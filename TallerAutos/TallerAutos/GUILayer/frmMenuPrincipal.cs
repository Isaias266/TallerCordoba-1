using System;
using System.Windows.Forms;
using TallerAutos.Entities;
using System.Drawing;

namespace TallerAutos.GUILayer
{
    public partial class frmMenuPrincipal : Form
    {
        private Empleado empleadoSesion;
        public frmMenuPrincipal(object empleado)
        {
            InitializeComponent();
            empleadoSesion = (Empleado)empleado;
            if (empleadoSesion.Sexo.Nombre == "Femenino")
            {
                picBoy.Visible = false;
                picGirl.Visible = true;
            }
            else
            {
                picGirl.Visible = false;
                picBoy.Visible = true;
            }
            lblNomApe.Text = empleadoSesion.Nombre + " " + empleadoSesion.Apellido;
            lblNomApe.TextAlign = ContentAlignment.MiddleCenter;
            lblLegajo.Text = "Legajo: " + empleadoSesion.Legajo;
            lblUser.Text = "Usuario: " + empleadoSesion.Usuario;
            lblRol.Text = "Rol: " + empleadoSesion.Rol.Nombre;
            panelSubMenu.Visible = false;
            btnReporte2.Visible = false;
            btnReporte1.Visible = false;
            btnCrearOt.Visible = false;
            btnConsultaOt.Visible = false;

        }

        

        private void BtnMenuOrdenes_Click(object sender, EventArgs e)
        {
            
            AbrirSubMenu();
            btnConsultaOt.Visible = true;
            btnCrearOt.Visible = true;
            
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmEmpleados frE = new frmEmpleados();
            //Adjunto el evento del frE al evento que creo en este FORM
            frE.FormClosing += frmEmpleados_FormClosing;

            frE.Visible = true;
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        

        
        private void BtnMenuOrdenes_MouseHover(object sender, EventArgs e)
        {
            //Va con delay y se llega a ver el color anterior
            //pictureOrden.BackColor = ColorTranslator.FromHtml("#383D3E");
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            AbrirSubMenu();
            btnReporte2.Visible = true;
            btnReporte1.Visible = true;
        }

        private void AbrirSubMenu()
        {
            panelSubMenu.Visible = true;
            btnConsultaOt.Visible = false;
            btnCrearOt.Visible = false;
            btnReporte1.Visible = false;
            btnReporte2.Visible = false;
            picBoy.Location = new Point(537, 153);
            picGirl.Location = new Point(537, 153);
            lblNomApe.Location = new Point(533, 301);
            lblLegajo.Location = new Point(512, 342);
            picSeparador1.Location = new Point(501, 366);
            picSeparador2.Location = new Point(501, 424);
            picSeparador3.Location = new Point(501, 489);
            lblRol.Location = new Point(512, 465);
            lblUser.Location = new Point(512, 400);
            timerSubMenu.Start();
        }

        private void CerrarSubMenu()
        {
            panelSubMenu.Visible = false;
            btnConsultaOt.Visible = false;
            btnCrearOt.Visible = false;
            btnReporte1.Visible = false;
            btnReporte2.Visible = false;
            picBoy.Location = new Point(537, 53);
            picGirl.Location = new Point(537, 53);
            lblNomApe.Location = new Point(533, 201);
            lblLegajo.Location = new Point(512, 242);
            picSeparador1.Location = new Point(501, 266);
            picSeparador2.Location = new Point(501, 324);
            picSeparador3.Location = new Point(501, 389);
            lblRol.Location = new Point(512, 365);
            lblUser.Location = new Point(512, 300);
        }

        private void TimerSubMenu_Tick(object sender, EventArgs e)
        {
            CerrarSubMenu();
        }

        private void BtnConsultaOt_Click(object sender, EventArgs e)
        {           
            frmConsultaOrden nuevaConsulta = new frmConsultaOrden();
            nuevaConsulta.Visible = true; 
        }

        //Evento de cierre del formulario de empleados, vuelve a mostrar el menú principal
        private void frmEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void BtnMenuClientes_Click(object sender, EventArgs e)
        {
            frmClientes frC = new frmClientes();
            frC.FormClosing += frmClientes_FormClosing;
            frC.Show();
            this.Hide();
        }

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void BtnCrearOt_Click(object sender, EventArgs e)
        {
            frmCrearOrden cO = new frmCrearOrden(empleadoSesion);
            cO.ShowDialog();
        }

        private void PanelTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
