using System;
using TallerAutos.Entities;

namespace TallerAutos.DataAccessLayer
{
    class OrdenTrabajo
    {
        public int CodOrden { get; set; }
        public Estado Estado { get; set; }
        public string Patente { get; set; }
        public int DniCliente { get; set; }
        public int CantidadCombustible { get; set; }
        public int Kilometraje { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaCierre { get; set; }
        public DateTime HoraAlta { get; set; }
        public DateTime HoraCierre { get; set; }
        public string DescripcionFalla { get; set; }
        public FormaPago FormaPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoTotal { get; set; }

        /*
        public int CodOrden { get => codOrden; set => codOrden = value; }
        public string Patente { get => patente; set => patente = value; }
        public int DniCliente { get => dniCliente; set => dniCliente = value; }
        public int CantidadCombustible { get => cantidadCombustible; set => cantidadCombustible = value; }
        public int Kilometraje { get => kilometraje; set => kilometraje = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public DateTime FechaCierre { get => fechaCierre; set => fechaCierre = value; }
        public DateTime HoraAlta { get => horaAlta; set => horaAlta = value; }
        public DateTime HoraCierre { get => horaCierre; set => horaCierre = value; }
        public string DescripcionFalla { get => descripcionFalla; set => descripcionFalla = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public decimal MontoTotal { get => montoTotal; set => montoTotal = value; }
        internal Estado Estado { get => estado; set => estado = value; }
        internal FormaPago FormaPago { get => formaPago; set => formaPago = value; }
        */
    }
}
