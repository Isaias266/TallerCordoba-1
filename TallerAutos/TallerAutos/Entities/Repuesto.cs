using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerAutos.Entities
{
    public class Repuesto
    {
        public int CodRepuesto { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public string Fabricante { get; set; }
    }
}
