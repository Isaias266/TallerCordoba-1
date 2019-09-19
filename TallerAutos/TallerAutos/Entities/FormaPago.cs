using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerAutos.Entities
{
    class FormaPago
    {
        public int CodFormaPago { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        /*
        public int CodFormaPago { get => codFormaPago; set => codFormaPago = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        */
        public override string ToString()
        {
            return Nombre;
        }
    }
}
