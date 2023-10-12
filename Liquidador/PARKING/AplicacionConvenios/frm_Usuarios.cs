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
    public partial class frm_Usuarios : Form
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

        public frm_Usuarios()
        {
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Validaciones())
                {
                    conexionSQL.ConnectionString = data1;

                    conexionSQL.Open();

                    string textoCmd = "INSERT INTO T_USUARIOS (Documento,Usuario,Clave,MontoMaximo,Cargo,Estado) values('"
                          + tbDocumento.Text + "','" + tbUsuario.Text + "','" + tbClave.Text + "'," + tbMontoMaximo.Text +",'" + cbCargo.Text + "'," + 1 + ")";

                    SqlCommand InsertData = new SqlCommand(textoCmd, conexionSQL);
                    InsertData = new SqlCommand(textoCmd, conexionSQL);
                    InsertData.ExecuteNonQuery();

                    conexionSQL.Close();
                    
                    MessageBox.Show("Usuario guardado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbClave.Text = string.Empty;
                    tbDocumento.Text = string.Empty;
                    tbUsuario.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los campos para poder guardar", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar crear el usuario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool Validaciones()
        {
            bool ok = false;

            if (tbClave.Text != string.Empty)
            {
                if (tbDocumento.Text != string.Empty)
                {
                    if(tbUsuario.Text != string.Empty)
                    {
                        if (cbCargo.Text != string.Empty)
                        {
                            if (tbMontoMaximo.Text != string.Empty)
                            {
                                ok = true;
                            }
                        }
                    }
                }
            }


            return ok;
        }

        private void frm_Usuarios_Load(object sender, EventArgs e)
        {
            tbDocumento.Focus();
        }
    }
}
