namespace TallerAutos.GUILayer
{
    partial class frmCrearOrden
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearOrden));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblVehiculo = new System.Windows.Forms.Label();
            this.lblCombustible = new System.Windows.Forms.Label();
            this.lblKilometraje = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.lblFechaAlta = new System.Windows.Forms.Label();
            this.lblFechaCierre = new System.Windows.Forms.Label();
            this.txtCodOrden = new System.Windows.Forms.TextBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.cboFormaPago = new System.Windows.Forms.ComboBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.txtKilometraje = new System.Windows.Forms.TextBox();
            this.txtCombustible = new System.Windows.Forms.TextBox();
            this.cboVehiculo = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblTrabajos = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblOT = new System.Windows.Forms.Label();
            this.txtFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.txtFechaCierre = new System.Windows.Forms.DateTimePicker();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.btnCerrar);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(710, 32);
            this.panelTop.TabIndex = 27;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelTop_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(689, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 24);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1039, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(19, 28);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 19;
            this.btnCerrar.TabStop = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblCodigo.ForeColor = System.Drawing.Color.White;
            this.lblCodigo.Location = new System.Drawing.Point(75, 91);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(92, 17);
            this.lblCodigo.TabIndex = 28;
            this.lblCodigo.Text = "Código Orden";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblCliente.ForeColor = System.Drawing.Color.White;
            this.lblCliente.Location = new System.Drawing.Point(76, 244);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(69, 17);
            this.lblCliente.TabIndex = 29;
            this.lblCliente.Text = "Cliente (*)";
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblVehiculo.ForeColor = System.Drawing.Color.White;
            this.lblVehiculo.Location = new System.Drawing.Point(397, 244);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Size = new System.Drawing.Size(79, 17);
            this.lblVehiculo.TabIndex = 30;
            this.lblVehiculo.Text = "Vehiculo (*)";
            // 
            // lblCombustible
            // 
            this.lblCombustible.AutoSize = true;
            this.lblCombustible.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblCombustible.ForeColor = System.Drawing.Color.White;
            this.lblCombustible.Location = new System.Drawing.Point(397, 288);
            this.lblCombustible.Name = "lblCombustible";
            this.lblCombustible.Size = new System.Drawing.Size(101, 17);
            this.lblCombustible.TabIndex = 31;
            this.lblCombustible.Text = "Combustible (*)";
            // 
            // lblKilometraje
            // 
            this.lblKilometraje.AutoSize = true;
            this.lblKilometraje.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblKilometraje.ForeColor = System.Drawing.Color.White;
            this.lblKilometraje.Location = new System.Drawing.Point(75, 288);
            this.lblKilometraje.Name = "lblKilometraje";
            this.lblKilometraje.Size = new System.Drawing.Size(94, 17);
            this.lblKilometraje.TabIndex = 32;
            this.lblKilometraje.Text = "Kilometraje (*)";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(75, 372);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(159, 17);
            this.lblDescripcion.TabIndex = 33;
            this.lblDescripcion.Text = "Descripcion de la falla (*)";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblEstado.Location = new System.Drawing.Point(397, 91);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(48, 17);
            this.lblEstado.TabIndex = 34;
            this.lblEstado.Text = "Estado";
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblFormaPago.Location = new System.Drawing.Point(397, 135);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(117, 17);
            this.lblFormaPago.TabIndex = 35;
            this.lblFormaPago.Text = "Forma de pago (*)";
            // 
            // lblFechaAlta
            // 
            this.lblFechaAlta.AutoSize = true;
            this.lblFechaAlta.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblFechaAlta.Location = new System.Drawing.Point(75, 135);
            this.lblFechaAlta.Name = "lblFechaAlta";
            this.lblFechaAlta.Size = new System.Drawing.Size(91, 17);
            this.lblFechaAlta.TabIndex = 36;
            this.lblFechaAlta.Text = "Fecha de alta";
            // 
            // lblFechaCierre
            // 
            this.lblFechaCierre.AutoSize = true;
            this.lblFechaCierre.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblFechaCierre.Location = new System.Drawing.Point(75, 178);
            this.lblFechaCierre.Name = "lblFechaCierre";
            this.lblFechaCierre.Size = new System.Drawing.Size(102, 17);
            this.lblFechaCierre.TabIndex = 37;
            this.lblFechaCierre.Text = "Fecha de cierre";
            // 
            // txtCodOrden
            // 
            this.txtCodOrden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.txtCodOrden.Enabled = false;
            this.txtCodOrden.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtCodOrden.ForeColor = System.Drawing.Color.Transparent;
            this.txtCodOrden.Location = new System.Drawing.Point(177, 91);
            this.txtCodOrden.Name = "txtCodOrden";
            this.txtCodOrden.Size = new System.Drawing.Size(121, 22);
            this.txtCodOrden.TabIndex = 1;
            this.txtCodOrden.TextChanged += new System.EventHandler(this.TxtCodOrden_TextChanged);
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.cboEstado.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cboEstado.ForeColor = System.Drawing.Color.Transparent;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(520, 91);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(121, 25);
            this.cboEstado.TabIndex = 2;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.CboEstado_SelectedIndexChanged);
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.cboFormaPago.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cboFormaPago.ForeColor = System.Drawing.Color.Transparent;
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(520, 132);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(121, 25);
            this.cboFormaPago.TabIndex = 4;
            this.cboFormaPago.SelectedIndexChanged += new System.EventHandler(this.CboFormaPago_SelectedIndexChanged);
            // 
            // cboCliente
            // 
            this.cboCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.cboCliente.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cboCliente.ForeColor = System.Drawing.Color.Transparent;
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(177, 241);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(121, 25);
            this.cboCliente.TabIndex = 6;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.CboCliente_SelectedIndexChanged);
            this.cboCliente.SelectionChangeCommitted += new System.EventHandler(this.CboCliente_SelectionChangeCommitted);
            // 
            // txtKilometraje
            // 
            this.txtKilometraje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.txtKilometraje.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtKilometraje.ForeColor = System.Drawing.Color.Transparent;
            this.txtKilometraje.Location = new System.Drawing.Point(177, 288);
            this.txtKilometraje.Name = "txtKilometraje";
            this.txtKilometraje.Size = new System.Drawing.Size(121, 22);
            this.txtKilometraje.TabIndex = 8;
            this.txtKilometraje.TextChanged += new System.EventHandler(this.TxtKilometraje_TextChanged);
            this.txtKilometraje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKilometraje_KeyPress);
            // 
            // txtCombustible
            // 
            this.txtCombustible.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.txtCombustible.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtCombustible.ForeColor = System.Drawing.Color.Transparent;
            this.txtCombustible.Location = new System.Drawing.Point(520, 285);
            this.txtCombustible.Name = "txtCombustible";
            this.txtCombustible.Size = new System.Drawing.Size(121, 22);
            this.txtCombustible.TabIndex = 9;
            this.txtCombustible.TextChanged += new System.EventHandler(this.TxtCombustible_TextChanged);
            this.txtCombustible.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCombustible_KeyPress);
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.cboVehiculo.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.cboVehiculo.ForeColor = System.Drawing.Color.Transparent;
            this.cboVehiculo.FormattingEnabled = true;
            this.cboVehiculo.Location = new System.Drawing.Point(520, 241);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(121, 25);
            this.cboVehiculo.TabIndex = 7;
            this.cboVehiculo.SelectedIndexChanged += new System.EventHandler(this.CboVehiculo_SelectedIndexChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.txtDescripcion.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.txtDescripcion.ForeColor = System.Drawing.Color.Transparent;
            this.txtDescripcion.Location = new System.Drawing.Point(240, 344);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(401, 73);
            this.txtDescripcion.TabIndex = 10;
            this.txtDescripcion.Text = "";
            this.txtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.panel1.Controls.Add(this.dgvDetalles);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnNuevo);
            this.panel1.Controls.Add(this.lblTrabajos);
            this.panel1.Location = new System.Drawing.Point(59, 438);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 209);
            this.panel1.TabIndex = 48;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalles.EnableHeadersVisualStyles = false;
            this.dgvDetalles.GridColor = System.Drawing.Color.White;
            this.dgvDetalles.Location = new System.Drawing.Point(19, 32);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalles.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(563, 126);
            this.dgvDetalles.TabIndex = 53;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnEliminar.Location = new System.Drawing.Point(512, 172);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(70, 23);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnEditar.Location = new System.Drawing.Point(436, 172);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(70, 23);
            this.btnEditar.TabIndex = 12;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnNuevo.Location = new System.Drawing.Point(360, 172);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(70, 23);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // lblTrabajos
            // 
            this.lblTrabajos.AutoSize = true;
            this.lblTrabajos.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblTrabajos.Location = new System.Drawing.Point(17, 12);
            this.lblTrabajos.Name = "lblTrabajos";
            this.lblTrabajos.Size = new System.Drawing.Size(57, 17);
            this.lblTrabajos.TabIndex = 0;
            this.lblTrabajos.Text = "Trabajos";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnAceptar.Location = new System.Drawing.Point(491, 662);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 23);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnCancelar.Location = new System.Drawing.Point(574, 662);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // lblOT
            // 
            this.lblOT.AutoSize = true;
            this.lblOT.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblOT.Location = new System.Drawing.Point(21, 51);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(111, 17);
            this.lblOT.TabIndex = 50;
            this.lblOT.Text = "Orden de Trabajo";
            // 
            // txtFechaAlta
            // 
            this.txtFechaAlta.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.txtFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaAlta.Location = new System.Drawing.Point(177, 132);
            this.txtFechaAlta.Name = "txtFechaAlta";
            this.txtFechaAlta.Size = new System.Drawing.Size(121, 22);
            this.txtFechaAlta.TabIndex = 3;
            this.txtFechaAlta.Value = new System.DateTime(2019, 10, 19, 0, 0, 0, 0);
            // 
            // txtFechaCierre
            // 
            this.txtFechaCierre.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.txtFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaCierre.Location = new System.Drawing.Point(177, 173);
            this.txtFechaCierre.Name = "txtFechaCierre";
            this.txtFechaCierre.Size = new System.Drawing.Size(121, 22);
            this.txtFechaCierre.TabIndex = 5;
            this.txtFechaCierre.Value = new System.DateTime(2019, 10, 19, 0, 0, 0, 0);
            // 
            // frmCrearOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(710, 700);
            this.Controls.Add(this.txtFechaCierre);
            this.Controls.Add(this.txtFechaAlta);
            this.Controls.Add(this.lblOT);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cboVehiculo);
            this.Controls.Add(this.txtCombustible);
            this.Controls.Add(this.txtKilometraje);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.txtCodOrden);
            this.Controls.Add(this.lblFechaCierre);
            this.Controls.Add(this.lblFechaAlta);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblKilometraje);
            this.Controls.Add(this.lblCombustible);
            this.Controls.Add(this.lblVehiculo);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCrearOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCrearOrden";
            this.Load += new System.EventHandler(this.FrmCrearOrden_Load);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblVehiculo;
        private System.Windows.Forms.Label lblCombustible;
        private System.Windows.Forms.Label lblKilometraje;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Label lblFechaAlta;
        private System.Windows.Forms.Label lblFechaCierre;
        private System.Windows.Forms.TextBox txtCodOrden;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.ComboBox cboFormaPago;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.TextBox txtKilometraje;
        private System.Windows.Forms.TextBox txtCombustible;
        private System.Windows.Forms.ComboBox cboVehiculo;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblTrabajos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblOT;
        private System.Windows.Forms.DateTimePicker txtFechaAlta;
        private System.Windows.Forms.DateTimePicker txtFechaCierre;
        private System.Windows.Forms.DataGridView dgvDetalles;
    }
}