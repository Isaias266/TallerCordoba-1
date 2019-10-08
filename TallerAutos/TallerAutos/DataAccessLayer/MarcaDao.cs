using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TallerAutos.Entities;

namespace TallerAutos.DataAccessLayer
{
    class MarcaDao
    {
        BaseDeDatos mDB = new BaseDeDatos();

        public List<Marca> RecuperarMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            DataTable tabla = new DataTable();
            tabla = mDB.ConsultarTabla("Marcas");
            foreach(DataRow row in tabla.Rows)
            {
                listaMarcas.Add(MappingMarcas(row));
            }

            return listaMarcas;

        }

        private Marca MappingMarcas(DataRow row)
        {
            Marca oMarca = new Marca()
            {

                CodMarca = Convert.ToInt32(row["codMarca"].ToString()),
                Nombre = row["nombre"].ToString()

            };

            return oMarca;
        }
    }
}
