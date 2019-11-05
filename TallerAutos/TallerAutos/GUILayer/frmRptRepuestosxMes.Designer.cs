namespace TallerAutos.GUILayer
{
    partial class frmRptRepuestosxMes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptRepuestosxMes));
            this.bindingRepxMes = new System.Windows.Forms.BindingSource(this.components);
            this.dsRptOT1 = new TallerAutos.dsRptOT();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.cboMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.repuestosxMesTableAdapter1 = new TallerAutos.dsRptOTTableAdapters.RepuestosxMesTableAdapter();
            this.cboAño = new System.Windows.Forms.ComboBox();
            this.lblCboAño = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRepxMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRptOT1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingRepxMes
            // 
            this.bindingRepxMes.DataMember = "RepuestosxMes";
            this.bindingRepxMes.DataSource = this.dsRptOT1;
            // 
            // dsRptOT1
            // 
            this.dsRptOT1.DataSetName = "dsRptOT1";
            this.dsRptOT1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(377, 36);
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
            this.cboMes.Location = new System.Drawing.Point(207, 19);
            this.cboMes.Name = "cboMes";
            this.cboMes.Size = new System.Drawing.Size(121, 21);
            this.cboMes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar mes reporte:";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "dataSetRepuestosxMes";
            reportDataSource1.Value = this.bindingRepxMes;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TallerAutos.Reportes.rptRepxMes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 90);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(762, 546);
            this.reportViewer1.TabIndex = 3;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // repuestosxMesTableAdapter1
            // 
            this.repuestosxMesTableAdapter1.ClearBeforeFill = true;
            // 
            // cboAño
            // 
            this.cboAño.FormattingEnabled = true;
            this.cboAño.Location = new System.Drawing.Point(207, 55);
            this.cboAño.Name = "cboAño";
            this.cboAño.Size = new System.Drawing.Size(121, 21);
            this.cboAño.TabIndex = 4;
            // 
            // lblCboAño
            // 
            this.lblCboAño.AutoSize = true;
            this.lblCboAño.Location = new System.Drawing.Point(77, 58);
            this.lblCboAño.Name = "lblCboAño";
            this.lblCboAño.Size = new System.Drawing.Size(123, 13);
            this.lblCboAño.TabIndex = 5;
            this.lblCboAño.Text = "Seleccionar año reporte:";
            // 
            // frmRptRepuestosxMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 553);
            this.Controls.Add(this.lblCboAño);
            this.Controls.Add(this.cboAño);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.btnGenerar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptRepuestosxMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Repuestos";
            this.Load += new System.EventHandler(this.frmRptRepuestosxMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingRepxMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsRptOT1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCboAño;
        private System.Windows.Forms.ComboBox cboAño;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMes;
        private System.Windows.Forms.Button btnGenerar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
       // private dsRptOTTableAdapters.RepuestosxMesTableAdapter repuestosxMesTableAdapter;
        private dsRptOTTableAdapters.RepuestosxMesTableAdapter repuestosxMesTableAdapter1;
        private dsRptOT dsRptOT1;
        private System.Windows.Forms.BindingSource bindingRepxMes;
    }
}