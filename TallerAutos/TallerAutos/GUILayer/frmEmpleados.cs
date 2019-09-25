using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TallerAutos.BusinessLayer;
using TallerAutos.DataAccessLayer;
using TallerAutos.Entities;

namespace TallerAutos.GUILayer
{
    public partial class frmEmpleados : Form
    {

        private bool nuevo_editar;
        private EmpleadoService empleado;
        private RolService rol;
        private SexoService sexo;

        public frmEmpleados()
        {
            InitializeComponent();
            InitializeDataGridView();
            empleado = new EmpleadoService();
            rol = new RolService();
            sexo = new SexoService();
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
            // TODO: esta línea de código carga datos en la tabla 'taller_PAVDataSet4.Empleados' Puede moverla o quitarla según sea necesario.
            //this.empleadosTableAdapter.Fill(this.taller_PAVDataSet4.Empleados);
            // TODO: esta línea de código carga datos en la tabla 'taller_PAVDataSet3.Roles' Puede moverla o quitarla según sea necesario.
            //this.rolesTableAdapter.Fill(this.taller_PAVDataSet3.Roles);
            // TODO: esta línea de código carga datos en la tabla 'taller_PAVDataSet2.Sexos' Puede moverla o quitarla según sea necesario.
            //this.sexosTableAdapter.Fill(this.taller_PAVDataSet2.Sexos);
            txtLegajo.Enabled = false;
            cargarCombo(cboRol, rol.recuperarRoles(), "nombre", "codRol");
            cargarCombo(cboSexo, sexo.recuperarSexos(), "nombre", "codSexo");
            this.habilitar(false);
            this.cargarGrilla();
        }

        private void cargarCombo(ComboBox cbo, Object source, string display, string value) {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void cargarGrilla()
        {
            EmpleadoService oEmpleadoService = new EmpleadoService();
            this.dataGridEmpleados.DataSource = oEmpleadoService.consultarEmpleados("");
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
            var empleado = (Empleado) dataGridEmpleados.CurrentRow.DataBoundItem;
            txtLegajo.Text = empleado.Legajo.ToString();
            txtNombre.Text = empleado.Nombre.ToString();
            txtApellido.Text = empleado.Apellido.ToString();
            if (!string.IsNullOrEmpty(empleado.Domicilio))
                txtDomicilio.Text = empleado.Domicilio.ToString();
            if (!string.IsNullOrEmpty(empleado.Telefono))
                txtTelefono.Text = empleado.Telefono.ToString();
            if (!string.IsNullOrEmpty(empleado.Celular))
                txtCelular.Text = empleado.Celular.ToString();
            if (!(empleado.FechaNacim == default(DateTime)))
                dateNac.Text = empleado.FechaNacim.ToString();
            dateAlta.Text = empleado.FechaAlta.ToString();
            cboRol.Text = empleado.Rol.Nombre.ToString();
            cboSexo.Text = empleado.Sexo.Nombre.ToString();
            txtUsuario.Text = empleado.Usuario.ToString();
            if (!nuevo_editar)
                txtPassword.Text = empleado.Password.ToString();
                        
        }
        

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            dataGridEmpleados.Enabled = true;

            if (validarDatos(this.txtUsuario.Text))
            {
                Empleado oEmpleado = new Empleado();
                oEmpleado.Rol = new Rol();
                oEmpleado.Sexo = new Sexo();
                EmpleadoService oEmpleadoService = new EmpleadoService();


                if (nuevo_editar)
                {
                    if (validarUsuario() == false)
                    {
                        //empleado.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                        oEmpleado.Rol.CodRol = Convert.ToInt32(this.cboRol.SelectedValue);
                        oEmpleado.Nombre = this.txtNombre.Text;
                        oEmpleado.Apellido = this.txtApellido.Text;
                        oEmpleado.Domicilio = this.txtDomicilio.Text;
                        oEmpleado.Telefono = this.txtTelefono.Text;
                        oEmpleado.Celular = this.txtCelular.Text;
                        oEmpleado.FechaNacim = this.dateNac.Value;
                        oEmpleado.FechaAlta = this.dateAlta.Value;
                        oEmpleado.Sexo.CodSexo = Convert.ToInt32(this.cboSexo.SelectedValue);
                        oEmpleado.Usuario = this.txtUsuario.Text;
                        oEmpleado.Password = this.txtPassword.Text;

                        oEmpleadoService.cargarEmpleado(oEmpleado);

                        this.habilitar(false);
                        this.limpiar();
                        lblError.ForeColor = Color.FromArgb(33, 151, 10);
                        lblError.Text = "Nuevo empleado creado con exito";
                        timerError.Enabled = true;
                        this.cargarGrilla();
                    }
                    else
                    {
                        lblError.Text = "Error: El nombre de usuario ya existe";
                        lblError.ForeColor = Color.DarkRed;
                        timerError.Enabled = true;
                    }
                }
                else
                {
                    oEmpleado.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                    oEmpleado.Rol.CodRol = Convert.ToInt32(this.cboRol.SelectedValue);
                    oEmpleado.Nombre = this.txtNombre.Text;
                    oEmpleado.Apellido = this.txtApellido.Text;
                    oEmpleado.Domicilio = this.txtDomicilio.Text;
                    oEmpleado.Telefono = this.txtTelefono.Text;
                    oEmpleado.Celular = this.txtCelular.Text;
                    oEmpleado.FechaNacim = this.dateNac.Value;
                    oEmpleado.FechaAlta = this.dateAlta.Value;
                    oEmpleado.Sexo.CodSexo = Convert.ToInt32(this.cboSexo.SelectedValue);
                    oEmpleado.Usuario = this.txtUsuario.Text;
                    oEmpleado.Password = this.txtPassword.Text;

                    oEmpleadoService.actualizarEmpleado(oEmpleado);

                    this.habilitar(false);
                    this.limpiar();
                    lblError.ForeColor = Color.FromArgb(33, 151, 10);
                    lblError.Text = "Empleado " + oEmpleado.Legajo + " actualizado con exito";
                    timerError.Enabled = true;
                    this.cargarGrilla();
                }
            }
            else
            {
                lblError.Text = "Error: Datos incompletos o incorrectos";
                lblError.ForeColor = Color.DarkRed;
                timerError.Enabled = true;
            }
        }

        private bool validarDatos(string user)
        {
            if (cboRol.SelectedIndex == -1 || txtNombre.Text.Length == 0 || txtApellido.Text.Length == 0
                || cboSexo.SelectedIndex == -1 || txtUsuario.Text == "" || txtPassword.Text == "") 
                return false;
            else
                return true;
        }

        //Devuelve true si existe un usuario con ese nombre, false en caso contrario
        private bool validarUsuario()
        {
            return empleado.validarUserEmpleado(txtUsuario.Text); 
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
                dataGridEmpleados.Enabled = false;
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
            //Application.Exit();
            this.Close();
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
                Empleado oEmpleado = new Empleado();
                EmpleadoService oEmpleadoService = new EmpleadoService();

                oEmpleado.Legajo = Convert.ToInt32(this.txtLegajo.Text);

                oEmpleadoService.eliminarEmpleado(oEmpleado);

                lblError.ForeColor = Color.DarkRed;
                lblError.Text = "Usuario " + oEmpleado.Legajo + " eliminado con exito";
                timerError.Enabled = true;
                this.limpiar();
                this.cargarGrilla();
            }
        }

        private void InitializeDataGridView()
        {
            // Cantidad columnas y las hago visibles.
            dataGridEmpleados.ColumnCount = 11;
            dataGridEmpleados.ColumnHeadersVisible = true;

            // Configurp la AutoGenerateColumns en false para que no se autogeneren las columnas
            dataGridEmpleados.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dataGridEmpleados.ColumnHeadersDefaultCellStyle = columnHeaderStyle;


            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            dataGridEmpleados.Columns[0].Name = "Legajo";
            dataGridEmpleados.Columns[0].DataPropertyName = "legajo";

            dataGridEmpleados.Columns[1].Name = "Nombre";
            dataGridEmpleados.Columns[1].DataPropertyName = "nombre";

            dataGridEmpleados.Columns[2].Name = "Apellido";
            dataGridEmpleados.Columns[2].DataPropertyName = "apellido";

            dataGridEmpleados.Columns[3].Name = "Rol";
            dataGridEmpleados.Columns[3].DataPropertyName = "Rol";

            dataGridEmpleados.Columns[4].Name = "Fecha Nacimiento";
            dataGridEmpleados.Columns[4].DataPropertyName = "fechaNacim";

            dataGridEmpleados.Columns[5].Name = "Domicilio";
            dataGridEmpleados.Columns[5].DataPropertyName = "domicilio";

            dataGridEmpleados.Columns[6].Name = "Teléfono";
            dataGridEmpleados.Columns[6].DataPropertyName = "telefono";

            dataGridEmpleados.Columns[7].Name = "Celular";
            dataGridEmpleados.Columns[7].DataPropertyName = "celular";

            dataGridEmpleados.Columns[8].Name = "Sexo";
            dataGridEmpleados.Columns[8].DataPropertyName = "Sexo";

            dataGridEmpleados.Columns[9].Name = "Usuario";
            dataGridEmpleados.Columns[9].DataPropertyName = "usuario";

            dataGridEmpleados.Columns[10].Name = "Fecha Alta";
            dataGridEmpleados.Columns[10].DataPropertyName = "fechaAlta";

            // Cambia el tamaño de la altura de los encabezados de columna.
            dataGridEmpleados.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            dataGridEmpleados.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            // Propiedades data grid view
            dataGridEmpleados.ReadOnly = true;
            this.dataGridEmpleados.MultiSelect = false;
            this.dataGridEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEmpleados.AllowUserToAddRows = false;
        }
    }
}
