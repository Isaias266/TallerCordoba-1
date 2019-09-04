using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerAutos.Clases;

namespace TallerAutos.Formularios
{
    public partial class frmLogin : Form
    {
        Empleado empleadoLogin = new Empleado();

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


            empleadoLogin.Usuario = this.txtUser.Text;
            empleadoLogin.Password = this.txtPass.Text;

            int idUser = empleadoLogin.validarUsuario(empleadoLogin.Usuario, empleadoLogin.Password);
            if (idUser != 0)
            {
                //empleadoLogin.obtenerDatos();
                //frmEmpleados fE = new frmEmpleados();
                //fE.Visible = true;
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
