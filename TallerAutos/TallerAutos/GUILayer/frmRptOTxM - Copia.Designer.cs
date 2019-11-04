namespace TallerAutos.GUILayer.Formularios_de_Reportes
{
    partial class frmRptOTxM
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dataTableOTsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsRptOT1 = new TallerAutos.dsRptOT();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataTableOTsTableAdapter1 = new TallerAutos.dsRptOTTableAdapters.dataTableOTsTableAdapter();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblCboAño = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableOTsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRptOT1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTableOTsBindingSource
            // 
            this.dataTableOTsBindingSource.DataMember = "dataTableOTs";
            this.dataTableOTsBindingSource.DataSource = this.dsRptOT1;
            // 
            // dsRptOT1
            // 
            this.dsRptOT1.DataSetName = "dsRptOT1";
            this.dsRptOT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(518, 50);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "dataSetMarcasOT";
            reportDataSource1.Value = this.dataTableOTsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TallerAutos.Reportes.rptOTxMc.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 90);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(765, 496);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // dataTableOTsTableAdapter1
            // 
            this.dataTableOTsTableAdapter1.ClearBeforeFill = true;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(294, 53);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 11;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(294, 17);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 10;
            // 
            // lblCboAño
            // 
            this.lblCboAño.AutoSize = true;
            this.lblCboAño.Location = new System.Drawing.Point(163, 59);
            this.lblCboAño.Name = "lblCboAño";
            this.lblCboAño.Size = new System.Drawing.Size(125, 13);
            this.lblCboAño.TabIndex = 9;
            this.lblCboAño.Text = "Seleccionar fecha hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleccionar fecha desde:";
            // 
            // frmRptOTxM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 598);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lblCboAño);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnGenerar);
            this.Name = "frmRptOTxM";
            this.Text = "frmRptOTxMc";
            this.Load += new System.EventHandler(this.frmRptOTxM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableOTsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRptOT1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dsRptOTTableAdapters.dataTableOTsTableAdapter dataTableOTsTableAdapter1;
        private System.Windows.Forms.Button btnGenerar;
        private dsRptOT dsRptOT1;
        //private dsRptOTTableAdapters.TableAdapterManager tableAdapterManager1;
       // private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource dataTableOTsBindingSource;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblCboAño;
        private System.Windows.Forms.Label label1;
    }
}