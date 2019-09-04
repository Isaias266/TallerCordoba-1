using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace TallerAutos.Clases
{
    class Estados
    {

        private int codEstado;
        private string nombre;
        private string descripcion;

        BaseDeDatos sDB = new BaseDeDatos();

        public DataTable recuperarEstados()
        {
            DataTable tabla = new DataTable();
            tabla = sDB.consultarTabla("Estados");
            return tabla;

        }

    }
}
