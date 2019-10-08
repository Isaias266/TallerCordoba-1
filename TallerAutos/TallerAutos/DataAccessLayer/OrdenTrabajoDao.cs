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
                                   "O.codEstado, " +
                                   "E.nombre as nombreEstado, " +
                                   "O.patente, " +
                                   "O.dniCliente, " +
                                   "O.formaPago, " +
                                   "FP.nombre as nombreFormaPago, " +
                                   "O.cantidadCombustible, " +
                                   "O.kilometraje, " +
                                   "O.fechaAlta, " +
                                   "O.fechaCierre, " +
                                   "O.descripcionFalla, " +
                                   "O.fechaPago, " +
                                   "O.montoTotal " +
                                   "FROM Ordenes O JOIN Estados E ON (O.codEstado = E.codEstado) " +
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

        private OrdenTrabajo MappingOT(DataRow row)
        {
            OrdenTrabajo oOT = new OrdenTrabajo();

            oOT.CodOrden = Convert.ToInt32(row["codOrden"].ToString());

            oOT.Estado = new Estado();
            oOT.Estado.CodEstado = Convert.ToInt32(row["codEstado"].ToString());
            oOT.Estado.Nombre = row["nombreEstado"].ToString();

            oOT.Patente = row["patente"].ToString();
            oOT.DniCliente = Convert.ToInt32(row["dniCliente"]);

            if (row["nombreFormaPago"].ToString() != "")
            {
                oOT.FormaPago = new FormaPago();
                oOT.FormaPago.CodFormaPago = Convert.ToInt32(row["formaPago"].ToString());
                oOT.FormaPago.Nombre = row["nombreFormaPago"].ToString();
            }
            
            oOT.CantidadCombustible = Convert.ToInt32(row["cantidadCombustible"].ToString());
            oOT.Kilometraje = Convert.ToInt32(row["kilometraje"].ToString());
            if (row["fechaAlta"].ToString() != "")
                oOT.FechaAlta = Convert.ToDateTime(row["fechaAlta"].ToString());
            if (row["fechaCierre"].ToString() != "")
                oOT.FechaCierre = Convert.ToDateTime(row["fechaCierre"].ToString());
            /*
            if (row["HoraAlta"].ToString() != "")
                oOT.HoraAlta = Convert.ToDateTime(row["HoraAlta"].ToString());
            if (row["HoraCierre"].ToString() != "")
                oOT.HoraCierre = Convert.ToDateTime(row["HoraCierre"].ToString());
            */
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
