namespace MC.ModuloEntrada.WinForm.FrontEnd
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.Imagen_DisfruteVisita = new System.Windows.Forms.PictureBox();
            this.Imagen_VehiculoEntrando = new System.Windows.Forms.PictureBox();
            this.btn_llegoCarro = new System.Windows.Forms.Button();
            this.Imagen_Fondo = new System.Windows.Forms.PictureBox();
            this.tmrTimeOut = new System.Windows.Forms.Timer(this.components);
            this.Imagen_SistemaSuspendido = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Animacion_Principal = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.Animacion_RetireTarjeta = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.Animacion_PublicidadSecundaria = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.btn_CarroBarrera = new System.Windows.Forms.Button();
            this.btn_CarroFuera = new System.Windows.Forms.Button();
            this.Imagen_TarjetaInvalida = new System.Windows.Forms.PictureBox();
            this.Imagen_DisfruteVisitaAuto = new System.Windows.Forms.PictureBox();
            this.Imagen_TarjetaSinRegistroSalida = new System.Windows.Forms.PictureBox();
            this.tmrEnvioImagenes = new System.Windows.Forms.Timer(this.components);
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblDatosAuto = new System.Windows.Forms.Label();
            this.Imagen_AutoVencida = new System.Windows.Forms.PictureBox();
            this.Imagen_SinTarjetas = new System.Windows.Forms.PictureBox();
            this.lblHoraINgreso = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_DisfruteVisita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_VehiculoEntrando)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_Fondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_SistemaSuspendido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animacion_Principal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animacion_RetireTarjeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animacion_PublicidadSecundaria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_TarjetaInvalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_DisfruteVisitaAuto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_TarjetaSinRegistroSalida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_AutoVencida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_SinTarjetas)).BeginInit();
            this.SuspendLayout();
            // 
            // Imagen_DisfruteVisita
            // 
            this.Imagen_DisfruteVisita.Location = new System.Drawing.Point(36, 292);
            this.Imagen_DisfruteVisita.Name = "Imagen_DisfruteVisita";
            this.Imagen_DisfruteVisita.Size = new System.Drawing.Size(82, 30);
            this.Imagen_DisfruteVisita.TabIndex = 0;
            this.Imagen_DisfruteVisita.TabStop = false;
            // 
            // Imagen_VehiculoEntrando
            // 
            this.Imagen_VehiculoEntrando.Location = new System.Drawing.Point(36, 328);
            this.Imagen_VehiculoEntrando.Name = "Imagen_VehiculoEntrando";
            this.Imagen_VehiculoEntrando.Size = new System.Drawing.Size(82, 29);
            this.Imagen_VehiculoEntrando.TabIndex = 1;
            this.Imagen_VehiculoEntrando.TabStop = false;
            // 
            // btn_llegoCarro
            // 
            this.btn_llegoCarro.Location = new System.Drawing.Point(43, 456);
            this.btn_llegoCarro.Name = "btn_llegoCarro";
            this.btn_llegoCarro.Size = new System.Drawing.Size(117, 23);
            this.btn_llegoCarro.TabIndex = 2;
            this.btn_llegoCarro.Text = "Llego Carro Mueble";
            this.btn_llegoCarro.UseVisualStyleBackColor = true;
            this.btn_llegoCarro.Click += new System.EventHandler(this.btn_llegoCarro_Click);
            // 
            // Imagen_Fondo
            // 
            this.Imagen_Fondo.Location = new System.Drawing.Point(36, 252);
            this.Imagen_Fondo.Name = "Imagen_Fondo";
            this.Imagen_Fondo.Size = new System.Drawing.Size(82, 34);
            this.Imagen_Fondo.TabIndex = 3;
            this.Imagen_Fondo.TabStop = false;
            // 
            // tmrTimeOut
            // 
            this.tmrTimeOut.Interval = 1000;
            this.tmrTimeOut.Tick += new System.EventHandler(this.tmrTimeOut_Tick);
            // 
            // Imagen_SistemaSuspendido
            // 
            this.Imagen_SistemaSuspendido.Location = new System.Drawing.Point(122, 252);
            this.Imagen_SistemaSuspendido.Name = "Imagen_SistemaSuspendido";
            this.Imagen_SistemaSuspendido.Size = new System.Drawing.Size(82, 34);
            this.Imagen_SistemaSuspendido.TabIndex = 8;
            this.Imagen_SistemaSuspendido.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Flujo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Alertas";
            // 
            // Animacion_Principal
            // 
            this.Animacion_Principal.Enabled = true;
            this.Animacion_Principal.Location = new System.Drawing.Point(12, 12);
            this.Animacion_Principal.Name = "Animacion_Principal";
            this.Animacion_Principal.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Animacion_Principal.OcxState")));
            this.Animacion_Principal.Size = new System.Drawing.Size(192, 192);
            this.Animacion_Principal.TabIndex = 11;
            // 
            // Animacion_RetireTarjeta
            // 
            this.Animacion_RetireTarjeta.Enabled = true;
            this.Animacion_RetireTarjeta.Location = new System.Drawing.Point(210, 12);
            this.Animacion_RetireTarjeta.Name = "Animacion_RetireTarjeta";
            this.Animacion_RetireTarjeta.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Animacion_RetireTarjeta.OcxState")));
            this.Animacion_RetireTarjeta.Size = new System.Drawing.Size(192, 192);
            this.Animacion_RetireTarjeta.TabIndex = 12;
            // 
            // Animacion_PublicidadSecundaria
            // 
            this.Animacion_PublicidadSecundaria.Enabled = true;
            this.Animacion_PublicidadSecundaria.Location = new System.Drawing.Point(408, 12);
            this.Animacion_PublicidadSecundaria.Name = "Animacion_PublicidadSecundaria";
            this.Animacion_PublicidadSecundaria.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Animacion_PublicidadSecundaria.OcxState")));
            this.Animacion_PublicidadSecundaria.Size = new System.Drawing.Size(192, 192);
            this.Animacion_PublicidadSecundaria.TabIndex = 13;
            // 
            // btn_CarroBarrera
            // 
            this.btn_CarroBarrera.Location = new System.Drawing.Point(43, 494);
            this.btn_CarroBarrera.Name = "btn_CarroBarrera";
            this.btn_CarroBarrera.Size = new System.Drawing.Size(117, 23);
            this.btn_CarroBarrera.TabIndex = 14;
            this.btn_CarroBarrera.Text = "Llego Carro Barrera";
            this.btn_CarroBarrera.UseVisualStyleBackColor = true;
            this.btn_CarroBarrera.Click += new System.EventHandler(this.btn_CarroBarrera_Click);
            // 
            // btn_CarroFuera
            // 
            this.btn_CarroFuera.Location = new System.Drawing.Point(43, 536);
            this.btn_CarroFuera.Name = "btn_CarroFuera";
            this.btn_CarroFuera.Size = new System.Drawing.Size(117, 23);
            this.btn_CarroFuera.TabIndex = 15;
            this.btn_CarroFuera.Text = "Salio Carro Barrera";
            this.btn_CarroFuera.UseVisualStyleBackColor = true;
            this.btn_CarroFuera.Click += new System.EventHandler(this.btn_CarroFuera_Click);
            // 
            // Imagen_TarjetaInvalida
            // 
            this.Imagen_TarjetaInvalida.Location = new System.Drawing.Point(122, 288);
            this.Imagen_TarjetaInvalida.Name = "Imagen_TarjetaInvalida";
            this.Imagen_TarjetaInvalida.Size = new System.Drawing.Size(82, 34);
            this.Imagen_TarjetaInvalida.TabIndex = 16;
            this.Imagen_TarjetaInvalida.TabStop = false;
            // 
            // Imagen_DisfruteVisitaAuto
            // 
            this.Imagen_DisfruteVisitaAuto.Location = new System.Drawing.Point(36, 363);
            this.Imagen_DisfruteVisitaAuto.Name = "Imagen_DisfruteVisitaAuto";
            this.Imagen_DisfruteVisitaAuto.Size = new System.Drawing.Size(82, 34);
            this.Imagen_DisfruteVisitaAuto.TabIndex = 17;
            this.Imagen_DisfruteVisitaAuto.TabStop = false;
            // 
            // Imagen_TarjetaSinRegistroSalida
            // 
            this.Imagen_TarjetaSinRegistroSalida.Location = new System.Drawing.Point(122, 328);
            this.Imagen_TarjetaSinRegistroSalida.Name = "Imagen_TarjetaSinRegistroSalida";
            this.Imagen_TarjetaSinRegistroSalida.Size = new System.Drawing.Size(82, 34);
            this.Imagen_TarjetaSinRegistroSalida.TabIndex = 21;
            this.Imagen_TarjetaSinRegistroSalida.TabStop = false;
            // 
            // tmrEnvioImagenes
            // 
            this.tmrEnvioImagenes.Interval = 10000;
            this.tmrEnvioImagenes.Tick += new System.EventHandler(this.tmrEnvioImagenes_Tick);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold);
            this.lblBienvenido.ForeColor = System.Drawing.Color.Black;
            this.lblBienvenido.Location = new System.Drawing.Point(12, 370);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(998, 83);
            this.lblBienvenido.TabIndex = 1182;
            this.lblBienvenido.Text = "BIENVENIDO";
            this.lblBienvenido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDatosAuto
            // 
            this.lblDatosAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold);
            this.lblDatosAuto.ForeColor = System.Drawing.Color.Black;
            this.lblDatosAuto.Location = new System.Drawing.Point(12, 476);
            this.lblDatosAuto.Name = "lblDatosAuto";
            this.lblDatosAuto.Size = new System.Drawing.Size(998, 83);
            this.lblDatosAuto.TabIndex = 1183;
            this.lblDatosAuto.Text = "GEOVANNY TOVAR CEBALLOS";
            this.lblDatosAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Imagen_AutoVencida
            // 
            this.Imagen_AutoVencida.Location = new System.Drawing.Point(122, 368);
            this.Imagen_AutoVencida.Name = "Imagen_AutoVencida";
            this.Imagen_AutoVencida.Size = new System.Drawing.Size(82, 34);
            this.Imagen_AutoVencida.TabIndex = 1184;
            this.Imagen_AutoVencida.TabStop = false;
            // 
            // Imagen_SinTarjetas
            // 
            this.Imagen_SinTarjetas.Location = new System.Drawing.Point(122, 408);
            this.Imagen_SinTarjetas.Name = "Imagen_SinTarjetas";
            this.Imagen_SinTarjetas.Size = new System.Drawing.Size(82, 34);
            this.Imagen_SinTarjetas.TabIndex = 1185;
            this.Imagen_SinTarjetas.TabStop = false;
            // 
            // lblHoraINgreso
            // 
            this.lblHoraINgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.lblHoraINgreso.ForeColor = System.Drawing.Color.Black;
            this.lblHoraINgreso.Location = new System.Drawing.Point(12, 359);
            this.lblHoraINgreso.Name = "lblHoraINgreso";
            this.lblHoraINgreso.Size = new System.Drawing.Size(998, 62);
            this.lblHoraINgreso.TabIndex = 1186;
            this.lblHoraINgreso.Text = "HORA DE ENTRADA ES 12:06:20";
            this.lblHoraINgreso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1022, 766);
            this.ControlBox = false;
            this.Controls.Add(this.lblHoraINgreso);
            this.Controls.Add(this.Imagen_SinTarjetas);
            this.Controls.Add(this.Imagen_AutoVencida);
            this.Controls.Add(this.Imagen_TarjetaSinRegistroSalida);
            this.Controls.Add(this.Imagen_DisfruteVisitaAuto);
            this.Controls.Add(this.Imagen_TarjetaInvalida);
            this.Controls.Add(this.btn_CarroFuera);
            this.Controls.Add(this.btn_CarroBarrera);
            this.Controls.Add(this.Animacion_PublicidadSecundaria);
            this.Controls.Add(this.Animacion_RetireTarjeta);
            this.Controls.Add(this.Animacion_Principal);
            this.Controls.Add(this.Imagen_SistemaSuspendido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Imagen_Fondo);
            this.Controls.Add(this.btn_llegoCarro);
            this.Controls.Add(this.Imagen_VehiculoEntrando);
            this.Controls.Add(this.Imagen_DisfruteVisita);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblDatosAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_DisfruteVisita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_VehiculoEntrando)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_Fondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_SistemaSuspendido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animacion_Principal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animacion_RetireTarjeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Animacion_PublicidadSecundaria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_TarjetaInvalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_DisfruteVisitaAuto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_TarjetaSinRegistroSalida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_AutoVencida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_SinTarjetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Imagen_DisfruteVisita;
        private System.Windows.Forms.PictureBox Imagen_VehiculoEntrando;
        private System.Windows.Forms.Button btn_llegoCarro;
        private System.Windows.Forms.PictureBox Imagen_Fondo;
        private System.Windows.Forms.Timer tmrTimeOut;
        private System.Windows.Forms.PictureBox Imagen_SistemaSuspendido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private AxShockwaveFlashObjects.AxShockwaveFlash Animacion_Principal;
        private AxShockwaveFlashObjects.AxShockwaveFlash Animacion_RetireTarjeta;
        private AxShockwaveFlashObjects.AxShockwaveFlash Animacion_PublicidadSecundaria;
        private System.Windows.Forms.Button btn_CarroBarrera;
        private System.Windows.Forms.Button btn_CarroFuera;
        private System.Windows.Forms.PictureBox Imagen_TarjetaInvalida;
        private System.Windows.Forms.PictureBox Imagen_DisfruteVisitaAuto;
        private System.Windows.Forms.PictureBox Imagen_TarjetaSinRegistroSalida;
        private System.Windows.Forms.Timer tmrEnvioImagenes;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblDatosAuto;
        private System.Windows.Forms.PictureBox Imagen_AutoVencida;
        private System.Windows.Forms.PictureBox Imagen_SinTarjetas;
        private System.Windows.Forms.Label lblHoraINgreso;
    }
}

