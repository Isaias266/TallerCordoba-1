using System;
using System.Collections.Generic;
using TallerAutos.Entities;

namespace TallerAutos.Entities
{
    public class OrdenTrabajo
    {
        public IList<DetalleOT> DetalleOT { get; set; }
        public int CodOrden { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Cliente Cliente { get; set; }
        public int CantidadCombustible { get; set; }
        public int Kilometraje { get; set; }
        public DateTime FechaAlta { get; set; }
        // El signo ? es para indicar que fechacierre puede tomar valores nulos.
        public DateTime? FechaCierre { get; set; }
        public DateTime HoraAlta { get; set; }
        public DateTime HoraCierre { get; set; }
        public string DescripcionFalla { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoTotal { get; set; }
        public Estado Estado { get; set; }
        public FormaPago FormaPago { get; set; }
    }
}
