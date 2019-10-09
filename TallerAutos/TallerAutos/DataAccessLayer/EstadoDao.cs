using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.Entities;
using System.Data;

namespace TallerAutos.DataAccessLayer
{
    class EstadoDao
    {
        BaseDeDatos eDB = new BaseDeDatos();

        public List<Estado> RecuperarEstados()
        {
            List<Estado> listaEstados = new List<Estado>();
            DataTable tabla = new DataTable();
            tabla = eDB.ConsultarTabla("Estados");
            foreach (DataRow row in tabla.Rows)
            {
                listaEstados.Add(MappingEstados(row));
            }

            return listaEstados;
        }

        private Estado MappingEstados(DataRow row)
        {
            Estado oEstado = new Estado();

            oEstado.CodEstado = Convert.ToInt32(row["codEstado"].ToString());
            oEstado.Nombre = row["nombre"].ToString();
            

            return oEstado;
        }
    }
}

