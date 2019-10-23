namespace TallerAutos.GUILayer
{
    partial class frmRptOT
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
            this.btnGenerar = new System.Windows.Forms.Button();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataTableOTsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTableOTsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dsRptOT = new TallerAutos.dsRptOT();
            this.dataTableOTsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataTableOTsTableAdapter = new TallerAutos.dsRptOTTableAdapters.dataTableOTsTableAdapter();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.lblCboAño = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableOTsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableOTsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRptOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableOTsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(467, 44);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 0;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click_1);
            // 
            // cboMes
            // 
            this.cboMes.FormattingEnabled = true;
            this.cboMes.Location = new System.Drawing.Point(297, 27);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(121, 21);
            this.cboMes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar mes reporte:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "datasetRptOT";
            reportDataSource1.Value = this.dataTableOTsBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TallerAutos.Reportes.rptOT2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 90);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(765, 496);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // dataTableOTsBindingSource2
            // 
            this.dataTableOTsBindingSource2.DataMember = "dataTableOTs";
            this.dataTableOTsBindingSource2.DataSource = this.dsRptOT;
            // 
            // dsRptOT
            // 
            this.dsRptOT.DataSetName = "dsRptOT";
            this.dsRptOT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTableOTsBindingSource1
            // 
            this.dataTableOTsBindingSource1.DataMember = "dataTableOTs";
            this.dataTableOTsBindingSource1.DataSource = this.dsRptOT;
            // 
            // dataTableOTsTableAdapter
            // 
            this.dataTableOTsTableAdapter.ClearBeforeFill = true;
            // 
            // cboAño
            // 
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(297, 63);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(121, 21);
            this.cboAño.TabIndex = 4;
            // 
            // lblCboAño
            // 
            this.lblCboAño.AutoSize = true;
            this.lblCboAño.Location = new System.Drawing.Point(167, 66);
            this.lblCboAño.Name = "lblCboAño";
            this.lblCboAño.Size = new System.Drawing.Size(123, 13);
            this.lblCboAño.TabIndex = 5;
            this.lblCboAño.Text = "Seleccionar año reporte:";
            // 
            // frmRptOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 598);
            this.Controls.Add(this.lblCboAño);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.btnGenerar);
            this.Name = "frmRptOT";
            this.Text = "frmRptOT";
            this.Load += new System.EventHandler(this.frmRptOT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableOTsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableOTsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRptOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableOTsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataTableOTsBindingSource;
        private dsRptOTTableAdapters.dataTableOTsTableAdapter dataTableOTsTableAdapter;
        private System.Windows.Forms.BindingSource dataTableOTsBindingSource1;
        private dsRptOT dsRptOT;
        private System.Windows.Forms.BindingSource dataTableOTsBindingSource2;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label lblCboAño;
    }
}