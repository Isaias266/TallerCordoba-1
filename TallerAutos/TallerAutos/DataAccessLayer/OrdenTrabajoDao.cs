using System;
using System.Collections.Generic;
using System.Data;
using TallerAutos.Entities;

namespace TallerAutos.DataAccessLayer
{
    class OrdenTrabajoDao
    { 
        BaseDeDatos otDB = new BaseDeDatos();

        public IList<OrdenTrabajo> ConsultarOT(string condicionesSql)
        {
            List<OrdenTrabajo> listaOT = new List<OrdenTrabajo>();

            string strSql = "SELECT O.codOrden, " +
                                   "O.codEstado as codEstado, " +
                                   "O.patente, " +
                                   "O.dniCliente, " +
                                   "O.formaPago as codFormaPago, " +                                   
                                   "O.cantidadCombustible, " +
                                   "O.kilometraje, " +
                                   "O.fechaAlta, " +
                                   "O.fechaCierre, " +
                                   "O.descripcionFalla, " +
                                   "O.fechaPago, " +
                                   "O.montoTotal, " +
                                   "E.nombre as nombreEstado, " +
                                   "FP.nombre as nombreFormaPago " +
                                   "FROM Ordenes O FULL JOIN Estados E ON (O.codEstado = E.codEstado) " +
                                   "FULL JOIN FormasPago FP ON (O.formaPago = FP.codFormaPago) " +
                                   "WHERE 1=1 ";

            strSql += condicionesSql;
            strSql += " ORDER BY O.fechaAlta DESC";

            var resultadoConsulta = (DataRowCollection)otDB.Consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listaOT.Add(MappingOT(row));
            }

            return listaOT;
        }

        public bool Crear(OrdenTrabajo oOT)
        {
            try
            {
                otDB.Conectar();
                otDB.ComenzarTransaccion();

                string sql = "INSERT INTO Ordenes (" +
                    "codEstado, " +
                    "patente, " +
                    "dniCliente, " +
                    "formaPago, " +
                    "cantidadCombustible, " +
                    "kilometraje, " +
                    "fechaAlta, " +
                    "fechaCierre, " +
                    "descripcionFalla, " +
                    "fechaPago, " +
                    "montoTotal) " +
                    "VALUES (" +
                    oOT.Estado.CodEstado + ", '" +
                    oOT.Vehiculo.Patente + "', " +
                    oOT.Cliente.Dni + ", " +
                    oOT.FormaPago.CodFormaPago.ToString() + ", " +
                    oOT.CantidadCombustible + ", " +
                    oOT.Kilometraje + ", '" +
                    oOT.FechaAlta.ToString() + "', '" +
                    oOT.FechaCierre.ToString() + "', '" +
                    oOT.DescripcionFalla + "', '" +
                    oOT.FechaPago.ToString() + "', " +
                    oOT.MontoTotal.ToString().Replace(",", ".") + ")";

                otDB.Insertar_Transaccion(sql);
                var newId = otDB.ConsultaSQLScalar(" SELECT @@IDENTITY");
                oOT.CodOrden = Convert.ToInt32(newId);

                foreach (var trabajo in oOT.DetalleOT)
                {
                    string sqlDetalle = "INSERT INTO DetallesOrdenTrabajo (" +
                        "codOrden, " +
                        "legajoEmpleado, " +
                        "descripcion, " +
                        "monto) " +
                        "VALUES (" +
                        oOT.CodOrden + ", " +
                        trabajo.Empleado.Legajo + ", '" +
                        trabajo.Descripcion + "', " +
                        trabajo.Monto.ToString().Replace(",", ".") + ")";

                    otDB.Insertar_Transaccion(sqlDetalle);
                    newId = otDB.ConsultaSQLScalar(" SELECT @@IDENTITY");
                    trabajo.NumTrabajo = Convert.ToInt32(newId);

                    int i = 0;
                    foreach (var repuesto in trabajo.Repuesto)
                    {
                        string sqlRepuesto = "INSERT INTO RepuestosxTrabajos (" +
                            "codOrden, " +
                            "codRepuesto, " +
                            "numTrabajo, " +
                            "cantidad) " +
                            "VALUES (" +
                            oOT.CodOrden + ", " +
                            repuesto.CodRepuesto + ", " +
                            trabajo.NumTrabajo + ", " +
                            trabajo.Cantidades[i] + ")";

                        otDB.Insertar_Transaccion(sqlRepuesto);

                        string sqlUpdateRepuesto = "UPDATE Repuestos SET " +
                            "stock=" + (repuesto.Stock - trabajo.Cantidades[i]) + " " +
                            "WHERE codRepuesto=" + repuesto.CodRepuesto;

                        otDB.Insertar_Transaccion(sqlUpdateRepuesto);

                        i++;
                    }
                }

                otDB.Commit();
            }
            catch (Exception ex)
            {
                otDB.Rollback();
                throw ex;
            }
            finally
            {
                otDB.Desconectar();
            }
            return true;
        }

        private OrdenTrabajo MappingOT(DataRow row)
        {
            OrdenTrabajo oOT = new OrdenTrabajo();
            oOT.Estado = new Estado();

            oOT.CodOrden = Convert.ToInt32(row["codOrden"].ToString());

            oOT.Estado.CodEstado = Convert.ToInt32(row["codEstado"].ToString());
            oOT.Estado.Nombre = row["nombreEstado"].ToString();

            oOT.Vehiculo = new Vehiculo();
            oOT.Vehiculo.Patente = row["patente"].ToString();

            oOT.Cliente = new Cliente();
            oOT.Cliente.Dni = Convert.ToInt32(row["dniCliente"]);

            if (row["nombreFormaPago"].ToString() != "")
            {
                oOT.FormaPago = new FormaPago();
                oOT.FormaPago.CodFormaPago = Convert.ToInt32(row["codFormaPago"].ToString());
                oOT.FormaPago.Nombre = row["nombreFormaPago"].ToString();
            }
            
            oOT.CantidadCombustible = Convert.ToInt32(row["cantidadCombustible"].ToString());
            oOT.Kilometraje = Convert.ToInt32(row["kilometraje"].ToString());
            if (row["fechaAlta"].ToString() != "")
                oOT.FechaAlta = Convert.ToDateTime(row["fechaAlta"].ToString());
            if (row["fechaCierre"].ToString() != "")
                oOT.FechaCierre = Convert.ToDateTime(row["fechaCierre"].ToString());
            if (row["descripcionFalla"].ToString() != "")
                oOT.DescripcionFalla = row["descripcionFalla"].ToString();
            if (row["fechaPago"].ToString() != "")
                oOT.FechaPago = Convert.ToDateTime(row["fechaPago"].ToString());
            if (row["montoTotal"].ToString() != "")
                oOT.MontoTotal = Convert.ToDecimal(row["montoTotal"].ToString());

            return oOT;
        }
    }
}
