namespace MC.ModuloManual.WinForm.FrontEnd
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
            this.tmrHora = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TsUsuario = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TsFechaHora = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TsSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPlaca = new System.Windows.Forms.TextBox();
            this.lblFechaIngresoIn = new System.Windows.Forms.Label();
            this.btn_RegistrarEntrada = new CustomButton.CustomButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_LeerTIAuto = new CustomButton.CustomButton();
            this.Btn_IngresoAuto = new CustomButton.CustomButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombreAutorizado = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cbTipoAuto = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPlacaAuto = new System.Windows.Forms.TextBox();
            this.lblFechaInAuto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_LeerTI = new CustomButton.CustomButton();
            this.btn_Pay = new CustomButton.CustomButton();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFechaPago = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.cbRepo = new System.Windows.Forms.CheckBox();
            this.cbCortesia = new System.Windows.Forms.CheckBox();
            this.cbCiclo = new System.Windows.Forms.CheckBox();
            this.lblTipoVehiculo = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblFechaEntrada = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblTipoTarjeta = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblIdTarjeta = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
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
            this.TsFechaHora,
            this.toolStripSeparator4,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 660);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1251, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TsUsuario
            // 
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
            // TsFechaHora
            // 
            this.TsFechaHora.Name = "TsFechaHora";
            this.TsFechaHora.Size = new System.Drawing.Size(118, 22);
            this.TsFechaHora.Text = "11:13:00 - 09/09/2016";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsSistema,
            this.TsAyuda});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1251, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TsSistema
            // 
            this.TsSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarContraseñaToolStripMenuItem1,
            this.cerrarSesionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.TsSistema.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TsSistema.Name = "TsSistema";
            this.TsSistema.Size = new System.Drawing.Size(59, 20);
            this.TsSistema.Text = "Sistema";
            // 
            // cambiarContraseñaToolStripMenuItem1
            // 
            this.cambiarContraseñaToolStripMenuItem1.Name = "cambiarContraseñaToolStripMenuItem1";
            this.cambiarContraseñaToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.cambiarContraseñaToolStripMenuItem1.Text = "Cambiar Contraseña";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // TsAyuda
            // 
            this.TsAyuda.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TsAyuda.Name = "TsAyuda";
            this.TsAyuda.Size = new System.Drawing.Size(50, 20);
            this.TsAyuda.Text = "Ayuda";
            this.TsAyuda.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.cbTipo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbPlaca);
            this.groupBox1.Controls.Add(this.lblFechaIngresoIn);
            this.groupBox1.Controls.Add(this.btn_RegistrarEntrada);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(1, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 271);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INGRESO DE VEHICULOS";
            // 
            // cbTipo
            // 
            this.cbTipo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "CARRO",
            "MOTO",
            "BICICLETA"});
            this.cbTipo.Location = new System.Drawing.Point(15, 124);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(110, 22);
            this.cbTipo.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(29, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "TIPO VEHICULO";
            // 
            // tbPlaca
            // 
            this.tbPlaca.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.tbPlaca.Location = new System.Drawing.Point(141, 26);
            this.tbPlaca.MaxLength = 10;
            this.tbPlaca.Multiline = true;
            this.tbPlaca.Name = "tbPlaca";
            this.tbPlaca.Size = new System.Drawing.Size(172, 48);
            this.tbPlaca.TabIndex = 1;
            this.tbPlaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFechaIngresoIn
            // 
            this.lblFechaIngresoIn.AutoSize = true;
            this.lblFechaIngresoIn.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaIngresoIn.Location = new System.Drawing.Point(237, 149);
            this.lblFechaIngresoIn.Name = "lblFechaIngresoIn";
            this.lblFechaIngresoIn.Size = new System.Drawing.Size(110, 14);
            this.lblFechaIngresoIn.TabIndex = 3;
            this.lblFechaIngresoIn.Text = "20/11/2017 21:31:45";
            // 
            // btn_RegistrarEntrada
            // 
            this.btn_RegistrarEntrada.AutoSize = true;
            this.btn_RegistrarEntrada.BackColor = System.Drawing.Color.Transparent;
            this.btn_RegistrarEntrada.FlatAppearance.BorderSize = 0;
            this.btn_RegistrarEntrada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_RegistrarEntrada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_RegistrarEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RegistrarEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RegistrarEntrada.Location = new System.Drawing.Point(5, 187);
            this.btn_RegistrarEntrada.LockPush = true;
            this.btn_RegistrarEntrada.Name = "btn_RegistrarEntrada";
            this.btn_RegistrarEntrada.Size = new System.Drawing.Size(130, 78);
            this.btn_RegistrarEntrada.TabIndex = 3;
            this.btn_RegistrarEntrada.Text = "B";
            this.btn_RegistrarEntrada.UseVisualStyleBackColor = false;
            this.btn_RegistrarEntrada.Click += new System.EventHandler(this.btn_RegistrarEntrada_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(237, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "FECHA HORA DE INGRESO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLACA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(166, 232);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 14);
            this.label13.TabIndex = 7;
            this.label13.Text = "REGISTRAR INGRESO";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Location = new System.Drawing.Point(751, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 88);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.btn_LeerTIAuto);
            this.groupBox3.Controls.Add(this.Btn_IngresoAuto);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblNombreAutorizado);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.cbTipoAuto);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbPlacaAuto);
            this.groupBox3.Controls.Add(this.lblFechaInAuto);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(686, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(553, 441);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "INGRESO CLIENTE AUTORIZADO O MENSUAL";
            // 
            // btn_LeerTIAuto
            // 
            this.btn_LeerTIAuto.AutoSize = true;
            this.btn_LeerTIAuto.BackColor = System.Drawing.Color.Transparent;
            this.btn_LeerTIAuto.FlatAppearance.BorderSize = 0;
            this.btn_LeerTIAuto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_LeerTIAuto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_LeerTIAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LeerTIAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LeerTIAuto.Location = new System.Drawing.Point(39, 327);
            this.btn_LeerTIAuto.LockPush = true;
            this.btn_LeerTIAuto.Name = "btn_LeerTIAuto";
            this.btn_LeerTIAuto.Size = new System.Drawing.Size(124, 51);
            this.btn_LeerTIAuto.TabIndex = 21;
            this.btn_LeerTIAuto.Text = "B";
            this.btn_LeerTIAuto.UseVisualStyleBackColor = false;
            this.btn_LeerTIAuto.Click += new System.EventHandler(this.btn_LeerTIAuto_Click);
            // 
            // Btn_IngresoAuto
            // 
            this.Btn_IngresoAuto.AutoSize = true;
            this.Btn_IngresoAuto.BackColor = System.Drawing.Color.Transparent;
            this.Btn_IngresoAuto.FlatAppearance.BorderSize = 0;
            this.Btn_IngresoAuto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Btn_IngresoAuto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Btn_IngresoAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_IngresoAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_IngresoAuto.Location = new System.Drawing.Point(352, 294);
            this.Btn_IngresoAuto.LockPush = true;
            this.Btn_IngresoAuto.Name = "Btn_IngresoAuto";
            this.Btn_IngresoAuto.Size = new System.Drawing.Size(104, 51);
            this.Btn_IngresoAuto.TabIndex = 19;
            this.Btn_IngresoAuto.Text = "B";
            this.Btn_IngresoAuto.UseVisualStyleBackColor = false;
            this.Btn_IngresoAuto.Click += new System.EventHandler(this.Btn_IngresoAuto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(316, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "REGISTRAR INGRESO";
            // 
            // lblNombreAutorizado
            // 
            this.lblNombreAutorizado.AutoSize = true;
            this.lblNombreAutorizado.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.lblNombreAutorizado.Location = new System.Drawing.Point(184, 156);
            this.lblNombreAutorizado.Name = "lblNombreAutorizado";
            this.lblNombreAutorizado.Size = new System.Drawing.Size(340, 24);
            this.lblNombreAutorizado.TabIndex = 10;
            this.lblNombreAutorizado.Text = "ALFREDO PIROBERTO PEREZ GONZALEZ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(5, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 24);
            this.label11.TabIndex = 9;
            this.label11.Text = "NOMBRE CLIENTE";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(41, 291);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(122, 24);
            this.label16.TabIndex = 19;
            this.label16.Text = "LEER TARJETA";
            // 
            // cbTipoAuto
            // 
            this.cbTipoAuto.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.cbTipoAuto.FormattingEnabled = true;
            this.cbTipoAuto.Items.AddRange(new object[] {
            "CARRO",
            "MOTO",
            "BICICLETA"});
            this.cbTipoAuto.Location = new System.Drawing.Point(152, 97);
            this.cbTipoAuto.Name = "cbTipoAuto";
            this.cbTipoAuto.Size = new System.Drawing.Size(137, 32);
            this.cbTipoAuto.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(5, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "TIPO VEHICULO";
            // 
            // tbPlacaAuto
            // 
            this.tbPlacaAuto.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.tbPlacaAuto.Location = new System.Drawing.Point(73, 57);
            this.tbPlacaAuto.MaxLength = 10;
            this.tbPlacaAuto.Multiline = true;
            this.tbPlacaAuto.Name = "tbPlacaAuto";
            this.tbPlacaAuto.Size = new System.Drawing.Size(160, 28);
            this.tbPlacaAuto.TabIndex = 4;
            this.tbPlacaAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFechaInAuto
            // 
            this.lblFechaInAuto.AutoSize = true;
            this.lblFechaInAuto.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.lblFechaInAuto.Location = new System.Drawing.Point(239, 22);
            this.lblFechaInAuto.Name = "lblFechaInAuto";
            this.lblFechaInAuto.Size = new System.Drawing.Size(185, 24);
            this.lblFechaInAuto.TabIndex = 3;
            this.lblFechaInAuto.Text = "20/11/2017 21:31:45";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(5, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(228, 24);
            this.label7.TabIndex = 2;
            this.label7.Text = "FECHA HORA DE INGRESO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(5, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "PLACA";
            // 
            // btn_LeerTI
            // 
            this.btn_LeerTI.AutoSize = true;
            this.btn_LeerTI.BackColor = System.Drawing.Color.Transparent;
            this.btn_LeerTI.FlatAppearance.BorderSize = 0;
            this.btn_LeerTI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_LeerTI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_LeerTI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LeerTI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LeerTI.Location = new System.Drawing.Point(526, 157);
            this.btn_LeerTI.LockPush = true;
            this.btn_LeerTI.Name = "btn_LeerTI";
            this.btn_LeerTI.Size = new System.Drawing.Size(105, 48);
            this.btn_LeerTI.TabIndex = 20;
            this.btn_LeerTI.Text = "B";
            this.btn_LeerTI.UseVisualStyleBackColor = false;
            this.btn_LeerTI.Click += new System.EventHandler(this.btn_LeerTI_Click);
            // 
            // btn_Pay
            // 
            this.btn_Pay.AutoSize = true;
            this.btn_Pay.BackColor = System.Drawing.Color.Transparent;
            this.btn_Pay.FlatAppearance.BorderSize = 0;
            this.btn_Pay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Pay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pay.Location = new System.Drawing.Point(942, 53);
            this.btn_Pay.LockPush = true;
            this.btn_Pay.Name = "btn_Pay";
            this.btn_Pay.Size = new System.Drawing.Size(182, 77);
            this.btn_Pay.TabIndex = 22;
            this.btn_Pay.Text = "B";
            this.btn_Pay.UseVisualStyleBackColor = false;
            this.btn_Pay.Click += new System.EventHandler(this.btn_Pay_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(958, 146);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(166, 24);
            this.label17.TabIndex = 23;
            this.label17.Text = "REGISTRAR SALIDA";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lblFechaPago);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.btn_LeerTI);
            this.groupBox4.Controls.Add(this.cbRepo);
            this.groupBox4.Controls.Add(this.cbCortesia);
            this.groupBox4.Controls.Add(this.cbCiclo);
            this.groupBox4.Controls.Add(this.lblTipoVehiculo);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.lblFechaEntrada);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.lblTipoTarjeta);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.lblIdTarjeta);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(6, 427);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(679, 230);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "INFORMACION DE LA TARJETA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(522, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "LEER TARJETA";
            // 
            // lblFechaPago
            // 
            this.lblFechaPago.AutoSize = true;
            this.lblFechaPago.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.lblFechaPago.Location = new System.Drawing.Point(187, 122);
            this.lblFechaPago.Name = "lblFechaPago";
            this.lblFechaPago.Size = new System.Drawing.Size(0, 24);
            this.lblFechaPago.TabIndex = 35;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label31.Location = new System.Drawing.Point(6, 122);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(174, 24);
            this.label31.TabIndex = 34;
            this.label31.Text = "FECHA HORA PAGO";
            // 
            // cbRepo
            // 
            this.cbRepo.AutoSize = true;
            this.cbRepo.Enabled = false;
            this.cbRepo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.cbRepo.Location = new System.Drawing.Point(280, 177);
            this.cbRepo.Name = "cbRepo";
            this.cbRepo.Size = new System.Drawing.Size(132, 28);
            this.cbRepo.TabIndex = 33;
            this.cbRepo.Text = "REPOSICION";
            this.cbRepo.UseVisualStyleBackColor = true;
            // 
            // cbCortesia
            // 
            this.cbCortesia.AutoSize = true;
            this.cbCortesia.Enabled = false;
            this.cbCortesia.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.cbCortesia.Location = new System.Drawing.Point(163, 177);
            this.cbCortesia.Name = "cbCortesia";
            this.cbCortesia.Size = new System.Drawing.Size(111, 28);
            this.cbCortesia.TabIndex = 32;
            this.cbCortesia.Text = "CORTESIA";
            this.cbCortesia.UseVisualStyleBackColor = true;
            // 
            // cbCiclo
            // 
            this.cbCiclo.AutoSize = true;
            this.cbCiclo.Enabled = false;
            this.cbCiclo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.cbCiclo.Location = new System.Drawing.Point(10, 177);
            this.cbCiclo.Name = "cbCiclo";
            this.cbCiclo.Size = new System.Drawing.Size(147, 28);
            this.cbCiclo.TabIndex = 31;
            this.cbCiclo.Text = "CICLO ACTIVO";
            this.cbCiclo.UseVisualStyleBackColor = true;
            // 
            // lblTipoVehiculo
            // 
            this.lblTipoVehiculo.AutoSize = true;
            this.lblTipoVehiculo.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.lblTipoVehiculo.Location = new System.Drawing.Point(153, 75);
            this.lblTipoVehiculo.Name = "lblTipoVehiculo";
            this.lblTipoVehiculo.Size = new System.Drawing.Size(0, 24);
            this.lblTipoVehiculo.TabIndex = 30;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label28.Location = new System.Drawing.Point(6, 75);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(141, 24);
            this.label28.TabIndex = 29;
            this.label28.Text = "TIPO VEHICULO";
            // 
            // lblFechaEntrada
            // 
            this.lblFechaEntrada.AutoSize = true;
            this.lblFechaEntrada.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.lblFechaEntrada.Location = new System.Drawing.Point(478, 75);
            this.lblFechaEntrada.Name = "lblFechaEntrada";
            this.lblFechaEntrada.Size = new System.Drawing.Size(0, 24);
            this.lblFechaEntrada.TabIndex = 26;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label24.Location = new System.Drawing.Point(266, 75);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(206, 24);
            this.label24.TabIndex = 25;
            this.label24.Text = "FECHA HORA ENTRADA";
            // 
            // lblTipoTarjeta
            // 
            this.lblTipoTarjeta.AutoSize = true;
            this.lblTipoTarjeta.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.lblTipoTarjeta.Location = new System.Drawing.Point(390, 37);
            this.lblTipoTarjeta.Name = "lblTipoTarjeta";
            this.lblTipoTarjeta.Size = new System.Drawing.Size(0, 24);
            this.lblTipoTarjeta.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(266, 37);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(123, 24);
            this.label20.TabIndex = 21;
            this.label20.Text = "TIPO TARJETA";
            // 
            // lblIdTarjeta
            // 
            this.lblIdTarjeta.AutoSize = true;
            this.lblIdTarjeta.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.lblIdTarjeta.Location = new System.Drawing.Point(108, 37);
            this.lblIdTarjeta.Name = "lblIdTarjeta";
            this.lblIdTarjeta.Size = new System.Drawing.Size(0, 24);
            this.lblIdTarjeta.TabIndex = 20;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(6, 37);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 24);
            this.label18.TabIndex = 19;
            this.label18.Text = "IDTARJETA";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::MC.ModuloManual.WinForm.FrontEnd.Properties.Resources.LOGO_PNG;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(6, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(213, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1251, 685);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btn_Pay);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modulo Manual B&P";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrHora;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel TsUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel TsFechaHora;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TsSistema;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TsAyuda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFechaIngresoIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPlaca;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblNombreAutorizado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbTipoAuto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPlacaAuto;
        private System.Windows.Forms.Label lblFechaInAuto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private CustomButton.CustomButton btn_RegistrarEntrada;
        private CustomButton.CustomButton btn_LeerTI;
        private System.Windows.Forms.Label label16;
        private CustomButton.CustomButton btn_Pay;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblFechaPago;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox cbRepo;
        private System.Windows.Forms.CheckBox cbCortesia;
        private System.Windows.Forms.CheckBox cbCiclo;
        private System.Windows.Forms.Label lblTipoVehiculo;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblFechaEntrada;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblTipoTarjeta;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblIdTarjeta;
        private System.Windows.Forms.Label label18;
        private CustomButton.CustomButton Btn_IngresoAuto;
        private System.Windows.Forms.Label label3;
        private CustomButton.CustomButton btn_LeerTIAuto;
        private System.Windows.Forms.Label label6;
    }
}