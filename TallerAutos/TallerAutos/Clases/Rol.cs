using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TallerAutos.Clases
{
    class Rol
    {
        private int codRol;
        private string nombre;
        private string descripcion;

        BaseDeDatos rDB = new BaseDeDatos();
        public int CodRol { get => codRol; set => codRol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public DataTable recuperarRoles()
        {
            DataTable tabla = new DataTable();
            tabla = rDB.consultarTabla("Roles");
            return tabla;
        }

    }
}
