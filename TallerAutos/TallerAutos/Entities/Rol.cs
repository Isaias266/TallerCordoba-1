using System;
using System.Data;

namespace TallerAutos.Entities
{
    public class Rol
    {
        public int CodRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        /*
        public int CodRol { get => codRol; set => codRol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; } 
        */

        public override string ToString()
        {
            return Nombre;
        }
    }
}
