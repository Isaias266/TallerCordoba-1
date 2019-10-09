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
        public frmDetallesOT()
        {
            InitializeComponent();
            InitializeDataGridView();
            empleadoS = new EmpleadoService();
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
            this.dgvTrabajos.DataSource = null;
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
        }

        private void FrmDetallesOT_Load(object sender, EventArgs e)
        {
            LlenarCombo(this.cboEmpleado, empleadoS.ConsultarEmpleados("AND 1=1"), "nombre", "legajo");
            switch (formMode)
            {
                //Modo crear Orden de Trabajo
                case FormMode.insert:
                    {
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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

        }
    }   
}
