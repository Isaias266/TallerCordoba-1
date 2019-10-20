using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TallerAutos.Entities;
using TallerAutos.BusinessLayer;
using System.ComponentModel;

namespace TallerAutos.GUILayer
{
    public partial class frmCrearOrden : Form
    {
        private OrdenTrabajo otSeleccionada = new OrdenTrabajo();
        private OrdenTrabajoService oOTService;
        private DetalleOTService sDetalle;
        private FormasPagoService sFormasPago;
        private EstadoService sEstado;
        private ClienteService sCliente;
        private VehiculoService sVehiculo;
        private Empleado empleadoSesion;
        private BindingList<DetalleOT> listadoDetalleOT;
        private FormMode formMode = FormMode.insert;

        public frmCrearOrden(Empleado empleadoSesion)
        {
            InitializeComponent();
            InitializeDataGridView();
            oOTService = new OrdenTrabajoService();
            this.empleadoSesion = empleadoSesion;
            sDetalle = new DetalleOTService();
            sFormasPago = new FormasPagoService();
            sEstado = new EstadoService();
            sCliente = new ClienteService();
            sVehiculo = new VehiculoService();
            listadoDetalleOT = new BindingList<DetalleOT>();
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
                        this.cboEstado.SelectedIndex = 1;
                        
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
            dgvDetalles.Columns[0].Name = "Descripcion";
            dgvDetalles.Columns[0].DataPropertyName = "descripcion";

            dgvDetalles.Columns[1].Name = "Monto";
            dgvDetalles.Columns[1].DataPropertyName = "monto";

            dgvDetalles.Columns[2].Name = "Cantidad Respuestos";
            dgvDetalles.Columns[2].DataPropertyName = "cantRepuestos";

            dgvDetalles.Columns[3].Name = "Empleado";
            dgvDetalles.Columns[3].DataPropertyName = "empleado";

            // Propiedades data grid view
            dgvDetalles.ReadOnly = true;
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.AllowUserToAddRows = false;
        }

        private void CargarDgvDetalles()
        {
            int cantRepuestos = 0;
            dgvDetalles.RowCount = 0;
            for (int i = 0; i < listadoDetalleOT.Count; i++)
            {
                cantRepuestos = 0;
                for(int j=0; j<listadoDetalleOT[i].Cantidades.Count; j++)
                {
                    cantRepuestos += listadoDetalleOT[i].Cantidades[j];
                }
                dgvDetalles.Rows.Insert(i, listadoDetalleOT[i].Descripcion, listadoDetalleOT[i].Monto, cantRepuestos, 
                    listadoDetalleOT[i].Empleado.Nombre + " (" + listadoDetalleOT[i].Empleado.Legajo + ")");
            }
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
            this.Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCamposObl())
            {
                OrdenTrabajo oOT = new OrdenTrabajo();
                this.LlenarDatosOT(oOT);
                this.oOTService.Crear(oOT);

                MessageBox.Show("Orden cargada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se han completado uno o más campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LlenarDatosOT(OrdenTrabajo oOT)
        {
            oOT.Estado = new Estado();
            oOT.FormaPago = new FormaPago();
            oOT.Cliente = new Cliente();
            oOT.Vehiculo = new Vehiculo();

            oOT.FechaAlta = txtFechaAlta.Value;
            oOT.FechaCierre = null;
            oOT.Cliente = (Cliente)cboCliente.SelectedItem;
            oOT.Kilometraje = Convert.ToInt32(txtKilometraje.Text);
            oOT.Estado = (Estado)cboEstado.SelectedItem;
            oOT.FormaPago = (FormaPago)cboFormaPago.SelectedItem;
            oOT.Vehiculo = (Vehiculo)cboVehiculo.SelectedItem;
            oOT.CantidadCombustible = Convert.ToInt32(txtCombustible.Text);
            oOT.DescripcionFalla = txtDescripcion.Text;
            oOT.DetalleOT = this.listadoDetalleOT;
            oOT.MontoTotal = 0;
            foreach(var trabajo in oOT.DetalleOT)
            {
                oOT.MontoTotal += trabajo.Monto;
            }
        }

        public void CargarTrabajo(DetalleOT oDOT)
        {
            listadoDetalleOT.Add(oDOT);
        }

        private bool validarCamposObl()
        {
            if (cboCliente.SelectedIndex == -1 || String.IsNullOrEmpty(txtCombustible.Text) || cboVehiculo.SelectedIndex == -1 ||
                String.IsNullOrEmpty(txtKilometraje.Text) || String.IsNullOrEmpty(txtDescripcion.Text) || cboFormaPago.SelectedIndex == -1)
            {
                return false;
            }
            return true;
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
            //frmDetallesOT frmDetallesOT = new frmDetallesOT();
            //frmDetallesOT.SeleccionarDOT(frmDetallesOT.FormMode.insert, empleadoSesion);
            //frmDetallesOT.Show();

            frmDetallesOT frmDetallesOT = new frmDetallesOT();
            frmDetallesOT.SeleccionarDOT(frmDetallesOT.FormMode.insert, empleadoSesion);
            AddOwnedForm(frmDetallesOT);
            frmDetallesOT.FormClosing += frmDetalleOT_FormClosing;
            frmDetallesOT.Show();
        }

        private void frmDetalleOT_FormClosing(object sender, EventArgs e)
        {
            CargarDgvDetalles();
        }

        private void PanelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtCodOrden_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtFechaAlta_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtFechaCierre_TextChanged(object sender, EventArgs e)
        {

        }

        private void CboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtKilometraje_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCombustible_TextChanged(object sender, EventArgs e)
        {

        }

        private void CboVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void CboFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void TxtKilometraje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar)) //Al pulsar un número
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Teclas especial como borrar
            {
                e.Handled = false; //Se acepta
            }
            else //Para todas las demas teclas
            {
                e.Handled = true; //No se acepta
            }
        }

        private void TxtCombustible_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar)) //Al pulsar un número
            {
                e.Handled = false; //Se acepta
            }
            else if (Char.IsControl(e.KeyChar)) //Teclas especial como borrar
            {
                e.Handled = false; //Se acepta
            }
            else //Para todas las demas teclas
            {
                e.Handled = true; //No se acepta
            }
        }
    }
}
