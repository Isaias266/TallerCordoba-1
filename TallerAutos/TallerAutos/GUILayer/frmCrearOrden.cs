using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;
using TallerAutos.BusinessLayer;

namespace TallerAutos.GUILayer
{
    public partial class frmCrearOrden : Form
    {
        private OrdenTrabajo otSeleccionada = new OrdenTrabajo();
        private DetalleOTService sDetalle;
        private FormasPagoService sFormasPago;
        private EstadoService sEstado;
        private ClienteService sCliente;
        private VehiculoService sVehiculo;
        private Empleado empleadoSesion;
        private FormMode formMode = FormMode.insert;
        public frmCrearOrden(Empleado empleadoSesion)
        {
            InitializeComponent();
            InitializeDataGridView();
            this.empleadoSesion = empleadoSesion;
            sDetalle = new DetalleOTService();
            sFormasPago = new FormasPagoService();
            sEstado = new EstadoService();
            sCliente = new ClienteService();
            sVehiculo = new VehiculoService();
        }

        public enum FormMode
        {
            insert,
            update,
            details
        }
        public void SeleccionarOT(FormMode modo, OrdenTrabajo otSel)
        {
            formMode = modo;
            otSeleccionada = otSel;
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCrearOrden_Load(object sender, EventArgs e)
        {
            LlenarCombo(this.cboCliente, sCliente.ConsultarClientes("AND 1=1"), "nombre", "dni");
            LlenarCombo(this.cboEstado, sEstado.RecuperarEstados(), "nombre", "codEstado");
            LlenarCombo(this.cboFormaPago, sFormasPago.RecuperarFormasPago(), "nombre", "codFormaPago");

            CargarDgvDetalles();
            this.txtCodOrden.Enabled = false;
            switch (formMode)
            {
                //Modo crear Orden de Trabajo
                case FormMode.insert:
                    {
                        
                        HabilitarTxt(true);
                        this.txtFechaAlta.Enabled = false;
                        this.txtFechaCierre.Enabled = false;
                        this.cboEstado.Enabled = false;
                        
                        //Si es necesario más adelante se agrupara en un método la habilitacion de los botones.
                        this.btnEditar.Enabled = false;
                        this.btnEliminar.Enabled = false;
                        this.btnAceptar.Enabled = true;
                        this.btnCancelar.Enabled = true;
                        this.btnNuevo.Enabled = true;

                        break;
                    }
            }
        }

        private void HabilitarTxt(bool x)
        {
            this.txtCombustible.Enabled = x;
            this.txtDescripcion.Enabled = x;
            this.txtFechaAlta.Enabled = x;
            this.txtFechaCierre.Enabled = x;
            this.txtKilometraje.Enabled = x;
            this.cboCliente.Enabled = x;
            this.cboEstado.Enabled = x;
            this.cboFormaPago.Enabled = x;
            this.cboVehiculo.Enabled = x;
        }

        private void InitializeDataGridView()
        {
            dgvDetalles.ColumnCount = 4;
            dgvDetalles.ColumnHeadersVisible = true;

            dgvDetalles.AutoGenerateColumns = false;

            //Cargado
            dgvDetalles.Columns[0].Name = "Codigo";
            dgvDetalles.Columns[0].DataPropertyName = "numTrabajo";

            dgvDetalles.Columns[1].Name = "Descripcion";
            dgvDetalles.Columns[1].DataPropertyName = "descripcion";

            dgvDetalles.Columns[2].Name = "Monto";
            dgvDetalles.Columns[2].DataPropertyName = "monto";

            dgvDetalles.Columns[3].Name = "Cantidad Respuestos";

            // Propiedades data grid view
            dgvDetalles.ReadOnly = true;
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.AllowUserToAddRows = false;
        }

        private void CargarDgvDetalles()
        {
            this.dgvDetalles.DataSource = sDetalle.ConsultarDetalles("AND D.codOrden = " + otSeleccionada.CodOrden);
        }

        private void LlenarCombo(ComboBox combo, Object fuente, string display, String value)
        {
            combo.DataSource = fuente;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.SelectedIndex = -1;
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void CboCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cboVehiculo.SelectedIndex = -1;
            IList<Vehiculo> lista = new List<Vehiculo>();
            lista = sVehiculo.ConsultarVehiculos("AND C.dni = " + this.cboCliente.SelectedValue);
            this.cboVehiculo.DataSource = lista;
            //Lograr que se vea el nombre del modelo en el Display Member.
            this.cboVehiculo.DisplayMember = "Patente";
            this.cboVehiculo.ValueMember = "Patente";
            //LlenarCombo(this.cboVehiculo, sVehiculo.consultarVehiculos("AND C.dni = " + this.cboCliente.SelectedValue), "Modelo.Nombre", "patente");
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmDetallesOT frmDetallesOT = new frmDetallesOT();
            frmDetallesOT.SeleccionarDOT(frmDetallesOT.FormMode.insert, empleadoSesion);
            frmDetallesOT.Show();
        }

        private void PanelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
