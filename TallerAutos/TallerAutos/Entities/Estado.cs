using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerAutos.Entities
{
    class Estado
    {
        public int CodEstado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        /*
        public int CodEstado { get => codEstado; set => codEstado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        */
        public override string ToString()
        {
            return Nombre;
        }
    }
}
