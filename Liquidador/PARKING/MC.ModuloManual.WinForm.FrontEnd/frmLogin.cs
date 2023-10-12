using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC.ModuloManual.WinForm.FrontEnd
{
    public partial class frmLogin : Form
    {
        public static SqlConnection conexionSQL = new SqlConnection();
        public static SqlCommand comandoSQL = new SqlCommand();
        public static string sSerial
        {
            get
            {
                string sIdeModulo = ConfigurationManager.AppSettings["serial"];
                if (!string.IsNullOrEmpty(sIdeModulo))
                {
                    return sIdeModulo;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string Pass = string.Empty;

        #region EvenetosFormulario
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        #endregion

        #region General
        private async Task Inicio()
        {
            if (CargaRecursos())
            {
                if (CargaImagenes())
                {

                    string data = @"" + sSerial + "";
                    conexionSQL.ConnectionString = data;
                }
            }

        }
        private bool CargaRecursos()
        {
            bool ok = false;

            try
            {
                tbUser.Focus();
                btn_Cerrar.LockPush = false;
                btn_Cerrar.Text = string.Empty;
                CapaLogin.Text = string.Empty;
               

                ok = true;

                //General_Events = "(FrondEnd CargaRecursos): Carga Controles - OK";
            }
            catch (Exception ex)
            {
                //General_Events = "Error (FrondEnd CargaRecursos): al cargar recursos. " + ex.ToString();
            }

            return ok;
        }
        private bool CargaImagenes()
        {
            bool ok = false;

            try
            {
                #region Imagenes
                /// Carga Imagenes Flujo
                /// 
                //Img_LogoEmpresa.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Img_Empresa.jpg"));

                #endregion

                #region Botones
                /// Carga botones
                btn_Cerrar.ImageSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_IconoCancelar.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_IconoCancelar.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_IconoCancelar.png"));

                #endregion

                this.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Imagen_Login.PNG"));
                this.Icon = new System.Drawing.Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Ico\Imagen_Parquearse.ico"));

                ok = true;

                //General_Events = "(FrondEnd CargaImagenes): Carga Imagenes - OK";
            }
            catch (Exception ex)
            {
                //General_Events = "Error (FrondEnd CargaImagenes): al cargar imagenes. " + ex.ToString();
            }

            return ok;
        }
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        #endregion

        #region Botones
        private void CapaLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbUser.Text != string.Empty)
                {
                    if (tbPass.Text != string.Empty)
                    {

                        string Us = tbUser.Text;
                        string Ps = tbPass.Text;
                        Pass = string.Empty;

                        conexionSQL.Open();

                        SqlDataReader myReader = null;
                        string strCadSQL = "SELECT CONTRASEÑA FROM T_USUARIOS WHERE USUARIO = '" + Us + "'";
                        SqlCommand myCommand = new SqlCommand(strCadSQL, conexionSQL);

                        //Ejecutar el comando SQL
                        myReader = myCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            if (Environment.UserInteractive)
                                Console.WriteLine("Devuelve datos");

                            Pass = myReader["Contraseña"].ToString();
                        }

                        conexionSQL.Close();


                        if (Decrypt(Pass) == tbPass.Text)
                        {
                            this.Hide();
                            frmPrincipal newMDIChild = new frmPrincipal();
                            newMDIChild.ShowDialog();
                            if (newMDIChild.DialogResult == System.Windows.Forms.DialogResult.Abort)
                            {
                                this.Show();
                                tbUser.Focus();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos, por favor intentelo de nuevo", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbUser.Text = string.Empty;
                            tbPass.Text = string.Empty;
                            tbUser.Focus();
                        }                        
                    }
                    else 
                    {
                        MessageBox.Show("Debe digitar una contraseña", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {
                    MessageBox.Show("Debe digitar un usuario", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region EventosControles
        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    if (tbUser.Text != string.Empty)
                    {
                        if (tbPass.Text != string.Empty)
                        {

                            string Us = tbUser.Text;
                            string Ps = tbPass.Text;
                            Pass = string.Empty;

                            conexionSQL.Open();

                            SqlDataReader myReader = null;
                            string strCadSQL = "SELECT CONTRASEÑA FROM T_USUARIOS WHERE USUARIO = '" + Us + "'";
                            SqlCommand myCommand = new SqlCommand(strCadSQL, conexionSQL);

                            //Ejecutar el comando SQL
                            myReader = myCommand.ExecuteReader();

                            while (myReader.Read())
                            {
                                if (Environment.UserInteractive)
                                    Console.WriteLine("Devuelve datos");

                                Pass = myReader["Contraseña"].ToString();
                            }

                            conexionSQL.Close();


                            if (Decrypt(Pass) == tbPass.Text)
                            {
                                this.Hide();
                                frmPrincipal newMDIChild = new frmPrincipal();
                                newMDIChild.ShowDialog();
                                if (newMDIChild.DialogResult == System.Windows.Forms.DialogResult.Abort)
                                {
                                    this.Show();
                                    tbUser.Focus();
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos, por favor intentelo de nuevo", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbUser.Text = string.Empty;
                                tbPass.Text = string.Empty;
                                tbUser.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe digitar una contraseña", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe digitar un usuario", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        #endregion

    }
}
