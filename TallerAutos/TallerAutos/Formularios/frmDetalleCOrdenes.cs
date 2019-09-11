using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerAutos.Clases;

namespace TallerAutos.Formularios
{
    public partial class frmDetalleCOrdenes : Form
    {

        int codOrden;

        public frmDetalleCOrdenes(string idOrden)
        {
            InitializeComponent();
            this.codOrden = Convert.ToInt32(idOrden);
            
        }

        private void DetalleCOrdenes_Load(object sender, EventArgs e)
        {
            BaseDeDatos cDB = new BaseDeDatos();
            DataTable tabla = new DataTable();
            string strSql = "SELECT O.codOrden, E.nombre, FP.nombre, O.fechaPago, O.fechaAlta, O.fechaCierre, O.montoTotal, O.descripcionFalla, O.dniCliente, C.nombre, C.apellido, O.patente, M.nombre, Mo.nombre " +
                            "FROM Ordenes O JOIN Estados E ON (O.codEstado = E.codEstado) " +
                            "               FULL JOIN FormasPago FP ON (O.formaPago = FP.codFormaPago) " +
                            "               JOIN Clientes C ON (O.dniCliente = C.dni) "+
                            "               JOIN Vehiculos V ON (O.patente = V.patente) "+
                            "               FULL JOIN Marcas M ON (V.codMarca = M.codMarca) "+
                            "               FULL JOIN Modelos Mo ON (V.codModelo = Mo.codModelo) " +
                            "WHERE O.codOrden = " +codOrden;
            
            tabla = cDB.consultar(strSql);
            


        }

       

        
    }
}
