namespace ModuloCascos
{
    partial class TicketEntrada
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSetFacturas = new ModuloCascos.DataSetFacturas();
            this.T_MovimientosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.T_MovimientosTableAdapter = new ModuloCascos.DataSetFacturasTableAdapters.T_MovimientosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_MovimientosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.T_MovimientosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ModuloCascos.TicketEntrada.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 314);
            this.reportViewer1.TabIndex = 0;
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
            // T_MovimientosTableAdapter
            // 
            this.T_MovimientosTableAdapter.ClearBeforeFill = true;
            // 
            // TicketEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 314);
            this.Controls.Add(this.reportViewer1);
            this.Name = "TicketEntrada";
            this.Text = "TicketEntrada";
            this.Load += new System.EventHandler(this.TicketEntrada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_MovimientosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource T_MovimientosBindingSource;
        private DataSetFacturas DataSetFacturas;
        private DataSetFacturasTableAdapters.T_MovimientosTableAdapter T_MovimientosTableAdapter;
    }
}