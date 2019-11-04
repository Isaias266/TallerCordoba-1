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
    public partial class frmRptOTxM : Form
    {
       
        public frmRptOTxM()
        {
            InitializeComponent();
        }

        private void frmRptOTxM_Load(object sender, EventArgs e)
        {
        
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.dataTableOTsTableAdapter1.Fill(dsRptOT1.dataTableOTs, this.dtpDesde.Value.ToString() , this.dtpHasta.Value.ToString());
            this.reportViewer1.RefreshReport();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataTableOTsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
