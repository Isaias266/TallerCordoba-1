using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerAutos.GUILayer
{
    public partial class frmRptOTxEmp : Form
    {
        List<String> meses = new List<String>();
        List<int> años = new List<int>();

        public void cargarMeses()
        {
            meses.Add("Enero");
            meses.Add("Febrero");
            meses.Add("Marzo");
            meses.Add("Abril");
            meses.Add("Mayo");
            meses.Add("Junio");
            meses.Add("Julio");
            meses.Add("Agosto");
            meses.Add("Septiembre");
            meses.Add("Octubre");
            meses.Add("Noviembre");
            meses.Add("Diciembre");

            this.cboMes.DataSource = this.meses;
            this.cboMes.SelectedIndex = 9;
        }

        public void cargarAños()
        {

            for (int i = 1900; i < 2020; i++)
            {
                años.Add(i);
            }
            this.cboAño.DataSource = this.años;
            this.cboAño.SelectedIndex = 119;
        }
        public frmRptOTxEmp()
        {
            InitializeComponent();
        }

        private void frmRptOTxEmp_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsRptOT.EmpleadosxOrden' Puede moverla o quitarla según sea necesario.
            dsRptOT.EnforceConstraints = false;
            this.cargarAños();
            this.cargarMeses();

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.empleadosxOrdenTableAdapter.Fill(this.dsRptOT.EmpleadosxOrden, (int)this.cboAño.SelectedValue, this.cboMes.SelectedIndex + 1);
            this.reportViewer1.RefreshReport();
 
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            //this.empleadosxOrdenTableAdapter.Fill(this.dsRptOT.EmpleadosxOrden, (int)this.cboAño.SelectedValue, this.cboMes.SelectedIndex + 1);
           // this.reportViewer1.RefreshReport();
        }
    }
}
