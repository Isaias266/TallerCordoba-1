using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerAutos.GUILayer.Formularios_de_Reportes
{
    public partial class frmLstClientes : Form
    {
        public frmLstClientes()
        {
            InitializeComponent();
        }

        private void frmLstClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsRptOT.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.dsRptOT.Clientes);

            this.reportViewer1.RefreshReport();
        }
    }
}
