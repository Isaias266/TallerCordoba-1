using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.DataAccessLayer;

namespace TallerAutos.Entities
{
    public class Cliente
    { 
        public int Dni { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }

        public override string ToString()
        {
            return Dni.ToString();
        }
    }
}
