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

        public List<Modelo> recuperarModelos()
        {
            List<Modelo> listaModelos = new List<Modelo>();
            DataTable tabla = new DataTable();
            tabla = mDB.consultarTabla("Modelos");
            foreach (DataRow row in tabla.Rows)
            {
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
