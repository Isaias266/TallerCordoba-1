using System;
using System.Windows.Forms;

namespace TallerAutos.GUILayer
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMenuOrdenes_Click(object sender, EventArgs e)
        {
            frmConsultaOrden nuevaConsulta = new frmConsultaOrden();
            nuevaConsulta.Visible = true;           
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados frE = new frmEmpleados();
            frE.Visible = true;
        }
    }
}
