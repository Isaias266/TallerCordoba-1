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
        private Cliente clienteSeleccionado;
        private BindingList<DetalleOT> listadoDetalleOT;
        private int ultimo_indice;
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

            LlenarCombo(this.cboEstado, sEstado.RecuperarEstados(), "nombre", "codEstado");
            LlenarCombo(this.cboFormaPago, sFormasPago.RecuperarFormasPago(), "nombre", "codFormaPago");
            this.cboFormaPago.SelectedIndex = 0;
            
            this.txtCodOrden.Enabled = false;
           
            switch (formMode)
            {
                //Modo crear Orden de Trabajo
                case FormMode.insert:
                    {
                        
                        CargarDgvDetalles();
                        HabilitarTxt(true);
                        this.txtFechaAlta.Enabled = false;
                        this.txtFechaAlta.Value = DateTime.Now;
                        this.txtFechaCierre.Enabled = false;
                        this.cboEstado.Enabled = false;
                        this.cboEstado.SelectedIndex = 1;
                        this.txtCliente.Enabled = false;
                        
                        //Si es necesario más adelante se agrupara en un método la habilitacion de los botones.
                        this.btnEditar.Enabled = false;
                        this.btnEliminar.Enabled = false;
                        this.btnAceptar.Enabled = true;
                        this.btnCancelar.Enabled = true;
                        this.btnNuevo.Enabled = true;
                        this.btnEditarCliente.Enabled = true;

                        break;
                    }

                case FormMode.update:
                    {
                        CompletarDatosOt();
                        LlenarDatosForm();
                        CargarDgvDetalles();
                        //Obtengo el último indice una vez cargado el datagrid.
                        ultimo_indice = (dgvDetalles.Rows.Count) - 1;
                        HabilitarTxt(true);
                        this.txtCliente.Enabled = false;
                        this.txtFechaAlta.Enabled = false;
                        this.txtFechaCierre.Enabled = false;
                        this.btnEditar.Text = "Detalle";
                        //Si es necesario más adelante se agrupara en un método la habilitacion de los botones.
                        this.btnEditar.Enabled = false;
                        this.btnEliminar.Enabled = false;
                        this.btnEliminar.Visible = false;
                        this.btnAceptar.Enabled = true;
                        this.btnCancelar.Enabled = true;
                        this.btnNuevo.Enabled = true;
                        this.btnEditarCliente.Enabled = true;

                        break;
                    }

                case FormMode.details:
                    {
                        CompletarDatosOt();
                        LlenarDatosForm();
                        CargarDgvDetalles();
                        HabilitarTxt(false);
                        this.btnEditar.Text = "Detalle";
                        //Si es necesario más adelante se agrupara en un método la habilitacion de los botones.
                        this.btnEditar.Enabled = true;
                        this.btnEliminar.Enabled = false;
                        this.btnEliminar.Visible = false;
                        this.btnAceptar.Enabled = true;
                        this.btnCancelar.Enabled = true;
                        this.btnNuevo.Enabled = false;
                        this.btnNuevo.Visible = false;
                        this.btnEditarCliente.Enabled = false;
                        break;
                    }
            }
        }


        private void CompletarDatosOt()
        {
            string condicion = " AND D.codOrden = " + otSeleccionada.CodOrden;
            otSeleccionada.DetalleOT = sDetalle.ConsultarDetalles(condicion);
            for(int i = 0; i < otSeleccionada.DetalleOT.Count; i++)
            {
                int codOrden = otSeleccionada.CodOrden;
                int numTrabajo = otSeleccionada.DetalleOT[i].NumTrabajo;
                (otSeleccionada.DetalleOT[i].Repuesto, otSeleccionada.DetalleOT[i].Cantidades) = sDetalle.ObtenerRepuestos(codOrden, numTrabajo);
            }

            this.listadoDetalleOT = new BindingList<DetalleOT>(otSeleccionada.DetalleOT);
            
        }
        private void LlenarDatosForm()
        {
            
            SeleccionarCliente(otSeleccionada.Cliente);
            txtCodOrden.Text = otSeleccionada.CodOrden.ToString();
            txtCombustible.Text = otSeleccionada.CantidadCombustible.ToString();
            txtDescripcion.Text = otSeleccionada.DescripcionFalla.ToString();
            txtFechaAlta.Value = Convert.ToDateTime(otSeleccionada.FechaAlta);
            txtFechaCierre.Value = Convert.ToDateTime(otSeleccionada.FechaCierre);
            txtKilometraje.Text = otSeleccionada.Kilometraje.ToString();
            cboEstado.Text = otSeleccionada.Estado.Nombre;
            cboFormaPago.Text = otSeleccionada.FormaPago.Nombre;
            
            
        }

        private void HabilitarTxt(bool x)
        {
            this.txtCombustible.Enabled = x;
            this.txtDescripcion.ReadOnly = !x;
            this.txtFechaAlta.Enabled = x;
            this.txtFechaCierre.Enabled = x;
            this.txtKilometraje.Enabled = x;
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

                switch (formMode)
                {
                    case FormMode.insert:
                        {
                            this.oOTService.Crear(oOT);
                            MessageBox.Show("Orden cargada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            break;
                        }

                    case FormMode.update:
                        {

                            this.oOTService.Update(oOT,ultimo_indice+1);
                            MessageBox.Show("Orden actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            break;
                        }
                    case FormMode.details:
                        {
                            this.Close();
                            break;
                        }
                }
                
            }
            else
            {
                MessageBox.Show("No se han completado uno o más campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LlenarDatosOT(OrdenTrabajo oOT)
        {
            //Si esta lleno el txt de CodOrden significa que esta en modo edición.
            if (!String.IsNullOrEmpty(txtCodOrden.Text)) oOT.CodOrden = Convert.ToInt32(txtCodOrden.Text);
            oOT.Estado = new Estado();
            oOT.FormaPago = new FormaPago();
            oOT.Cliente = new Cliente();
            oOT.Vehiculo = new Vehiculo();

            oOT.FechaAlta = txtFechaAlta.Value;
            if (cboEstado.Text == "Cerrada") oOT.FechaCierre = DateTime.Now;
            else oOT.FechaCierre = otSeleccionada.FechaCierre;
            if (cboEstado.Text == "Cobrada") oOT.FechaPago = DateTime.Now;
            else oOT.FechaPago = otSeleccionada.FechaPago;
            oOT.Cliente = clienteSeleccionado; //(Cliente)cboCliente.SelectedItem;
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

        public void EliminarTrabajo(DetalleOT ot)
        {
            listadoDetalleOT.Remove(ot);
        }

        private bool validarCamposObl()
        {
            if (clienteSeleccionado == null || String.IsNullOrEmpty(txtCombustible.Text) || cboVehiculo.SelectedIndex == -1 ||
                String.IsNullOrEmpty(txtKilometraje.Text) || String.IsNullOrEmpty(txtDescripcion.Text))
            {
                return false;
            }
            return true;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
           
            frmDetallesOT frmDetallesOT = new frmDetallesOT();
            frmDetallesOT.SeleccionarDOT(frmDetallesOT.FormMode.insert, empleadoSesion);
            AddOwnedForm(frmDetallesOT);
            frmDetallesOT.FormClosing += frmDetalleOT_FormClosing;
            this.Hide();
            frmDetallesOT.Show();
        }

        private void frmDetalleOT_FormClosing(object sender, EventArgs e)
        {
            this.Show();
            CargarDgvDetalles();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                int indice = dgvDetalles.CurrentRow.Index;
                DetalleOT trabajo = listadoDetalleOT[indice];
                frmDetallesOT frmDetallesOT = new frmDetallesOT();
                //Si esta en crear ot, seteamos el FormMode en update
                if(this.btnEditar.Text == "Editar") frmDetallesOT.SeleccionarDOT(frmDetallesOT.FormMode.update, empleadoSesion);
                //Si esta en editar, lo seteamos en detail, ya que no se va a permitir la modificacion de los detalles. (Unicamente agregar)
                if(this.btnEditar.Text == "Detalle") frmDetallesOT.SeleccionarDOT(frmDetallesOT.FormMode.detail, empleadoSesion);
                frmDetallesOT.SeleccionarTrabajo(trabajo);
                AddOwnedForm(frmDetallesOT);
                frmDetallesOT.FormClosing += frmDetalleOT_FormClosing;
                
                this.Hide();
                
                frmDetallesOT.Show();

            }
            else
            {
                MessageBox.Show("Seleccione un trabajo antes de comenzar a editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow != null)
            {
                int indice = dgvDetalles.CurrentRow.Index;
                listadoDetalleOT.RemoveAt(indice);
                MessageBox.Show("El trabajo se ha eliminado con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDgvDetalles();

            }
            else
            {
                MessageBox.Show("Debe seleccionar un trabajo para poder eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void frmClientes_FormClosing(object sender, EventArgs e)
        {
            this.Show();
        }

        public void SeleccionarCliente(Cliente clienteSelec)
        {
            
            this.txtCliente.Enabled = false;
            this.txtCliente.Text = clienteSelec.Nombre + " " + clienteSelec.Apellido;
            //Cargo el combo de vehiculos del cliente.
            this.cboVehiculo.SelectedIndex = -1;
            IList<Vehiculo> lista = new List<Vehiculo>();
            lista = sVehiculo.ConsultarVehiculos("AND C.dni = " + clienteSelec.Dni);
            this.cboVehiculo.DataSource = lista;
            //Lograr que se vea el nombre del modelo en el Display Member.
            this.cboVehiculo.DisplayMember = "Patente";
            this.cboVehiculo.ValueMember = "Patente";
            this.clienteSeleccionado = clienteSelec;

        }

        private void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            frmClientes fC = new frmClientes(true);
            AddOwnedForm(fC);
            fC.FormClosing += frmClientes_FormClosing;
            fC.Show();
            this.Hide();
        }

        private void DgvDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (formMode != FormMode.details)
            {
                this.btnEditar.Enabled = true;
                this.btnEliminar.Enabled = true;
            }
        }

       
    }
}
