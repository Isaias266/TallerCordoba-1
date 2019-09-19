using System;
using System.Windows.Forms;
using TallerAutos.BusinessLayer;

namespace TallerAutos.GUILayer
{
    public partial class frmLogin : Form
    {
        private EmpleadoService empleadoService = new EmpleadoService();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                lblIncorrecto.Text = "Error: Usuario inválido";
                return;
            }
            if (txtPass.Text == "")
            {
                lblIncorrecto.Text = "Error: Contraseña inválida";
                return;
            }

            var oEmpleado = empleadoService.validarEmpleado(txtUser.Text, txtPass.Text);

            if (oEmpleado != null)
            {
                frmMenuPrincipal frmMP = new frmMenuPrincipal();
                frmMP.Visible = true;
                this.Visible = false;
            }
            else
            {
                lblIncorrecto.Text = "Error: Datos incorrectos";
                this.txtPass.Clear();
                this.txtUser.Clear();
                this.txtUser.Focus();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
