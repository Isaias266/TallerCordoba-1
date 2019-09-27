using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerAutos.GUILayer;
using TallerAutos.BusinessLayer;
using TallerAutos.Entities;
namespace TallerAutos.GUILayer
{
    public partial class frmClientes : Form
    {
        ClienteService clienteService = new ClienteService();

        public frmClientes()
        {
           // ClienteService oClienteService = new ClienteService();
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


                if (nomOk || apOk || dniOk) {

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
                IList<Cliente> listaClientes = clienteService.ConsultarClientes(strCondiciones);
                if(listaClientes.Count() >= 1)
                    this.dataGridClientes.DataSource = listaClientes;
                else MessageBox.Show("No se encontraron clientes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void InitializeDataGridView()
        {

            dataGridClientes.ColumnCount = 3;
            dataGridClientes.ColumnHeadersVisible = true;

            dataGridClientes.AutoGenerateColumns = false;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dataGridClientes.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridClientes.Columns[0].Name = "DNI";
            dataGridClientes.Columns[0].DataPropertyName = "dni";

            dataGridClientes.Columns[1].Name = "Nombre";
            dataGridClientes.Columns[1].DataPropertyName = "nombre";

            dataGridClientes.Columns[2].Name = "Apellido";
            dataGridClientes.Columns[2].DataPropertyName = "apellido";

            dataGridClientes.AutoResizeColumnHeadersHeight();

            dataGridClientes.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

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
            ABMCl.ShowDialog();
        }

        private void DataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnNuevo.Enabled= false;
            this.btnEditar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnDetalle.Enabled = true;

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Cliente selected = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
           
            frmABMClientes frABMCl = new frmABMClientes();
            frABMCl.SeleccionarCliente(frmABMClientes.FormMode.update, selected);
            frABMCl.ShowDialog();            

        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            this.btnEditar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnDetalle.Enabled = false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Cliente selected = (Cliente)this.dataGridClientes.CurrentRow.DataBoundItem;
            frmABMClientes frABMCl = new frmABMClientes();
            frABMCl.SeleccionarCliente(frmABMClientes.FormMode.delete, selected);
            frABMCl.ShowDialog();
        }

        private void BtnDetalle_Click(object sender, EventArgs e)
        {
            Cliente selected = (Cliente) this.dataGridClientes.CurrentRow.DataBoundItem;
            frmABMClientes frABMCl = new frmABMClientes();
            frABMCl.SeleccionarCliente(frmABMClientes.FormMode.details, selected);
            frABMCl.ShowDialog();
        }
    }
}
