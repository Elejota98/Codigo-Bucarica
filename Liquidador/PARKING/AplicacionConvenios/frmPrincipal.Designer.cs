namespace AplicacionConvenios
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.TsBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btn_LeerTarjeta = new System.Windows.Forms.ToolStripButton();
            this.btn_Cargue = new System.Windows.Forms.ToolStripButton();
            this.btn_uSUARIO = new System.Windows.Forms.ToolStripButton();
            this.btn_Reports = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaACtual = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIdTarjeta = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTipoVehiculo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFechaEntrada = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pMas = new System.Windows.Forms.Panel();
            this.pMenos = new System.Windows.Forms.Panel();
            this.tbHoras = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pAplicarDescuento = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.tmrHora = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TsUsuario = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TsCargo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsEstable = new System.Windows.Forms.ToolStripLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TsBar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TsBar
            // 
            this.TsBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.TsBar.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.TsBar.ImageScalingSize = new System.Drawing.Size(90, 90);
            this.TsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btn_LeerTarjeta,
            this.btn_Cargue,
            this.btn_uSUARIO,
            this.btn_Reports});
            this.TsBar.Location = new System.Drawing.Point(0, 0);
            this.TsBar.Name = "TsBar";
            this.TsBar.Size = new System.Drawing.Size(96, 527);
            this.TsBar.TabIndex = 13;
            this.TsBar.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(93, 4);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // btn_LeerTarjeta
            // 
            this.btn_LeerTarjeta.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btn_LeerTarjeta.Image = ((System.Drawing.Image)(resources.GetObject("btn_LeerTarjeta.Image")));
            this.btn_LeerTarjeta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_LeerTarjeta.Name = "btn_LeerTarjeta";
            this.btn_LeerTarjeta.Size = new System.Drawing.Size(93, 108);
            this.btn_LeerTarjeta.Text = "Leer Tarjeta";
            this.btn_LeerTarjeta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_LeerTarjeta.Click += new System.EventHandler(this.btn_LeerTarjeta_Click);
            // 
            // btn_Cargue
            // 
            this.btn_Cargue.Enabled = false;
            this.btn_Cargue.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Cargue.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cargue.Image")));
            this.btn_Cargue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Cargue.Name = "btn_Cargue";
            this.btn_Cargue.Size = new System.Drawing.Size(93, 108);
            this.btn_Cargue.Text = "Cargue Bolsa";
            this.btn_Cargue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Cargue.Click += new System.EventHandler(this.btn_Cargue_Click);
            // 
            // btn_uSUARIO
            // 
            this.btn_uSUARIO.Enabled = false;
            this.btn_uSUARIO.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btn_uSUARIO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_uSUARIO.Image = ((System.Drawing.Image)(resources.GetObject("btn_uSUARIO.Image")));
            this.btn_uSUARIO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_uSUARIO.Name = "btn_uSUARIO";
            this.btn_uSUARIO.Size = new System.Drawing.Size(93, 108);
            this.btn_uSUARIO.Text = "Gestion Usuarios";
            this.btn_uSUARIO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_uSUARIO.Click += new System.EventHandler(this.btn_uSUARIO_Click);
            // 
            // btn_Reports
            // 
            this.btn_Reports.Enabled = false;
            this.btn_Reports.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Reports.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Reports.Image = ((System.Drawing.Image)(resources.GetObject("btn_Reports.Image")));
            this.btn_Reports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Reports.Name = "btn_Reports";
            this.btn_Reports.Size = new System.Drawing.Size(93, 108);
            this.btn_Reports.Text = "Reportes";
            this.btn_Reports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Reports.Click += new System.EventHandler(this.btn_Reports_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblFechaACtual);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblIdTarjeta);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblTipoVehiculo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblFechaEntrada);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox2.Location = new System.Drawing.Point(110, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 221);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DATOS TARJETA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(302, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 64;
            this.label10.Text = "ABC456";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 17);
            this.label6.TabIndex = 63;
            this.label6.Text = "Tiempo permanencia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 62;
            this.label3.Text = "ABC456";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "Placa*";
            // 
            // lblFechaACtual
            // 
            this.lblFechaACtual.AutoSize = true;
            this.lblFechaACtual.Location = new System.Drawing.Point(302, 122);
            this.lblFechaACtual.Name = "lblFechaACtual";
            this.lblFechaACtual.Size = new System.Drawing.Size(140, 17);
            this.lblFechaACtual.TabIndex = 60;
            this.lblFechaACtual.Text = "2018/12/18 15:23:55";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 17);
            this.label9.TabIndex = 59;
            this.label9.Text = "Fecha Hora Actual*";
            // 
            // lblIdTarjeta
            // 
            this.lblIdTarjeta.AutoSize = true;
            this.lblIdTarjeta.Location = new System.Drawing.Point(302, 89);
            this.lblIdTarjeta.Name = "lblIdTarjeta";
            this.lblIdTarjeta.Size = new System.Drawing.Size(77, 17);
            this.lblIdTarjeta.TabIndex = 58;
            this.lblIdTarjeta.Text = "ABDFI87K*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 57;
            this.label4.Text = "Id Tarjeta*";
            // 
            // lblTipoVehiculo
            // 
            this.lblTipoVehiculo.AutoSize = true;
            this.lblTipoVehiculo.Location = new System.Drawing.Point(302, 58);
            this.lblTipoVehiculo.Name = "lblTipoVehiculo";
            this.lblTipoVehiculo.Size = new System.Drawing.Size(48, 17);
            this.lblTipoVehiculo.TabIndex = 56;
            this.lblTipoVehiculo.Text = "Carro*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 55;
            this.label2.Text = "Tipo Vehiculo*";
            // 
            // lblFechaEntrada
            // 
            this.lblFechaEntrada.AutoSize = true;
            this.lblFechaEntrada.Location = new System.Drawing.Point(302, 30);
            this.lblFechaEntrada.Name = "lblFechaEntrada";
            this.lblFechaEntrada.Size = new System.Drawing.Size(140, 17);
            this.lblFechaEntrada.TabIndex = 54;
            this.lblFechaEntrada.Text = "2018/12/18 15:23:55";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 17);
            this.label5.TabIndex = 53;
            this.label5.Text = "Fecha Entrada Al Estacionamiento*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.pMas);
            this.groupBox1.Controls.Add(this.pMenos);
            this.groupBox1.Controls.Add(this.tbHoras);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.pAplicarDescuento);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.groupBox1.Location = new System.Drawing.Point(110, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 250);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "APLICACION HORAS";
            // 
            // pMas
            // 
            this.pMas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pMas.BackgroundImage")));
            this.pMas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pMas.Location = new System.Drawing.Point(289, 123);
            this.pMas.Name = "pMas";
            this.pMas.Size = new System.Drawing.Size(49, 54);
            this.pMas.TabIndex = 61;
            this.pMas.Click += new System.EventHandler(this.pMas_Click);
            // 
            // pMenos
            // 
            this.pMenos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pMenos.BackgroundImage")));
            this.pMenos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pMenos.Location = new System.Drawing.Point(125, 123);
            this.pMenos.Name = "pMenos";
            this.pMenos.Size = new System.Drawing.Size(49, 54);
            this.pMenos.TabIndex = 63;
            this.pMenos.Click += new System.EventHandler(this.pMenos_Click);
            // 
            // tbHoras
            // 
            this.tbHoras.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbHoras.Enabled = false;
            this.tbHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHoras.Location = new System.Drawing.Point(171, 123);
            this.tbHoras.MaxLength = 2;
            this.tbHoras.Multiline = true;
            this.tbHoras.Name = "tbHoras";
            this.tbHoras.Size = new System.Drawing.Size(123, 54);
            this.tbHoras.TabIndex = 62;
            this.tbHoras.Text = "9999";
            this.tbHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(391, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "APLICAR";
            // 
            // pAplicarDescuento
            // 
            this.pAplicarDescuento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pAplicarDescuento.BackgroundImage")));
            this.pAplicarDescuento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pAplicarDescuento.Location = new System.Drawing.Point(393, 173);
            this.pAplicarDescuento.Name = "pAplicarDescuento";
            this.pAplicarDescuento.Size = new System.Drawing.Size(49, 54);
            this.pAplicarDescuento.TabIndex = 60;
            this.pAplicarDescuento.Visible = false;
            this.pAplicarDescuento.Click += new System.EventHandler(this.pAplicarDescuento_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(148, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 17);
            this.label7.TabIndex = 59;
            this.label7.Text = "HORAS DE CONVENIO*";
            // 
            // tmrHora
            // 
            this.tmrHora.Interval = 1000;
            this.tmrHora.Tick += new System.EventHandler(this.tmrHora_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsUsuario,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.TsCargo,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.tsEstable});
            this.toolStrip1.Location = new System.Drawing.Point(96, 502);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(511, 25);
            this.toolStrip1.TabIndex = 60;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TsUsuario
            // 
            this.TsUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TsUsuario.Name = "TsUsuario";
            this.TsUsuario.Size = new System.Drawing.Size(56, 22);
            this.TsUsuario.Text = "USUARIO";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // TsCargo
            // 
            this.TsCargo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TsCargo.Name = "TsCargo";
            this.TsCargo.Size = new System.Drawing.Size(52, 22);
            this.TsCargo.Text = "ADMON";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsEstable
            // 
            this.tsEstable.Name = "tsEstable";
            this.tsEstable.Size = new System.Drawing.Size(105, 22);
            this.tsEstable.Text = "ESTABLECIMIENTO";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CONVENIO 1",
            "CONVENIO 2",
            "CONVENIO 3",
            "CONVENIO 4",
            "CONVENIO 5"});
            this.comboBox1.Location = new System.Drawing.Point(49, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(356, 24);
            this.comboBox1.TabIndex = 64;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(93, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(286, 17);
            this.label11.TabIndex = 65;
            this.label11.Text = "SELECCIONE EL NOMBRE DEL CONVENIO";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 527);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.TsBar);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modulo Gestion Convenios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.TsBar.ResumeLayout(false);
            this.TsBar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TsBar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btn_Reports;
        private System.Windows.Forms.ToolStripButton btn_uSUARIO;
        private System.Windows.Forms.ToolStripButton btn_LeerTarjeta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblIdTarjeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTipoVehiculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFechaEntrada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbHoras;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pAplicarDescuento;
        private System.Windows.Forms.Panel pMas;
        private System.Windows.Forms.Panel pMenos;
        private System.Windows.Forms.Label lblFechaACtual;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer tmrHora;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel TsUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel TsCargo;
        private System.Windows.Forms.ToolStripButton btn_Cargue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel tsEstable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}