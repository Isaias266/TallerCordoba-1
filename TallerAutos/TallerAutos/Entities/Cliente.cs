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

        /*
         public string Apellido { get => apellido; set => apellido = value; }
         public string Nombre { get => nombre; set => nombre = value; }
         public string Domicilio { get => domicilio; set => domicilio = value; }
         public string Telefono { get => telefono; set => telefono = value; }
         public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
         public string Email { get => email; set => email = value; }
         public string Celular { get => celular; set => celular = value; }
         public int Dni { get => dni; set => dni = value; }
         internal Sexo Sexo { get => sexo; set => sexo = value; }
         */
    }
}
