using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerAutos.Clases
{

    class OrdenTrabajo
    {
        private int codOrden;
        private int codEstado;
        private string patente;
        private int dniCliente;
        private int cantidadCombustible;
        private int kilometraje;
        private DateTime fechaAlta;
        private DateTime fechaCierre;
        private DateTime horaAlta;
        private DateTime horaCierre;
        private string descripcionFalla;
        private int formaPago;
        private DateTime fechaPago;
        private float montoTotal;

        public int CodOrden { get => codOrden; set => codOrden = value; }
        public int CodEstado { get => codEstado; set => codEstado = value; }
        public string Patente { get => patente; set => patente = value; }
        public int DniCliente { get => dniCliente; set => dniCliente = value; }
        public int CantidadCombustible { get => cantidadCombustible; set => cantidadCombustible = value; }
        public int Kilometraje { get => kilometraje; set => kilometraje = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public DateTime FechaCierre { get => fechaCierre; set => fechaCierre = value; }
        public DateTime HoraAlta { get => horaAlta; set => horaAlta = value; }
        public DateTime HoraCierre { get => horaCierre; set => horaCierre = value; }
        public string DescripcionFalla { get => descripcionFalla; set => descripcionFalla = value; }
        public int FormaPago { get => formaPago; set => formaPago = value; }
        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }
        public float MontoTotal { get => montoTotal; set => montoTotal = value; }

        BaseDeDatos otDB = new BaseDeDatos();

        public DataTable consultarOT(string strSql, Dictionary<string, object> prs)
        {
            DataTable dt = new DataTable();
            dt = otDB.ConsultaSQLConParametros(strSql, prs);
            return dt;
        }
    }
}
