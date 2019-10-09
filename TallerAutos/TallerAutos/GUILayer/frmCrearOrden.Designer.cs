﻿namespace TallerAutos.GUILayer
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
            this.txtFechaAlta = new System.Windows.Forms.TextBox();
            this.txtFechaCierre = new System.Windows.Forms.TextBox();
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
            this.pictureBox1.Location = new System.Drawing.Point(689, 4);
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
            this.lblCodigo.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.White;
            this.lblCodigo.Location = new System.Drawing.Point(75, 91);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(83, 16);
            this.lblCodigo.TabIndex = 28;
            this.lblCodigo.Text = "Código Orden";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.White;
            this.lblCliente.Location = new System.Drawing.Point(75, 244);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(66, 16);
            this.lblCliente.TabIndex = 29;
            this.lblCliente.Text = "Cliente (*)";
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehiculo.ForeColor = System.Drawing.Color.White;
            this.lblVehiculo.Location = new System.Drawing.Point(411, 244);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Size = new System.Drawing.Size(74, 16);
            this.lblVehiculo.TabIndex = 30;
            this.lblVehiculo.Text = "Vehiculo (*)";
            // 
            // lblCombustible
            // 
            this.lblCombustible.AutoSize = true;
            this.lblCombustible.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombustible.ForeColor = System.Drawing.Color.White;
            this.lblCombustible.Location = new System.Drawing.Point(411, 288);
            this.lblCombustible.Name = "lblCombustible";
            this.lblCombustible.Size = new System.Drawing.Size(97, 16);
            this.lblCombustible.TabIndex = 31;
            this.lblCombustible.Text = "Combustible (*)";
            // 
            // lblKilometraje
            // 
            this.lblKilometraje.AutoSize = true;
            this.lblKilometraje.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKilometraje.ForeColor = System.Drawing.Color.White;
            this.lblKilometraje.Location = new System.Drawing.Point(75, 288);
            this.lblKilometraje.Name = "lblKilometraje";
            this.lblKilometraje.Size = new System.Drawing.Size(92, 16);
            this.lblKilometraje.TabIndex = 32;
            this.lblKilometraje.Text = "Kilometraje (*)";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Century", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.White;
            this.lblDescripcion.Location = new System.Drawing.Point(75, 372);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(148, 16);
            this.lblDescripcion.TabIndex = 33;
            this.lblDescripcion.Text = "Descripcion de la falla (*)";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(411, 91);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(47, 16);
            this.lblEstado.TabIndex = 34;
            this.lblEstado.Text = "Estado";
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Location = new System.Drawing.Point(411, 135);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(90, 16);
            this.lblFormaPago.TabIndex = 35;
            this.lblFormaPago.Text = "Forma de pago";
            // 
            // lblFechaAlta
            // 
            this.lblFechaAlta.AutoSize = true;
            this.lblFechaAlta.Location = new System.Drawing.Point(75, 135);
            this.lblFechaAlta.Name = "lblFechaAlta";
            this.lblFechaAlta.Size = new System.Drawing.Size(83, 16);
            this.lblFechaAlta.TabIndex = 36;
            this.lblFechaAlta.Text = "Fecha de alta";
            // 
            // lblFechaCierre
            // 
            this.lblFechaCierre.AutoSize = true;
            this.lblFechaCierre.Location = new System.Drawing.Point(75, 178);
            this.lblFechaCierre.Name = "lblFechaCierre";
            this.lblFechaCierre.Size = new System.Drawing.Size(91, 16);
            this.lblFechaCierre.TabIndex = 37;
            this.lblFechaCierre.Text = "Fecha de cierre";
            // 
            // txtCodOrden
            // 
            this.txtCodOrden.Location = new System.Drawing.Point(177, 91);
            this.txtCodOrden.Name = "txtCodOrden";
            this.txtCodOrden.Size = new System.Drawing.Size(121, 22);
            this.txtCodOrden.TabIndex = 38;
            // 
            // txtFechaAlta
            // 
            this.txtFechaAlta.Location = new System.Drawing.Point(177, 135);
            this.txtFechaAlta.Name = "txtFechaAlta";
            this.txtFechaAlta.Size = new System.Drawing.Size(121, 22);
            this.txtFechaAlta.TabIndex = 39;
            // 
            // txtFechaCierre
            // 
            this.txtFechaCierre.Location = new System.Drawing.Point(177, 178);
            this.txtFechaCierre.Name = "txtFechaCierre";
            this.txtFechaCierre.Size = new System.Drawing.Size(121, 22);
            this.txtFechaCierre.TabIndex = 40;
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(520, 91);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(121, 24);
            this.cboEstado.TabIndex = 41;
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.FormattingEnabled = true;
            this.cboFormaPago.Location = new System.Drawing.Point(520, 132);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Size = new System.Drawing.Size(121, 24);
            this.cboFormaPago.TabIndex = 42;
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(177, 244);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(121, 24);
            this.cboCliente.TabIndex = 43;
            this.cboCliente.SelectionChangeCommitted += new System.EventHandler(this.CboCliente_SelectionChangeCommitted);
            // 
            // txtKilometraje
            // 
            this.txtKilometraje.Location = new System.Drawing.Point(177, 288);
            this.txtKilometraje.Name = "txtKilometraje";
            this.txtKilometraje.Size = new System.Drawing.Size(121, 22);
            this.txtKilometraje.TabIndex = 44;
            // 
            // txtCombustible
            // 
            this.txtCombustible.Location = new System.Drawing.Point(520, 288);
            this.txtCombustible.Name = "txtCombustible";
            this.txtCombustible.Size = new System.Drawing.Size(121, 22);
            this.txtCombustible.TabIndex = 45;
            // 
            // cboVehiculo
            // 
            this.cboVehiculo.FormattingEnabled = true;
            this.cboVehiculo.Location = new System.Drawing.Point(520, 241);
            this.cboVehiculo.Name = "cboVehiculo";
            this.cboVehiculo.Size = new System.Drawing.Size(121, 24);
            this.cboVehiculo.TabIndex = 46;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(222, 344);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(419, 73);
            this.txtDescripcion.TabIndex = 47;
            this.txtDescripcion.Text = "";
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
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalles.EnableHeadersVisualStyles = false;
            this.dgvDetalles.GridColor = System.Drawing.Color.White;
            this.dgvDetalles.Location = new System.Drawing.Point(86, 35);
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
            this.dgvDetalles.Size = new System.Drawing.Size(451, 120);
            this.dgvDetalles.TabIndex = 27;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(467, 174);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(70, 23);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Location = new System.Drawing.Point(391, 174);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(70, 23);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Location = new System.Drawing.Point(315, 174);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(70, 23);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // lblTrabajos
            // 
            this.lblTrabajos.AutoSize = true;
            this.lblTrabajos.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrabajos.Location = new System.Drawing.Point(17, 12);
            this.lblTrabajos.Name = "lblTrabajos";
            this.lblTrabajos.Size = new System.Drawing.Size(68, 18);
            this.lblTrabajos.TabIndex = 0;
            this.lblTrabajos.Text = "Trabajos";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Location = new System.Drawing.Point(498, 662);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(70, 23);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(154)))), ((int)(((byte)(187)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(585, 662);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(70, 23);
            this.btnCancelar.TabIndex = 49;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // lblOT
            // 
            this.lblOT.AutoSize = true;
            this.lblOT.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOT.Location = new System.Drawing.Point(21, 51);
            this.lblOT.Name = "lblOT";
            this.lblOT.Size = new System.Drawing.Size(167, 23);
            this.lblOT.TabIndex = 50;
            this.lblOT.Text = "Orden de Trabajo";
            // 
            // frmCrearOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(61)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(710, 692);
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
            this.Controls.Add(this.txtFechaCierre);
            this.Controls.Add(this.txtFechaAlta);
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
            this.ForeColor = System.Drawing.Color.White;
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
        private System.Windows.Forms.TextBox txtFechaAlta;
        private System.Windows.Forms.TextBox txtFechaCierre;
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
        private System.Windows.Forms.DataGridView dgvDetalles;
    }
}