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

namespace TallerAutos
{
    public partial class frmEmpleados : Form
    {

        private bool nuevo_editar;
        Rol rol = new Rol();
        Sexo sexo = new Sexo();
        public frmEmpleados()
        {
            InitializeComponent();

        }

        private void limpiar()
        {
            txtLegajo.Text = "";
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            cboSexo.SelectedIndex = -1;
            cboRol.SelectedIndex = -1;
            txtDomicilio.Clear();
            txtCelular.Clear();
            dateAlta.Value = DateTime.Now;
            dateNac.Value = DateTime.Now;
            txtUsuario.Text = "";
            txtPassword.Text = "";
        }

        private void habilitar(bool x)
        {
            btnGuardar.Enabled = x;
            btnCancelar.Enabled = x;

            cboRol.Enabled = x;
            txtNombre.Enabled = x;
            txtApellido.Enabled = x;
            txtDomicilio.Enabled = x;
            txtTelefono.Enabled = x;
            txtCelular.Enabled = x;
            dateAlta.Enabled = x;
            dateNac.Enabled = x;
            cboSexo.Enabled = x;
            btnNuevo.Enabled = !x;
            btnEliminar.Enabled = !x;
            btnEditar.Enabled = !x;
            btnSalir.Enabled = !x;
            txtUsuario.Enabled = x;
            txtPassword.Enabled = x;
        }
        


        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            this.habilitar(false);
            this.cargarGrilla();
            txtLegajo.Enabled = false;
            cboRol.DataSource = rol.recuperarRoles();
            cboRol.DisplayMember = "nombre";
            cboRol.ValueMember = "codRol";
            cboSexo.DataSource = sexo.recuperarSexos();
            cboSexo.DisplayMember = "nombre";
            cboSexo.ValueMember = "codSexo";
            cboRol.SelectedIndex = -1;
            cboSexo.SelectedIndex = -1;
        }

        private void cargarGrilla()
        {
            DataTable tabla_empleados;
            Empleado users_empleados = new Empleado();
            tabla_empleados = users_empleados.obtenerEmpleados();
            this.dataGridEmpleados.DataSource = tabla_empleados;
            this.dataGridEmpleados.ReadOnly = true;
            this.dataGridEmpleados.MultiSelect = false;
            this.dataGridEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEmpleados.AllowUserToAddRows = false;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.limpiar();
            this.habilitar(true);
            this.txtNombre.Focus();
            nuevo_editar = true;
            dataGridEmpleados.Enabled = false;
        }

        private void DataGridEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLegajo.Text = dataGridEmpleados.Rows[e.RowIndex].Cells["legajo"].Value.ToString();
            txtNombre.Text = dataGridEmpleados.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
            txtApellido.Text = dataGridEmpleados.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
            txtDomicilio.Text = dataGridEmpleados.Rows[e.RowIndex].Cells["domicilio"].Value.ToString();
            txtTelefono.Text = dataGridEmpleados.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
            txtCelular.Text = dataGridEmpleados.Rows[e.RowIndex].Cells["celular"].Value.ToString();
            dateNac.Text = dataGridEmpleados.Rows[e.RowIndex].Cells["fechaNacim"].Value.ToString();
            dateAlta.Text = dataGridEmpleados.Rows[e.RowIndex].Cells["fechaAlta"].Value.ToString();
            cboRol.SelectedValue = dataGridEmpleados.Rows[e.RowIndex].Cells["rol"].Value.ToString();
            cboSexo.SelectedValue = dataGridEmpleados.Rows[e.RowIndex].Cells["codSexo"].Value.ToString();
            txtUsuario.Text = dataGridEmpleados.Rows[e.RowIndex].Cells["usuario"].Value.ToString();
            txtPassword.Text = dataGridEmpleados.Rows[e.RowIndex].Cells["password"].Value.ToString();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            dataGridEmpleados.Enabled = true;

            if (validarDatos())
            {
                if (nuevo_editar)
                {
                    Empleado empleado = new Empleado();
                    //empleado.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                    empleado.Rol = Convert.ToInt32(this.cboRol.SelectedValue);
                    empleado.Nombre = this.txtNombre.Text;
                    empleado.Apellido = this.txtApellido.Text;
                    empleado.Domicilio = this.txtDomicilio.Text;
                    empleado.Telefono = this.txtTelefono.Text;
                    empleado.Celular = this.txtCelular.Text;
                    empleado.FechaNacim = this.dateNac.Value;
                    empleado.FechaAlta = this.dateAlta.Value;
                    empleado.Sexo = Convert.ToInt32(this.cboSexo.SelectedValue);
                    empleado.Usuario = this.txtUsuario.Text;
                    empleado.Password = this.txtPassword.Text;
                    empleado.cargarEmpleado();
                    this.habilitar(false);
                    this.limpiar();
                    lblError.ForeColor = Color.FromArgb(33, 151, 10);
                    lblError.Text = "Nuevo empleado creado con exito";
                    timerError.Enabled = true;
                    this.cargarGrilla();
                }
                else
                {
                    Empleado empleado_edit = new Empleado();
                    empleado_edit.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                    empleado_edit.Rol = Convert.ToInt32(this.cboRol.SelectedValue);
                    empleado_edit.Nombre = this.txtNombre.Text;
                    empleado_edit.Apellido = this.txtApellido.Text;
                    empleado_edit.Domicilio = this.txtDomicilio.Text;
                    empleado_edit.Telefono = this.txtTelefono.Text;
                    empleado_edit.Celular = this.txtCelular.Text;
                    empleado_edit.FechaNacim = this.dateNac.Value;
                    empleado_edit.FechaAlta = this.dateAlta.Value;
                    empleado_edit.Sexo = Convert.ToInt32(this.cboSexo.SelectedValue);
                    empleado_edit.Usuario = this.txtUsuario.Text;
                    empleado_edit.Password = this.txtPassword.Text;
                    empleado_edit.actualizarEmpleado();
                    this.habilitar(false);
                    this.limpiar();
                    lblError.ForeColor = Color.FromArgb(33, 151, 10);
                    lblError.Text = "Empleado " + empleado_edit.Legajo + " actualizado con exito";
                    timerError.Enabled = true;
                    this.cargarGrilla();
                }
            }

            else
            {
                lblError.Text = "Error: Datos incorrectos o incompletos";
                lblError.ForeColor = Color.DarkRed;
                timerError.Enabled = true;
            }
            

        }

        private bool validarDatos()
        {
            if (cboRol.SelectedIndex == -1 || txtNombre.Text.Length == 0 || txtApellido.Text.Length == 0 || txtDomicilio.Text.Length == 0 || cboSexo.SelectedIndex == -1)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        private void TimerError_Tick(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.habilitar(false);
            this.limpiar();
            this.dataGridEmpleados.Enabled = true;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if(this.txtLegajo.Text.Length > 0) {
                this.txtLegajo.Enabled = false;
                this.txtNombre.Focus();
                nuevo_editar = false;
                this.habilitar(true);
            }
            else
            {
                lblError.ForeColor = Color.DarkRed;
                lblError.Text = "Error: Primero debe seleccionar un usuario.";
                timerError.Enabled = true;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.txtLegajo.Text.Length == 0)
            {
                lblError.ForeColor = Color.DarkRed;
                lblError.Text = "Error: Seleccione al menos una fila.";
                timerError.Enabled = true;
            }
            else
            {
                Empleado empleado_eliminar = new Empleado();
                empleado_eliminar.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                empleado_eliminar.eliminarEmpleado();
                lblError.ForeColor = Color.DarkRed;
                lblError.Text = "Usuario " + empleado_eliminar.Legajo + " eliminado con exito";
                timerError.Enabled = true;
                this.limpiar();
                this.cargarGrilla();
            }
        }

        private void TxtLegajo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDomicilio_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCelular_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
