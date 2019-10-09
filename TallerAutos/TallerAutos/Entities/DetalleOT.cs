using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.Entities;
using TallerAutos.DataAccessLayer;

namespace TallerAutos.Entities
{
    public class DetalleOT
    {
        private OrdenTrabajo ordenTrabajo;
        private int numTrabajo;
        private Empleado empleado;
        private string descripcion;
        private decimal monto;

        public OrdenTrabajo OrdenTrabajo { get => ordenTrabajo; set => ordenTrabajo = value; }
        public int NumTrabajo { get => numTrabajo; set => numTrabajo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Monto { get => monto; set => monto = value; }
        internal Empleado Empleado { get => empleado; set => empleado = value; }
    }
}
