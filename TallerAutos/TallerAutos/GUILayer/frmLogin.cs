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
            lblLogin.Focus();
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

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void TxtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
            }
        }

        

        private void TxtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.PasswordChar = '\0';
                txtPass.Text = "Password";
            }
        }

        private void TxtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = "";
                txtPass.PasswordChar = '*';
            }
        }

        private void TxtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
            }
        }
    }
}
