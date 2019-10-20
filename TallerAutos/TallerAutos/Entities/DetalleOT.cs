using System;
using System.Collections.Generic;

namespace TallerAutos.Entities
{
    public class DetalleOT
    {
        /*
        private OrdenTrabajo ordenTrabajo;
        private int numTrabajo;
        private Empleado empleado;
        private string descripcion;
        private decimal monto;
        */

        public IList<Repuesto> Repuesto { get; set; }
        public IList<int> Cantidades { get; set; }
        public OrdenTrabajo OrdenTrabajo { get; set; }
        public int NumTrabajo { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        internal Empleado Empleado { get; set; }
    }
}
