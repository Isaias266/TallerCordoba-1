using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.Entities;

namespace TallerAutos.DataAccessLayer
{
    class RepuestoDao
    {
        BaseDeDatos rBD = new BaseDeDatos();

        public void CargarRepuesto(Repuesto r)
        {
            string insercionSQL = "INSERT INTO Repuestos (codMarca, codModelo, nombre, descripcion, " +
                                  "precioUnitario, stock, fabricante, borrado) " +
                                  "VALUES (" +
                                  r.Marca.CodMarca + ", " +
                                  r.Modelo.CodModelo + ", '" +
                                  r.Nombre + "', '" +
                                  r.Descripcion + "', " +
                                  r.PrecioUnitario.ToString().Replace(',', '.') + ", " +
                                  r.Stock + ", '" +
                                  r.Fabricante + "', 0)";
            rBD.Insertar(insercionSQL);
        }

        public void ActualizarRepuesto(Repuesto r)
        {
            string actualizacionSQL = "UPDATE Repuestos " +
                                      "SET " +
                                      "codMarca=" + r.Marca.CodMarca + ", " +
                                      "codModelo=" + r.Modelo.CodModelo + ", " +
                                      "nombre='" + r.Nombre + "', " +
                                      "descripcion='" + r.Descripcion + "', " +
                                      "precioUnitario=" + r.PrecioUnitario.ToString().Replace(',','.')  + ", " +
                                      "stock=" + r.Stock + ", " +
                                      "fabricante='" + r.Fabricante + "' " +
                                      "WHERE codRepuesto=" + r.CodRepuesto;
            rBD.Insertar(actualizacionSQL);
        }

        public IList<Repuesto> ConsultarRepuestos(string condicionesSql)
        {
            List<Repuesto> listaRepuestos = new List<Repuesto>();

            string strSql = "SELECT R.codRepuesto, " +
                                   "R.codMarca, " +
                                   "R.codModelo, " +
                                   "R.nombre as nombreRepuesto, " +
                                   "R.descripcion, " +
                                   "R.precioUnitario, " +
                                   "R.stock, " +
                                   "R.fabricante, " +
                                   "M.nombre as nombreMarca, " +
                                   "Mod.nombre as nombreModelo " +
                                   "FROM Repuestos R FULL JOIN Marcas M ON (R.codMarca = M.codMarca) " +
                                   "FULL JOIN Modelos Mod ON (R.codModelo = Mod.codModelo) " +
                                   "WHERE borrado=0 ";
            strSql += condicionesSql;
            strSql += " ORDER BY R.codRepuesto DESC";

            var resultadoConsulta = (DataRowCollection)rBD.Consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                if (!string.IsNullOrEmpty(row["codRepuesto"].ToString()))
                    listaRepuestos.Add(MappingRepuesto(row));
            }

            return listaRepuestos;
        }

        public void EliminarRepuesto(Repuesto r)
        {
            string eliminacionSQL = "UPDATE Repuestos SET borrado = 1 WHERE codRepuesto = " + r.CodRepuesto;
            rBD.Insertar(eliminacionSQL);
        }

        private Repuesto MappingRepuesto(DataRow row)
        {
            Repuesto oRepuesto = new Repuesto();
            oRepuesto.Marca = new Marca();

            oRepuesto.CodRepuesto = Convert.ToInt32(row["codRepuesto"].ToString());
            oRepuesto.Nombre = row["nombreRepuesto"].ToString();
            oRepuesto.Marca.CodMarca = Convert.ToInt32(row["codMarca"].ToString());
            oRepuesto.Marca.Nombre = row["nombreMarca"].ToString();
            oRepuesto.PrecioUnitario = Convert.ToDecimal(row["precioUnitario"].ToString());
            oRepuesto.Stock = Convert.ToInt32(row["stock"].ToString());

            if (row["nombreModelo"].ToString() != "")
            {
                oRepuesto.Modelo = new Modelo();
                oRepuesto.Modelo.CodModelo = Convert.ToInt32(row["codModelo"].ToString());
                oRepuesto.Modelo.Nombre = row["nombreModelo"].ToString();
            }
            if (row["descripcion"].ToString() != "")
                oRepuesto.Descripcion = row["descripcion"].ToString();
            if (row["fabricante"].ToString() != "")
                oRepuesto.Fabricante = row["fabricante"].ToString();

            return oRepuesto;
        }
                
    }
}
