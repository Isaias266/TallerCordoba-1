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
                                   "FP.nombre as nombreFormaPago, " +
                                   "C.Nombre as nombreCliente, " +
                                   "C.Apellido as apellidoCliente " + 
                                   "FROM Ordenes O FULL JOIN Estados E ON (O.codEstado = E.codEstado) " +
                                   "FULL JOIN FormasPago FP ON (O.formaPago = FP.codFormaPago) " +
                                   "JOIN Clientes C ON (O.dniCliente = C.dni) " +
                                   "WHERE O.borrado = 0 ";

            strSql += condicionesSql;
            strSql += " ORDER BY O.fechaAlta DESC";

            var resultadoConsulta = (DataRowCollection)otDB.Consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                listaOT.Add(MappingOT(row));
            }

            return listaOT;
        }

        //Unicamente se pone en borrado el campo e la tabla ordenes, los detalles y los rXT permancerán aunque no podrán ser accedidos desde
        //el programa.
        public void EliminarOT(OrdenTrabajo ot)
        {
            string Esql = "UPDATE Ordenes set borrado = 1 " +
                          "WHERE codOrden = " + ot.CodOrden;

            otDB.Insertar(Esql);
        }


        //Hace un update de la ot e inserta los nuevos trabajos, sin tener en cuenta los anteriores que ya estaban insertados.
        public bool Update(OrdenTrabajo ot, int indice)
        {
            try
            {
                otDB.Conectar();
                otDB.ComenzarTransaccion();

                //Primero hago un update de la Orden
                string Usql = "UPDATE Ordenes SET codEstado = " + ot.Estado.CodEstado + "," +
                              "patente = '" + ot.Vehiculo.Patente + "'" + ", " +
                              "dniCliente = " + ot.Cliente.Dni + ", " +
                              "formaPago = " + ot.FormaPago.CodFormaPago + ", " +
                              "cantidadCombustible = " + ot.CantidadCombustible + ", " +
                              "kilometraje = " + ot.Kilometraje + ", " +
                              "fechaCierre = '" + ot.FechaCierre.ToString() + "'" + ", " +
                              "descripcionFalla = '" + ot.DescripcionFalla + "'" + ", " +
                              "fechaPago = '" + ot.FechaPago.ToString() + "'" + ", " +
                              "montoTotal = " + ot.MontoTotal.ToString().Replace(",", ".") + " " +
                              "WHERE codOrden = " + ot.CodOrden;

                Console.WriteLine(Usql);
                otDB.Insertar_Transaccion(Usql);

                //Tengo en cuenta que el indice que me pasan es desde el que debo arrancar a recorrer.
                for (int i = indice; i < ot.DetalleOT.Count; i++)
                {
                    string sqlDetalle = "INSERT INTO DetallesOrdenTrabajo (" +
                        "codOrden, " +
                        "legajoEmpleado, " +
                        "descripcion, " +
                        "monto) " +
                        "VALUES (" +
                        ot.CodOrden + ", " +
                        ot.DetalleOT[i].Empleado.Legajo + ", '" +
                        ot.DetalleOT[i].Descripcion + "', " +
                        ot.DetalleOT[i].Monto.ToString().Replace(",", ".") + ")";

                    Console.WriteLine(sqlDetalle);
                    otDB.Insertar_Transaccion(sqlDetalle);
                    var newId = otDB.ConsultaSQLScalar(" SELECT @@IDENTITY");
                    ot.DetalleOT[i].NumTrabajo = Convert.ToInt32(newId);

                    int j = 0;
                    foreach (var repuesto in ot.DetalleOT[i].Repuesto)
                    {
                        string sqlRepuesto = "INSERT INTO RepuestosxTrabajos (" +
                            "codOrden, " +
                            "codRepuesto, " +
                            "numTrabajo, " +
                            "cantidad) " +
                            "VALUES (" +
                            ot.CodOrden + ", " +
                            repuesto.CodRepuesto + ", " +
                            ot.DetalleOT[i].NumTrabajo + ", " +
                            ot.DetalleOT[i].Cantidades[j] + ")";

                        otDB.Insertar_Transaccion(sqlRepuesto);
                        Console.WriteLine(sqlRepuesto);
                        string sqlUpdateRepuesto = "UPDATE Repuestos SET " +
                            "stock=" + (repuesto.Stock - ot.DetalleOT[i].Cantidades[j]) + " " +
                            "WHERE codRepuesto=" + repuesto.CodRepuesto;

                        otDB.Insertar_Transaccion(sqlUpdateRepuesto);
                        Console.WriteLine(sqlUpdateRepuesto);
                        j++;
                    }
                }

                otDB.Commit();
            }

            catch(Exception ex)
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
            oOT.Cliente.Nombre = row["nombreCliente"].ToString();
            oOT.Cliente.Apellido = row["apellidoCliente"].ToString();

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
