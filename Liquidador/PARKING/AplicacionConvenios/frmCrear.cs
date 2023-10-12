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
    public partial class frmCrear : Form
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
        public string _UsuarioLogin = string.Empty;
        public frmCrear(string usuario)
        {
            _UsuarioLogin = usuario;
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                conexionSQL.ConnectionString = data1;

                conexionSQL.Open();

                string textoCmd = "INSERT INTO T_INFO (Nombre,Estacionamiento,HorasActualesCarro,HorasActualesMoto,UsuarioUltimoCargue,FechaUltimoCargue) values('"
                      + tblocal.Text + "','" + tbEstacionamiento.Text + "','" + 0 + "','" + 0 + "','" + _UsuarioLogin + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "')";

                SqlCommand InsertData = new SqlCommand(textoCmd, conexionSQL);
                InsertData = new SqlCommand(textoCmd, conexionSQL);
                InsertData.ExecuteNonQuery();

                conexionSQL.Close();

                MessageBox.Show("Datos guardados correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbEstacionamiento.Text = string.Empty;
                tblocal.Text = string.Empty;
                this.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Error al registrar datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbEstacionamiento.Text = string.Empty;
                tblocal.Text = string.Empty;
                this.Close();

            }

        }

        private void frmCrear_Load(object sender, EventArgs e)
        {
            tblocal.Focus();
        }
    }
}
