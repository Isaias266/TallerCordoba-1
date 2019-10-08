using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerAutos.Entities
{
    public class Vehiculo
    {
        public string Patente { get; set; }
        public Cliente Cliente { get; set; }
        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }

        public override string ToString()
        {
            return Patente;
        }
    }
}
