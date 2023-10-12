namespace AplicacionConvenios
{
    partial class frmCrear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrear));
            this.btn_Convenio = new System.Windows.Forms.Button();
            this.tbEstacionamiento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tblocal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Convenio
            // 
            this.btn_Convenio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Convenio.BackgroundImage")));
            this.btn_Convenio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Convenio.FlatAppearance.BorderSize = 0;
            this.btn_Convenio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Convenio.Location = new System.Drawing.Point(12, 31);
            this.btn_Convenio.Name = "btn_Convenio";
            this.btn_Convenio.Size = new System.Drawing.Size(132, 124);
            this.btn_Convenio.TabIndex = 5;
            this.btn_Convenio.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btn_Convenio.UseVisualStyleBackColor = true;
            // 
            // tbEstacionamiento
            // 
            this.tbEstacionamiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbEstacionamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEstacionamiento.Location = new System.Drawing.Point(412, 80);
            this.tbEstacionamiento.MaxLength = 80;
            this.tbEstacionamiento.Multiline = true;
            this.tbEstacionamiento.Name = "tbEstacionamiento";
            this.tbEstacionamiento.Size = new System.Drawing.Size(244, 20);
            this.tbEstacionamiento.TabIndex = 2;
            this.tbEstacionamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(159, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "NOMBRE DE ESTACIONAMIENTO";
            // 
            // tblocal
            // 
            this.tblocal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblocal.Location = new System.Drawing.Point(412, 54);
            this.tblocal.MaxLength = 80;
            this.tblocal.Multiline = true;
            this.tblocal.Name = "tblocal";
            this.tblocal.Size = new System.Drawing.Size(244, 20);
            this.tblocal.TabIndex = 0;
            this.tblocal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Menu;
            this.label2.Location = new System.Drawing.Point(159, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "NOMBRE DE MARCA O LOCAL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Menu;
            this.label5.Location = new System.Drawing.Point(642, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Guardar";
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.BackgroundImage")));
            this.btn_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Guardar.FlatAppearance.BorderSize = 0;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Location = new System.Drawing.Point(649, 120);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(53, 58);
            this.btn_Guardar.TabIndex = 3;
            this.btn_Guardar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // frmCrear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(714, 214);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.tbEstacionamiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tblocal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Convenio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCrear";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CREACION DE ESTABLECIMIENTO";
            this.Load += new System.EventHandler(this.frmCrear_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Convenio;
        private System.Windows.Forms.TextBox tbEstacionamiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tblocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Guardar;
    }
}