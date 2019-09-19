using System;
using System.Data;
using System.Windows.Forms;
using TallerAutos.DataAccessLayer;

namespace TallerAutos.GUILayer
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
            string strSql = "SELECT O.codOrden, E.nombre, FP.nombre, O.fechaPago, O.fechaAlta, O.fechaCierre, O.montoTotal," +
                                    " O.descripcionFalla, O.dniCliente, C.nombre, C.apellido, O.patente, M.nombre, Mo.nombre " +
                            "FROM Ordenes O JOIN Estados E ON (O.codEstado = E.codEstado) " +
                            "               FULL JOIN FormasPago FP ON (O.formaPago = FP.codFormaPago) " +
                            "               JOIN Clientes C ON (O.dniCliente = C.dni) " +
                            "               JOIN Vehiculos V ON (O.patente = V.patente) " +
                            "               FULL JOIN Marcas M ON (V.codMarca = M.codMarca) " +
                            "               FULL JOIN Modelos Mo ON (V.codModelo = Mo.codModelo) " +
                            "WHERE O.codOrden = " + codOrden;

            tabla = cDB.consultar(strSql);

            txtCO.Text = tabla.Rows[0][0].ToString();
            txtEstado.Text = tabla.Rows[0][1].ToString();
            txtFormaPago.Text = tabla.Rows[0][2].ToString();
            txtFechaPago.Text = tabla.Rows[0][3].ToString();
            txtFechaAlta.Text = tabla.Rows[0][4].ToString();
            txtFechaCierre.Text = tabla.Rows[0][5].ToString();
            txtMontoTotal.Text = tabla.Rows[0][6].ToString();
            txtDescripcion.Text = tabla.Rows[0][7].ToString();
            txtDni.Text = tabla.Rows[0][8].ToString();
            txtNombre.Text = tabla.Rows[0][9].ToString();
            txtApellido.Text = tabla.Rows[0][10].ToString();
            txtPatente.Text = tabla.Rows[0][11].ToString();
            txtMarca.Text = tabla.Rows[0][12].ToString();
            txtModelo.Text = tabla.Rows[0][13].ToString();

            txtCO.Enabled = false;
            txtEstado.Enabled = false;
            txtFormaPago.Enabled = false;
            txtFechaPago.Enabled = false;
            txtFechaAlta.Enabled = false;
            txtFechaCierre.Enabled = false;
            txtMontoTotal.Enabled = false;
            txtDescripcion.Enabled = false;
            txtDni.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtPatente.Enabled = false;
            txtMarca.Enabled = false;
            txtModelo.Enabled = false;
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}