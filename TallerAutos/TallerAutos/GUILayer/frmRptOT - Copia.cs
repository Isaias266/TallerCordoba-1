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
    
    public frmRptOT()
        {
            InitializeComponent();
        }

        private void frmRptOT_Load(object sender, EventArgs e)
        {
        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
              {
                this.oTxMesTableAdapter1.Fill(dsOTxMes1.OTxMes, this.dtpDesde.Value.ToString(), this.dtpHasta.Value.ToString());
              }
              this.reportViewer1.RefreshReport();
        }
    }
}
