namespace ModuloCascos
{
    partial class TicketCasco
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
            this.T_MovimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetFacturas = new ModuloCascos.DataSetFacturas();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.T_MovimientosTableAdapter = new ModuloCascos.DataSetFacturasTableAdapters.T_MovimientosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.T_MovimientosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // T_MovimientosBindingSource
            // 
            this.T_MovimientosBindingSource.DataMember = "T_Movimientos";
            this.T_MovimientosBindingSource.DataSource = this.DataSetFacturas;
            // 
            // DataSetFacturas
            // 
            this.DataSetFacturas.DataSetName = "DataSetFacturas";
            this.DataSetFacturas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.T_MovimientosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ModuloCascos.TicketPago.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(365, 603);
            this.reportViewer1.TabIndex = 0;
            // 
            // T_MovimientosTableAdapter
            // 
            this.T_MovimientosTableAdapter.ClearBeforeFill = true;
            // 
            // TicketCasco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 603);
            this.Controls.Add(this.reportViewer1);
            this.Name = "TicketCasco";
            this.Text = "TicketCasco";
            this.Load += new System.EventHandler(this.TicketCasco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.T_MovimientosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetFacturas DataSetFacturas;
        private System.Windows.Forms.BindingSource T_MovimientosBindingSource;
        private DataSetFacturasTableAdapters.T_MovimientosTableAdapter T_MovimientosTableAdapter;
    }
}