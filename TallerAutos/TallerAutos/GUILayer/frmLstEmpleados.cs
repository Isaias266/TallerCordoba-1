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
    public partial class frmLstEmpleados : Form
    {
        public frmLstEmpleados()
        {
            InitializeComponent();
        }

        private void frmLstEmpleados_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsRptOT.Empleados' Puede moverla o quitarla según sea necesario.
            this.empleadosTableAdapter.Fill(this.dsRptOT.Empleados);

            this.reportViewer1.RefreshReport();
        }
    }
}
