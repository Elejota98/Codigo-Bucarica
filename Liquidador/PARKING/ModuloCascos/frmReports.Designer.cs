namespace ModuloCascos
{
    partial class frmReports
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
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetFacturas = new ModuloCascos.DataSetFacturas();
            this.T_MovimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbHoraFin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHoraIni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.T_MovimientosTableAdapter = new ModuloCascos.DataSetFacturasTableAdapters.T_MovimientosTableAdapter();
            this.DataTable1TableAdapter = new ModuloCascos.DataSetFacturasTableAdapters.DataTable1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_MovimientosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.DataSetFacturas;
            // 
            // DataSetFacturas
            // 
            this.DataSetFacturas.DataSetName = "DataSetFacturas";
            this.DataSetFacturas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // T_MovimientosBindingSource
            // 
            this.T_MovimientosBindingSource.DataMember = "T_Movimientos";
            this.T_MovimientosBindingSource.DataSource = this.DataSetFacturas;
            // 
            // tbHoraFin
            // 
            this.tbHoraFin.Location = new System.Drawing.Point(274, 33);
            this.tbHoraFin.MaxLength = 8;
            this.tbHoraFin.Name = "tbHoraFin";
            this.tbHoraFin.Size = new System.Drawing.Size(93, 20);
            this.tbHoraFin.TabIndex = 37;
            this.tbHoraFin.Text = "23:59:59";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "HORA FINAL";
            // 
            // tbHoraIni
            // 
            this.tbHoraIni.Location = new System.Drawing.Point(94, 33);
            this.tbHoraIni.MaxLength = 8;
            this.tbHoraIni.Name = "tbHoraIni";
            this.tbHoraIni.Size = new System.Drawing.Size(93, 20);
            this.tbHoraIni.TabIndex = 35;
            this.tbHoraIni.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "HORA INICIAL";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(358, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "CONSULTAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpFinal
            // 
            this.dtpFinal.CustomFormat = "yyyy-MM-dd";
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(274, 5);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(93, 20);
            this.dtpFinal.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "FECHA FINAL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "FECHA INICIAL";
            // 
            // dtpInicial
            // 
            this.dtpInicial.CustomFormat = "";
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(94, 5);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(93, 20);
            this.dtpInicial.TabIndex = 29;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ModuloCascos.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 88);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(365, 545);
            this.reportViewer1.TabIndex = 38;
            // 
            // T_MovimientosTableAdapter
            // 
            this.T_MovimientosTableAdapter.ClearBeforeFill = true;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 640);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.tbHoraFin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbHoraIni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpInicial);
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_MovimientosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHoraFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHoraIni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource T_MovimientosBindingSource;
        private DataSetFacturas DataSetFacturas;
        private DataSetFacturasTableAdapters.T_MovimientosTableAdapter T_MovimientosTableAdapter;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private DataSetFacturasTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
    }
}