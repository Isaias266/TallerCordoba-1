using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                   
                    this.dataGridClientes.DataSource = clienteService.ConsultarClientes(strCondiciones);
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
                else MessageBox.Show("No se encontró ningún cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
