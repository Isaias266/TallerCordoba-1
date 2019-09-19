using System;
using TallerAutos.DataAccessLayer;

namespace TallerAutos.Entities
{
    class Empleado
    {
        public int Legajo { get; set; }
        public Rol Rol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacim { get; set; }
        public DateTime FechaAlta { get; set; }
        public Sexo Sexo { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        /*
        public int Legajo { get => legajo; set => legajo = value; }
        public int Rol { get => rol; set => rol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Celular { get => celular; set => celular = value; }
        public DateTime FechaNacim { get => fechaNacim; set => fechaNacim = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public int Sexo { get => sexo; set => sexo = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        */
    }
}
