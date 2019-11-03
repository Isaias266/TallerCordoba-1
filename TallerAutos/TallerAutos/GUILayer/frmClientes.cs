using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TallerAutos.BusinessLayer;
using TallerAutos.Entities;

namespace TallerAutos.GUILayer
{
    public partial class frmClientes : Form
    {
        ClienteService clienteService = new ClienteService();
        bool seleccion;


        public frmClientes(bool selec)
        {
            // ClienteService oClienteService = new ClienteService();
            this.seleccion = selec;
            InitializeComponent();
            InitializeDataGridView();
        }

        //Es el button Consultar
        private void Button1_Click(object sender, EventArgs e)
        {
            string strCondiciones = "";

            if (!chkTodos.Checked)
            {
                bool nomOk = false;
                bool dniOk = false;
                bool apOk = false;
                if (!String.IsNullOrEmpty(txtDNI.Text.ToString()))
                {
                    dniOk = true;
                    strCondiciones += "AND C.dni =" + "'" + txtDNI.Text.ToString() + "'"; 
                }

                if (!String.IsNullOrEmpty(txtNombre.Text))
                {
                    nomOk = true;
                    strCondiciones += "AND C.nombre =" + "'" + txtNombre.Text + "'"; 
                }

                if (!String.IsNullOrEmpty(txtApellido.Text))
                {
                    apOk = true;
                    strCondiciones += "AND C.apellido =" + "'" + txtApellido.Text + "'";
                }


                if (nomOk || apOk || dniOk)
                {
                    IList<Cliente> listaC = clienteService.ConsultarClientes(strCondiciones);
                    if (listaC.Count > 0)
                        this.dataGridClientes.DataSource = listaC;
                    else
                        MessageBox.Show("No se encontró ningún cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                else
                {
                    MessageBox.Show("No se ingresó ningún criterio de búsqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                this.CargarGrilla();
            }
        }

        private void InitializeDataGridView()
        {

            dataGridClientes.ColumnCount = 3;
            dataGridClientes.ColumnHeadersVisible = true;

            dataGridClientes.AutoGenerateColumns = false;

            /*DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dataGridClientes.ColumnHeadersDefaultCellStyle = columnHeaderStyle;*/

            dataGridClientes.Columns[0].Name = "DNI";
            dataGridClientes.Columns[0].DataPropertyName = "dni";

            dataGridClientes.Columns[1].Name = "Nombre";
            dataGridClientes.Columns[1].DataPropertyName = "nombre";

            dataGridClientes.Columns[2].Name = "Apellido";
            dataGridClientes.Columns[2].DataPropertyName = "apellido";

            /*dataGridClientes.AutoResizeColumnHeadersHeight();

            dataGridClientes.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);*/

            // Propiedades data grid view
            dataGridClientes.ReadOnly = true;
            this.dataGridClientes.MultiSelect = false;
            this.dataGridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridClientes.AllowUserToAddRows = false;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmABMClientes ABMCl = new frmABMClientes();
            ABMCl.FormClosing += frmABMClientes_FormClosing;
            ABMCl.Show();
            this.Hide();
        }


        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Cliente selected = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
           
            frmABMClientes frABMCl = new frmABMClientes();
            frABMCl.SeleccionarCliente(frmABMClientes.FormMode.update, selected);
            frABMCl.FormClosing += frmABMClientes_FormClosing;
            frABMCl.Show();
            this.Hide();

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            if (seleccion)
            {
                this.btnEditar.Visible = false;
                this.btnEliminar.Visible = false;
                this.btnDetalle.Visible = false;
                this.btnSeleccionar.Visible = true;
                this.btnSeleccionar.Enabled = false;
            }
            else
            {
                this.btnSeleccionar.Visible = false;
                this.btnEditar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnDetalle.Enabled = false;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Cliente selected = (Cliente)this.dataGridClientes.CurrentRow.DataBoundItem;
          
            if (MessageBox.Show("Seguro que desea eiminar el cliente seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clienteService.EliminarCliente(selected);

                if (chkTodos.Checked)
                {
                    this.CargarGrilla();
                }
                MessageBox.Show("Cliente eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                        
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            Cliente selected = (Cliente) this.dataGridClientes.CurrentRow.DataBoundItem;
            frmABMClientes frABMCl = new frmABMClientes();
            frABMCl.SeleccionarCliente(frmABMClientes.FormMode.details, selected);
            frABMCl.FormClosing += frmABMClientes_FormClosing;
            frABMCl.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarGrilla()
        {
            IList<Cliente> listaClientes = clienteService.ConsultarClientes("");
            if (listaClientes.Count() >= 1)
                this.dataGridClientes.DataSource = listaClientes;
            else MessageBox.Show("No se encontraron clientes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = (Cliente) this.dataGridClientes.CurrentRow.DataBoundItem;
            frmCrearOrden fCO = this.Owner as frmCrearOrden;
            fCO.SeleccionarCliente(clienteSeleccionado);
            this.Close();
        }

        private void DataGridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnSeleccionar.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnDetalle.Enabled = true;
        }


        private void frmABMClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void TxtDNI_KeyPress(object sender, KeyPressEventArgs e)
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
