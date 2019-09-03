using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TallerAutos.Clases
{
    class Sexo
    {
        private int codSexo;
        private string nombre;

        BaseDeDatos sDB = new BaseDeDatos();

        public DataTable recuperarSexos()
        {
            DataTable tabla = new DataTable();
            tabla = sDB.consultarTabla("Sexos");
            return tabla;
            
        } 
    }
}
