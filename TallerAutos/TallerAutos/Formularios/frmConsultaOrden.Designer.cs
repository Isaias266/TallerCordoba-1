namespace TallerAutos.Formularios
{
    partial class frmConsultaOrden
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
            this.components = new System.ComponentModel.Container();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtIdOrden = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.codOrdenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codEstadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dniClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAltaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCierreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaAltaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaCierreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formaPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kilometrajeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadCombustibleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionFallaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taller_PAVDataSet1 = new TallerAutos.Taller_PAVDataSet1();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblPatente = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblID = new System.Windows.Forms.Label();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.lblFechDesde = new System.Windows.Forms.Label();
            this.cboEstados = new System.Windows.Forms.ComboBox();
            this.estadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taller_PAVDataSet = new TallerAutos.Taller_PAVDataSet();
            this.estadosTableAdapter = new TallerAutos.Taller_PAVDataSetTableAdapters.EstadosTableAdapter();
            this.ordenesTableAdapter = new TallerAutos.Taller_PAVDataSet1TableAdapters.OrdenesTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taller_PAVDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taller_PAVDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(669, 401);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(91, 35);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDNI);
            this.groupBox1.Controls.Add(this.txtDNI);
            this.groupBox1.Controls.Add(this.txtIdOrden);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.dgvOrdenes);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.lblPatente);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Controls.Add(this.lblFechaHasta);
            this.groupBox1.Controls.Add(this.lblFechDesde);
            this.groupBox1.Controls.Add(this.cboEstados);
            this.groupBox1.Location = new System.Drawing.Point(17, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 370);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(386, 105);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(61, 13);
            this.lblDNI.TabIndex = 18;
            this.lblDNI.Text = "DNI Cliente";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(486, 102);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(121, 20);
            this.txtDNI.TabIndex = 17;
            // 
            // txtIdOrden
            // 
            this.txtIdOrden.Location = new System.Drawing.Point(486, 71);
            this.txtIdOrden.Name = "txtIdOrden";
            this.txtIdOrden.Size = new System.Drawing.Size(121, 20);
            this.txtIdOrden.TabIndex = 16;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(165, 102);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(121, 20);
            this.txtPatente.TabIndex = 15;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(486, 139);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(91, 35);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "Consultar";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.AllowUserToAddRows = false;
            this.dgvOrdenes.AllowUserToDeleteRows = false;
            this.dgvOrdenes.AutoGenerateColumns = false;
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codOrdenDataGridViewTextBoxColumn,
            this.codEstadoDataGridViewTextBoxColumn,
            this.patenteDataGridViewTextBoxColumn,
            this.dniClienteDataGridViewTextBoxColumn,
            this.fechaAltaDataGridViewTextBoxColumn,
            this.fechaCierreDataGridViewTextBoxColumn,
            this.horaAltaDataGridViewTextBoxColumn,
            this.horaCierreDataGridViewTextBoxColumn,
            this.montoTotalDataGridViewTextBoxColumn,
            this.formaPagoDataGridViewTextBoxColumn,
            this.fechaPagoDataGridViewTextBoxColumn,
            this.kilometrajeDataGridViewTextBoxColumn,
            this.cantidadCombustibleDataGridViewTextBoxColumn,
            this.descripcionFallaDataGridViewTextBoxColumn});
            this.dgvOrdenes.DataSource = this.ordenesBindingSource;
            this.dgvOrdenes.Location = new System.Drawing.Point(13, 180);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.ReadOnly = true;
            this.dgvOrdenes.Size = new System.Drawing.Size(747, 184);
            this.dgvOrdenes.TabIndex = 14;
            // 
            // codOrdenDataGridViewTextBoxColumn
            // 
            this.codOrdenDataGridViewTextBoxColumn.DataPropertyName = "codOrden";
            this.codOrdenDataGridViewTextBoxColumn.HeaderText = "codOrden";
            this.codOrdenDataGridViewTextBoxColumn.Name = "codOrdenDataGridViewTextBoxColumn";
            this.codOrdenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codEstadoDataGridViewTextBoxColumn
            // 
            this.codEstadoDataGridViewTextBoxColumn.DataPropertyName = "codEstado";
            this.codEstadoDataGridViewTextBoxColumn.HeaderText = "codEstado";
            this.codEstadoDataGridViewTextBoxColumn.Name = "codEstadoDataGridViewTextBoxColumn";
            this.codEstadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patenteDataGridViewTextBoxColumn
            // 
            this.patenteDataGridViewTextBoxColumn.DataPropertyName = "patente";
            this.patenteDataGridViewTextBoxColumn.HeaderText = "patente";
            this.patenteDataGridViewTextBoxColumn.Name = "patenteDataGridViewTextBoxColumn";
            this.patenteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dniClienteDataGridViewTextBoxColumn
            // 
            this.dniClienteDataGridViewTextBoxColumn.DataPropertyName = "dniCliente";
            this.dniClienteDataGridViewTextBoxColumn.HeaderText = "dniCliente";
            this.dniClienteDataGridViewTextBoxColumn.Name = "dniClienteDataGridViewTextBoxColumn";
            this.dniClienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaAltaDataGridViewTextBoxColumn
            // 
            this.fechaAltaDataGridViewTextBoxColumn.DataPropertyName = "fechaAlta";
            this.fechaAltaDataGridViewTextBoxColumn.HeaderText = "fechaAlta";
            this.fechaAltaDataGridViewTextBoxColumn.Name = "fechaAltaDataGridViewTextBoxColumn";
            this.fechaAltaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaCierreDataGridViewTextBoxColumn
            // 
            this.fechaCierreDataGridViewTextBoxColumn.DataPropertyName = "fechaCierre";
            this.fechaCierreDataGridViewTextBoxColumn.HeaderText = "fechaCierre";
            this.fechaCierreDataGridViewTextBoxColumn.Name = "fechaCierreDataGridViewTextBoxColumn";
            this.fechaCierreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // horaAltaDataGridViewTextBoxColumn
            // 
            this.horaAltaDataGridViewTextBoxColumn.DataPropertyName = "HoraAlta";
            this.horaAltaDataGridViewTextBoxColumn.HeaderText = "HoraAlta";
            this.horaAltaDataGridViewTextBoxColumn.Name = "horaAltaDataGridViewTextBoxColumn";
            this.horaAltaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // horaCierreDataGridViewTextBoxColumn
            // 
            this.horaCierreDataGridViewTextBoxColumn.DataPropertyName = "HoraCierre";
            this.horaCierreDataGridViewTextBoxColumn.HeaderText = "HoraCierre";
            this.horaCierreDataGridViewTextBoxColumn.Name = "horaCierreDataGridViewTextBoxColumn";
            this.horaCierreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoTotalDataGridViewTextBoxColumn
            // 
            this.montoTotalDataGridViewTextBoxColumn.DataPropertyName = "montoTotal";
            this.montoTotalDataGridViewTextBoxColumn.HeaderText = "montoTotal";
            this.montoTotalDataGridViewTextBoxColumn.Name = "montoTotalDataGridViewTextBoxColumn";
            this.montoTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formaPagoDataGridViewTextBoxColumn
            // 
            this.formaPagoDataGridViewTextBoxColumn.DataPropertyName = "formaPago";
            this.formaPagoDataGridViewTextBoxColumn.HeaderText = "formaPago";
            this.formaPagoDataGridViewTextBoxColumn.Name = "formaPagoDataGridViewTextBoxColumn";
            this.formaPagoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaPagoDataGridViewTextBoxColumn
            // 
            this.fechaPagoDataGridViewTextBoxColumn.DataPropertyName = "fechaPago";
            this.fechaPagoDataGridViewTextBoxColumn.HeaderText = "fechaPago";
            this.fechaPagoDataGridViewTextBoxColumn.Name = "fechaPagoDataGridViewTextBoxColumn";
            this.fechaPagoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kilometrajeDataGridViewTextBoxColumn
            // 
            this.kilometrajeDataGridViewTextBoxColumn.DataPropertyName = "kilometraje";
            this.kilometrajeDataGridViewTextBoxColumn.HeaderText = "kilometraje";
            this.kilometrajeDataGridViewTextBoxColumn.Name = "kilometrajeDataGridViewTextBoxColumn";
            this.kilometrajeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadCombustibleDataGridViewTextBoxColumn
            // 
            this.cantidadCombustibleDataGridViewTextBoxColumn.DataPropertyName = "cantidadCombustible";
            this.cantidadCombustibleDataGridViewTextBoxColumn.HeaderText = "cantidadCombustible";
            this.cantidadCombustibleDataGridViewTextBoxColumn.Name = "cantidadCombustibleDataGridViewTextBoxColumn";
            this.cantidadCombustibleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionFallaDataGridViewTextBoxColumn
            // 
            this.descripcionFallaDataGridViewTextBoxColumn.DataPropertyName = "descripcionFalla";
            this.descripcionFallaDataGridViewTextBoxColumn.HeaderText = "descripcionFalla";
            this.descripcionFallaDataGridViewTextBoxColumn.Name = "descripcionFallaDataGridViewTextBoxColumn";
            this.descripcionFallaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordenesBindingSource
            // 
            this.ordenesBindingSource.DataMember = "Ordenes";
            this.ordenesBindingSource.DataSource = this.taller_PAVDataSet1;
            // 
            // taller_PAVDataSet1
            // 
            this.taller_PAVDataSet1.DataSetName = "Taller_PAVDataSet1";
            this.taller_PAVDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(486, 31);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(121, 20);
            this.dtpHasta.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(85, 74);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 12;
            this.lblEstado.Text = "Estado";
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(85, 110);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(44, 13);
            this.lblPatente.TabIndex = 11;
            this.lblPatente.Text = "Patente";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(165, 31);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(121, 20);
            this.dtpDesde.TabIndex = 0;
            this.dtpDesde.Value = new System.DateTime(2000, 7, 14, 0, 0, 0, 0);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(386, 74);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(50, 13);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "ID Orden";
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Location = new System.Drawing.Point(374, 37);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(89, 13);
            this.lblFechaHasta.TabIndex = 2;
            this.lblFechaHasta.Text = "Fecha Alta Hasta";
            // 
            // lblFechDesde
            // 
            this.lblFechDesde.AutoSize = true;
            this.lblFechDesde.Location = new System.Drawing.Point(58, 30);
            this.lblFechDesde.Name = "lblFechDesde";
            this.lblFechDesde.Size = new System.Drawing.Size(92, 13);
            this.lblFechDesde.TabIndex = 1;
            this.lblFechDesde.Text = "Fecha Alta Desde";
            // 
            // cboEstados
            // 
            this.cboEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstados.FormattingEnabled = true;
            this.cboEstados.Location = new System.Drawing.Point(165, 66);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(121, 21);
            this.cboEstados.TabIndex = 4;
            // 
            // estadosBindingSource
            // 
            this.estadosBindingSource.DataMember = "Estados";
            this.estadosBindingSource.DataSource = this.taller_PAVDataSet;
            // 
            // taller_PAVDataSet
            // 
            this.taller_PAVDataSet.DataSetName = "Taller_PAVDataSet";
            this.taller_PAVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // estadosTableAdapter
            // 
            this.estadosTableAdapter.ClearBeforeFill = true;
            // 
            // ordenesTableAdapter
            // 
            this.ordenesTableAdapter.ClearBeforeFill = true;
            // 
            // frmConsultaOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConsultaOrden";
            this.Text = "Consulta de Órdenes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taller_PAVDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taller_PAVDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Label lblFechDesde;
        private System.Windows.Forms.ComboBox cboEstados;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.TextBox txtIdOrden;
        private Taller_PAVDataSet taller_PAVDataSet;
        private System.Windows.Forms.BindingSource estadosBindingSource;
        private Taller_PAVDataSetTableAdapters.EstadosTableAdapter estadosTableAdapter;
        private Taller_PAVDataSet1 taller_PAVDataSet1;
        private System.Windows.Forms.BindingSource ordenesBindingSource;
        private Taller_PAVDataSet1TableAdapters.OrdenesTableAdapter ordenesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn codOrdenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEstadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dniClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAltaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCierreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaAltaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaCierreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formaPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kilometrajeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadCombustibleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionFallaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox txtDNI;
    }
}