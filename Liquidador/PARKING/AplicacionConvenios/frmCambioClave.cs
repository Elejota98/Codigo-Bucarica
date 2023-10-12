using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionConvenios
{
    public partial class frmCambioClave : Form
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
        public string data1 = @"" + sSerial + "";

        public frmCambioClave()
        {
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbclavenueva.Text != string.Empty)
                {
                    conexionSQL.ConnectionString = data1;

                    conexionSQL.Open();

                    string textoCmd = "UPDATE T_USUARIOS SET CLAVE = '" + tbclavenueva.Text + "' WHERE DOCUMENTO = '" + tbdocumento.Text + "'";

                    SqlCommand InsertData = new SqlCommand(textoCmd, conexionSQL);
                    InsertData = new SqlCommand(textoCmd, conexionSQL);
                    InsertData.ExecuteNonQuery();

                    conexionSQL.Close();
                    MessageBox.Show("Cambio de clave realizado correctamente", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    MessageBox.Show("Debe digitar la contraseña nueva", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al realizar cambio de clave", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
    }
}
