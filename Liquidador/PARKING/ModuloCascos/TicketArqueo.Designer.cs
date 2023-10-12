namespace ModuloCascos
{
    partial class TicketArqueo
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
            this.T_ArqueosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.T_ArqueosTableAdapter = new ModuloCascos.DataSetFacturasTableAdapters.T_ArqueosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_ArqueosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.T_ArqueosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ModuloCascos.TicketArqueo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(389, 453);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSetFacturas
            // 
            this.DataSetFacturas.DataSetName = "DataSetFacturas";
            this.DataSetFacturas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // T_ArqueosBindingSource
            // 
            this.T_ArqueosBindingSource.DataMember = "T_Arqueos";
            this.T_ArqueosBindingSource.DataSource = this.DataSetFacturas;
            // 
            // T_ArqueosTableAdapter
            // 
            this.T_ArqueosTableAdapter.ClearBeforeFill = true;
            // 
            // TicketArqueo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 453);
            this.Controls.Add(this.reportViewer1);
            this.Name = "TicketArqueo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TicketArqueo";
            this.Load += new System.EventHandler(this.TicketArqueo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_ArqueosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource T_ArqueosBindingSource;
        private DataSetFacturas DataSetFacturas;
        private DataSetFacturasTableAdapters.T_ArqueosTableAdapter T_ArqueosTableAdapter;
    }
}