using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerAutos.BusinessLayer;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.GUILayer
{
    public partial class frmDetallesOT : Form
    {
        private Empleado empleadoSesion = new Empleado();
        //Por defecto esta en insert mode.
        private FormMode formMode = FormMode.insert;
        private EmpleadoService empleadoS;
        private List<Repuesto> listaRepuestos;
        private List<int> listaCantidades;
        //No se utilizan por el momento.
        //private MarcaService Smarca;
        //private ModeloService Smodelo;
        public frmDetallesOT()
        {
            InitializeComponent();
            InitializeDataGridView();
            empleadoS = new EmpleadoService();
            //No se utilizan por el momento
            //Smarca = new MarcaService();
            //Smodelo = new ModeloService();
        }

        public enum FormMode
        {
            insert,
            update
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarDgvTrabajos()
        {
            for(int i = 0; i < listaRepuestos.Count(); i++)
            {
                dgvTrabajos.Rows.Insert(i, listaRepuestos[i].Nombre, listaRepuestos[i].Fabricante, listaCantidades[i], listaRepuestos[i].PrecioUnitario * listaCantidades[i]);
            }
        }
        private void InitializeDataGridView()
        {

           
            dgvTrabajos.ColumnCount = 4;
            dgvTrabajos.ColumnHeadersVisible = true;

            dgvTrabajos.AutoGenerateColumns = false;

            //Cargado
            dgvTrabajos.Columns[0].Name = "Nombre";
            dgvTrabajos.Columns[0].DataPropertyName = "nombre";
            

            dgvTrabajos.Columns[1].Name = "Fabricante";
            dgvTrabajos.Columns[1].DataPropertyName = "fabricante";

            dgvTrabajos.Columns[2].Name = "Cantidad";
            dgvTrabajos.Columns[2].DataPropertyName = "cantidad";

            dgvTrabajos.Columns[3].Name = "Precio";
            dgvTrabajos.Columns[3].DataPropertyName = "precio";

            DataGridViewImageColumn columnaimg = new DataGridViewImageColumn();
            columnaimg.Name = "Eliminar";
            columnaimg.HeaderText = "Eliminar";
            columnaimg.Image = Image.FromFile(Path.Combine(Application.StartupPath, "borrar.png"));

            dgvTrabajos.Columns.Add(columnaimg);

            dgvTrabajos.AllowUserToAddRows = false;

        }

        private void FrmDetallesOT_Load(object sender, EventArgs e)
        {
            LlenarCombo(this.cboEmpleado, empleadoS.ConsultarEmpleados("AND 1=1"), "nombre", "legajo");
            this.lblError.Visible = false;
            
            switch (formMode)
            {
                //Modo crear Orden de Trabajo
                case FormMode.insert:
                    {
                        listaRepuestos = new List<Repuesto>();
                        listaCantidades = new List<int>();
                        cboEmpleado.Enabled = false;
                        cboEmpleado.SelectedValue = empleadoSesion.Legajo;
                        break;
                    }
            }
        }

        public void SeleccionarDOT(FormMode modo,  Empleado empleadoSesion)
        {
            formMode = modo;
            this.empleadoSesion = empleadoSesion;
        }

        private void LlenarCombo(ComboBox combo, Object fuente, string display, String value)
        {
            combo.DataSource = fuente;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.SelectedIndex = -1;
        }


        public void CargarRepuesto(Repuesto rep, int cantidad)
        {
            listaRepuestos.Add(rep);
            listaCantidades.Add(cantidad);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            frmConsultaRepuestos fCR = new frmConsultaRepuestos(false);
            AddOwnedForm(fCR);
            fCR.FormClosing += frmRepuestos_FormClosing;
            fCR.Show();
            this.Hide();
            
        }

        private void frmRepuestos_FormClosing(object sender, EventArgs e)
        {
            this.Show();
            CargarDgvTrabajos();
        }

        private void TxtMonto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if(txtDescripcion.Text.Length <= 90 && txtMonto.Text.Length > 0 && Convert.ToInt32(txtMonto.Text) > 0)
            {
                MessageBox.Show("El trabajo se ha añadido con exito", "Trabajo añadido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Mandar info para transacción.
                this.Close();
            }
            else
            {
                lblError.Text = "Error: Descripción muy larga o monto incorrecto.";
                lblError.Visible = true;
                timerError.Start();

            }
        }

        private void TimerError_Tick(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void DgvTrabajos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) // Si es la columna que tiene el boton eliminar.
            {
                if (dgvTrabajos.Rows.Count > 0) //Si existe al menos una fila.
                {
                    int index = dgvTrabajos.CurrentRow.Index;
                    dgvTrabajos.Rows.RemoveAt(index); //Elimino de la grilla.
                    listaRepuestos.RemoveAt(index); //Elimino de la lista de repuestos.
                    listaCantidades.RemoveAt(index); //Eliminmo de la lista de cantidades.
                }
            }
        }
    }
    
}
 