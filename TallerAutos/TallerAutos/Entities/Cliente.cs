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
        private int dni;
        private string apellido;
        private string nombre;
        private string domicilio;
        private string telefono;
        private string email;
        private string celular;
        private DateTime fechaNacimiento;
        public Sexo sexo;

        public int Dni { get => dni; set => dni = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Celular { get => celular; set => celular = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
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
