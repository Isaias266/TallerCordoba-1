using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TallerAutos.BusinessLayer;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;
namespace TallerAutos.GUILayer
{
    public partial class frmABMClientes : Form
    {
        private FormMode formMode = FormMode.insert;
        
        private SexoService oSexService;
        private Cliente clienteSeleccionado;
        private ClienteService clienteService;
        public frmABMClientes()
        {   
            InitializeComponent();
            oSexService = new SexoService();
            clienteSeleccionado = new Cliente();
            clienteService = new ClienteService();
        }

        public enum FormMode
        {
            insert,
            update,
            delete,
            details
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmABMClientes_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboSexo, oSexService.recuperarSexos(), "nombre", "codSexo");
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Cargar cliente";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Editar cliente";
                        this.MostrarDatos(clienteSeleccionado);
                        HabilitarTxt(true);
                        
                        break;
                    }

                case FormMode.delete:
                    {
                        this.Text = "Eliminar cliente";
                        this.MostrarDatos(clienteSeleccionado);
                        HabilitarTxt(false);
                        

                        break;
                    }
                case FormMode.details:
                    {
                        this.Text = "Detalle de cliente";
                        this.MostrarDatos(clienteSeleccionado);
                        HabilitarTxt(false);
                        break;
                    }

            }

        }

        public void SeleccionarCliente(FormMode modo, Cliente clienteSel)
        {
            formMode = modo;
            clienteSeleccionado = clienteSel; 
        }

        private void LlenarCombo(ComboBox combo, Object fuente, string display, String value)
        {
            combo.DataSource = fuente;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.SelectedIndex = -1;
        }

        private void MostrarDatos(Cliente C)
        {
            this.txtDNI.Text = C.Dni.ToString();
            this.txtNom.Text = C.Nombre;
            this.txtApellido.Text = C.Apellido;
            this.txtDomicilio.Text = C.Domicilio;
            this.txtEmail.Text = C.Email;
            this.txtTel.Text = C.Telefono;
            this.txtCel.Text = C.Celular;
            this.cboSexo.SelectedValue = C.Sexo.CodSexo;
            this.dtpFechaNac.Value = C.FechaNacimiento;
        }

        private void HabilitarTxt(bool hab)
        {
            if (!hab)
            {
                this.txtDNI.Enabled = false;
                this.txtNom.Enabled = false;
                this.txtApellido.Enabled = false;
                this.txtDomicilio.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtTel.Enabled = false;
                this.txtCel.Enabled = false;
                this.cboSexo.Enabled = false;
                this.dtpFechaNac.Enabled = false;
            }

            else
            {
                this.txtDNI.Enabled = true;
                this.txtNom.Enabled = true;
                this.txtApellido.Enabled = true;
                this.txtDomicilio.Enabled = true;
                this.txtEmail.Enabled = true;
                this.txtTel.Enabled = true;
                this.txtCel.Enabled = true;
                this.cboSexo.Enabled = true;
                this.dtpFechaNac.Enabled = true;
            }
        }

        private bool ValidarCamposObl()
        {
            if (String.IsNullOrEmpty(this.txtDNI.Text) || String.IsNullOrEmpty(this.txtNom.Text) || String.IsNullOrEmpty(this.txtApellido.Text) || cboSexo.SelectedIndex == -1)
            {            
                return false;
            }
            return true;
        }

        private bool ValidarDNICliente()
        { string strSql = "AND C.dni = " + this.txtDNI.Text;
            if (clienteService.ConsultarClientes(strSql).Count > 0)
            {
                return false;
            }

            return true;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ValidarCamposObl())
                        {
                            if (ValidarDNICliente())
                            {   
                                Cliente oCliente = new Cliente();
                                LlenarDatosCliente(oCliente);

                                clienteService.CargarCliente(oCliente);
                                
                                MessageBox.Show("Usuario cargado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                                            }
                            else
                                MessageBox.Show("Ya existe un cliente con el número de DNI ingresado. Por favor, ingrese un DNI diferente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("No se han completado uno o más campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;
                    }
                    
                case FormMode.update:
                    {
                        if (ValidarCamposObl())
                        {                            
                             LlenarDatosCliente(clienteSeleccionado);                            
                                
                             clienteService.ActualizarCliente(clienteSeleccionado);

                             MessageBox.Show("Usuario actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             this.Dispose();

                        }
                        else
                            MessageBox.Show("No se han completado uno o más campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;
                    }
                    
                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea eiminar el cliente seleccionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            clienteService.EliminarCliente(clienteSeleccionado);                           
                            MessageBox.Show("Cliente eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();                           
                        }

                        break;
                    }

                case FormMode.details:

                    MostrarDatos(clienteSeleccionado);
                    this.Close();
                    break;
                    
                
            }

        }

        private void LlenarDatosCliente(Cliente C)
        {
            C.Sexo = new Sexo();
            C.Dni = Convert.ToInt32(this.txtDNI.Text);
            C.Apellido = this.txtApellido.Text;
            C.Nombre = this.txtNom.Text;
            C.Domicilio = this.txtDomicilio.Text;
            C.Email = this.txtEmail.Text;
            C.Telefono = this.txtTel.Text;
            C.Celular = this.txtCel.Text;
            C.Sexo.CodSexo = Convert.ToInt32(this.cboSexo.SelectedValue);
            C.FechaNacimiento = this.dtpFechaNac.Value;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
