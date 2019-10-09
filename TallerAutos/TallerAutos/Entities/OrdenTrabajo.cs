using System;
using TallerAutos.Entities;

namespace TallerAutos.Entities
{
    public class OrdenTrabajo
    {

        private int codOrden;
        private Estado estado;
        private string patente;
        private int dniCliente;
        private int cantidadCombustible;
        private int kilometraje;
        private DateTime fechaAlta;
        private DateTime fechaCierre;
        private DateTime horaAlta;
        private DateTime horaCierre;
        private string descripcionFalla;
        private FormaPago formaPago;
        private DateTime fechaPago;
        private decimal montoTotal;

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
