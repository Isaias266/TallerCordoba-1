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
    public partial class frmRptOT : Form
    {
        List<String> meses = new List<String>();
        private void cargarMeses()
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
        }
    
    public frmRptOT()
        {
            InitializeComponent();
        }

        private void frmRptOT_Load(object sender, EventArgs e)
        {
            this.cargarMeses();
            this.cboMes.DataSource = this.meses;
            this.cboMes.SelectedIndex = -1;
        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            if (this.cboMes.SelectedIndex != -1)
              {
                this.dataTableOTsTableAdapter.Fill(dsRptOT.dataTableOTs, this.cboMes.SelectedIndex + 1);
              }
              this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
