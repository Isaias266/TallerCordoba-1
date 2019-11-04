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
            btnReporteOTS.Visible = false;
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
            this.Hide();
            frmEmpleados frE = new frmEmpleados();
            //Adjunto el evento del frE al evento que creo en este FORM
            frE.FormClosing += frmEmpleados_FormClosing;

            frE.Show();
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
            this.btnReporteOTM.Visible = true;
            this.btnReporteOTS.Visible = true;
            this.btnReportesRM.Visible = true;
            this.btnReporteTE.Visible = true;           
        }

        private void AbrirSubMenu()
        {
            panelSubMenu.Visible = true;
            btnConsultaOt.Visible = false;
            btnCrearOt.Visible = false;
            this.btnReporteOTM.Visible = false;
            this.btnReporteOTS.Visible = false;
            this.btnReportesRM.Visible = false;
            this.btnReporteTE.Visible = false;
            this.btnListadoClientes.Visible = false;
            this.btnListadoEmpleados.Visible = false;
            this.btnListadoRepuestos.Visible = false;
            this.btnListadoVehiculos.Visible = false;
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
            btnReporteOTS.Visible = false;
            this.btnReporteOTM.Visible = false;
            this.btnReporteOTS.Visible = false;
            this.btnReportesRM.Visible = false;
            this.btnReporteTE.Visible = false;
            this.btnListadoClientes.Visible = false;
            this.btnListadoEmpleados.Visible = false;
            this.btnListadoRepuestos.Visible = false;
            this.btnListadoVehiculos.Visible = false;
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
            frmConsultaOrden nuevaConsulta = new frmConsultaOrden(empleadoSesion);
            nuevaConsulta.Visible = true;
            this.Hide();
            nuevaConsulta.FormClosing += frmConsultarOT_FormClosing;
        }

        //Evento de cierre del formulario de empleados, vuelve a mostrar el menú principal
        private void frmEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void frmConsultarOT_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void BtnMenuClientes_Click(object sender, EventArgs e)
        {
            frmClientes frmC = new frmClientes(false);
            frmC.FormClosing += frmClientes_FormClosing;
            frmC.Show();
            this.Hide();
        }

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void frmCrearOT_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void frmRepuestos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void frmReportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void BtnRepuestos_Click(object sender, EventArgs e)
        {
            frmConsultaRepuestos frR = new frmConsultaRepuestos(true);
            frR.FormClosing += frmRepuestos_FormClosing;
            frR.Show();
            this.Hide();
        }

        private void BtnCrearOt_Click(object sender, EventArgs e)
        {
            frmCrearOrden cO = new frmCrearOrden(empleadoSesion);
            cO.FormClosing += this.frmCrearOT_FormClosing;
            cO.Show();
            this.Hide();
            
        }

        private void BtnListados_Click(object sender, EventArgs e)
        {
            AbrirSubMenu();
            this.btnListadoClientes.Visible = true;
            this.btnListadoEmpleados.Visible = true;
            this.btnListadoRepuestos.Visible = true;
            this.btnListadoVehiculos.Visible = true;
        }

        private void BtnReporteOTS_Click(object sender, EventArgs e)
        {
            frmRptOT RPTOT = new frmRptOT();
            RPTOT.FormClosing += frmReportes_FormClosing;
            RPTOT.Show();
            this.Hide();
        }

        private void BtnReporteTE_Click(object sender, EventArgs e)
        {
            frmRptOTxEmp RptOTE = new frmRptOTxEmp();
            RptOTE.FormClosing += frmReportes_FormClosing;
            RptOTE.Show();
            this.Hide();
        }

        private void BtnReportesRM_Click(object sender, EventArgs e)
        {
            frmRptRepuestosxMes RptRM = new frmRptRepuestosxMes();
            RptRM.FormClosing += frmReportes_FormClosing;
            RptRM.Show();
            this.Hide();
        }

        private void BtnReporteOTM_Click(object sender, EventArgs e)
        {
            frmRptOTxM RptOTM = new frmRptOTxM();
            RptOTM.FormClosing += frmReportes_FormClosing;
            RptOTM.Show();
            this.Hide();
        }
        private void BtnListadoClientes_Click(object sender, EventArgs e)
        {
            frmLstClientes LstC = new frmLstClientes();
            LstC.FormClosing += frmReportes_FormClosing;
            LstC.Show();
            this.Hide();
        }

        private void BtnListadoRepuestos_Click(object sender, EventArgs e)
        {
            frmLstRepuestos LstR = new frmLstRepuestos();
            LstR.FormClosing += frmReportes_FormClosing;
            LstR.Show();
            this.Hide();
        }

        private void BtnListadoEmpleados_Click(object sender, EventArgs e)
        {
            frmLstEmpleados LstE = new frmLstEmpleados();
            LstE.FormClosing += frmReportes_FormClosing;
            LstE.Show();
            this.Hide();
        }

        private void BtnListadoVehiculos_Click(object sender, EventArgs e)
        {
            frmLstVehiculos LstV = new frmLstVehiculos();
            LstV.FormClosing += frmReportes_FormClosing;
            LstV.Show();
            this.Hide();
        }
    }
}
