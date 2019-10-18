using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.Entities;
using System.Data;

namespace TallerAutos.DataAccessLayer
{
    class ModeloDao
    {
        BaseDeDatos mDB = new BaseDeDatos();

        public List<Modelo> RecuperarModelos()
        {
            List<Modelo> listaModelos = new List<Modelo>();
            DataTable tabla = new DataTable();
            tabla = mDB.ConsultarTabla("Modelos");
            foreach (DataRow row in tabla.Rows)
            {
                listaModelos.Add(MappingModelos(row));
            }

            return listaModelos;

        }

        public IList<Modelo> ConsultarModelos(string condicionesSql)
        {
            List<Modelo> listaModelos = new List<Modelo>();

            string strSql = "SELECT M.codModelo,M.nombre, MA.nombre "+
                            "FROM Modelos M JOIN Marcas MA ON (M.codMarca = MA.codMarca) " +
                            "WHERE 1=1 ";

            strSql += condicionesSql;

            var resultadoConsulta = (DataRowCollection)mDB.Consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {
                if (!string.IsNullOrEmpty(row["codModelo"].ToString()))
                    listaModelos.Add(MappingModelos(row));
            }

            return listaModelos;
        }



        private Modelo MappingModelos(DataRow row)
        {
            Modelo oModelo = new Modelo()
            {

                CodModelo = Convert.ToInt32(row["codModelo"].ToString()),
                Nombre = row["nombre"].ToString()

            };

            return oModelo;
        }
    }
}
