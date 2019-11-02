using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;
using System.Data;
using System.Windows.Forms;
namespace TallerAutos.DataAccessLayer
{
    public class DetalleOTDao
    {
        BaseDeDatos dDB = new BaseDeDatos();

        public IList<DetalleOT> ConsultarDetalles(string condicionesSql)
        {
            List<DetalleOT> listaDetalles = new List<DetalleOT>();

            string strSql = "SELECT D.codOrden, " +
                                   "D.legajoEmpleado, " +
                                   "D.descripcion, " +
                                   "D.numTrabajo, " +
                                   "D.monto, " +
                                   "E.nombre as nombreEmpleado, " +
                                   "O.dniCliente "+
                                   "FROM DetallesOrdenTrabajo D JOIN Ordenes O ON (D.codOrden = O.codOrden) " +
                                   "JOIN Empleados E ON (D.legajoEmpleado = E.legajo) " +
                                   "WHERE D.borrado = 0 ";

            strSql += condicionesSql;


            var resultadoConsulta = (DataRowCollection)dDB.Consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {

                if (!string.IsNullOrEmpty(row["codOrden"].ToString()) && !string.IsNullOrEmpty(row["numTrabajo"].ToString())) {
                    listaDetalles.Add(MappingDetalleOT(row));
                }
            }

            return listaDetalles;
        }

        //Para facilitarlo, consulto y hago un mapeo personalizado en el mismo método.
        public (IList<Repuesto>,IList<int>) obtenerRepuestos(int codOrden, int numTrabajo)
        {

            List<Repuesto> listaRepuestos = new List<Repuesto>();
            List<int> listaCantidades = new List<int>();

            string strSql = "SELECT RT.cantidad as cantidad, R.codRepuesto, MA.codMarca as codigoMarca, MA.nombre as nombreMarca, MO.codModelo, MO.nombre as nombreModelo, " +
                            "R.nombre as nombreRepuesto, R.descripcion as descripcionRepuesto, R.precioUnitario as precioRepuesto, R.fabricante " +
                            "FROM RepuestosxTrabajos RT JOIN Repuestos R ON(RT.codRepuesto = R.codRepuesto) " +
                            "JOIN Marcas MA ON(R.codMarca = MA.codMarca) " +
                            "JOIN Modelos MO ON(R.codModelo = MO.codModelo) AND(R.codMarca = MO.codMarca) " +
                            "WHERE RT.codOrden = " + codOrden + " AND RT.numTrabajo = " + numTrabajo;

            //Borrar
            Console.Write(strSql);

            var resultadoConsulta = (DataRowCollection)dDB.Consultar(strSql).Rows;

            foreach (DataRow row in resultadoConsulta)
            {

                
                    Repuesto repuesto = new Repuesto();
                    listaCantidades.Add(Convert.ToInt32(row["cantidad"].ToString()));
                    repuesto.CodRepuesto = Convert.ToInt32(row["codRepuesto"].ToString());
                    repuesto.Nombre = row["nombreRepuesto"].ToString();
                    repuesto.Descripcion = row["descripcionRepuesto"].ToString();
                    repuesto.PrecioUnitario = Convert.ToDecimal(row["precioRepuesto"].ToString());
                    repuesto.Fabricante = row["fabricante"].ToString();
                    listaRepuestos.Add(repuesto);

                
            }

            return (listaRepuestos, listaCantidades);
        }

        //Mapeo simple
        private DetalleOT MappingDetalleOT(DataRow row)
        {
            DetalleOT oDetalle = new DetalleOT();

            oDetalle.OrdenTrabajo = new OrdenTrabajo();
            oDetalle.OrdenTrabajo.Cliente = new Cliente();
            oDetalle.OrdenTrabajo.CodOrden = Convert.ToInt32(row["codOrden"].ToString());
            oDetalle.OrdenTrabajo.Cliente.Dni = Convert.ToInt32(row["dniCliente"].ToString());
            oDetalle.Empleado = new Empleado();
            oDetalle.Empleado.Legajo = Convert.ToInt32(row["legajoEmpleado"].ToString());
            oDetalle.Empleado.Nombre = row["nombreEmpleado"].ToString();
            oDetalle.NumTrabajo = Convert.ToInt32(row["numTrabajo"].ToString());
            oDetalle.Descripcion = row["descripcion"].ToString();
            oDetalle.Monto = Convert.ToDecimal(row["monto"].ToString());

            return oDetalle;


        }

    }
}
