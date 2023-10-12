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
    public partial class frmCargue : Form
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

        public frmCargue(string usuario)
        {
            _UsuarioLogin = usuario;
            InitializeComponent();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            conexionSQL.ConnectionString = data1;

            string HorasCarro = string.Empty;
            string HorasMoto = string.Empty;


            conexionSQL.Open();

            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader1 = null;
            string strCadSQL1 = "SELECT HorasActualesCarro,HorasActualesMoto FROM  T_Info";
            SqlCommand myCommand1 = new SqlCommand(strCadSQL1, conexionSQL);

            //Ejecutar el comando SQL
            myReader1 = myCommand1.ExecuteReader();

            while (myReader1.Read())
            {
                HorasCarro = myReader1["HorasActualesCarro"].ToString();
                HorasMoto = myReader1["HorasActualesMoto"].ToString();
            }

            conexionSQL.Close();


            conexionSQL.Open();

            if (HorasCarro == string.Empty)
            {
                HorasCarro = "0";
            }
            if (HorasMoto == string.Empty)
            {
                HorasMoto = "0";
            }
            if (tbHorasCargue.Text == string.Empty)
            {
                tbHorasCargue.Text = "0";
            }
            if (tbHorasCargueMoto.Text == string.Empty)
            {
                tbHorasCargueMoto.Text = "0";
            }



            int finalCarro = Convert.ToInt32(HorasCarro) + Convert.ToInt32(tbHorasCargue.Text);
            int finalMoto = Convert.ToInt32(HorasMoto) + Convert.ToInt32(tbHorasCargueMoto.Text);


            string textoCmd = "UPDATE T_INFO SET HORASACTUALESCARRO =" + finalCarro + ", HORASACTUALESMOTO = " + finalMoto;

            SqlCommand InsertData = new SqlCommand(textoCmd, conexionSQL);
            InsertData = new SqlCommand(textoCmd, conexionSQL);
            InsertData.ExecuteNonQuery();

            conexionSQL.Close();

            MessageBox.Show("Cargue realizado correctamente le quedan " + finalCarro + " horas disponibles carro y "+ finalMoto + " horas disponibles moto", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbHorasCargue.Text = string.Empty;
            tbHorasCargueMoto.Text = string.Empty;
            lblActuales.Text = finalCarro + " Horas disponibles carro y " + finalMoto + " Horas disponibles moto"; 
        }

        private void frmCargue_Load(object sender, EventArgs e)
        {
            conexionSQL.ConnectionString = data1;

            string HorasCarro = string.Empty;
            string HorasMoto = string.Empty;

            conexionSQL.Open();

            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader1 = null;
            string strCadSQL1 = "SELECT HorasActualesCarro,HorasActualesMoto FROM  T_Info";
            SqlCommand myCommand1 = new SqlCommand(strCadSQL1, conexionSQL);

            //Ejecutar el comando SQL
            myReader1 = myCommand1.ExecuteReader();

            while (myReader1.Read())
            {
                HorasCarro = myReader1["HorasActualesCarro"].ToString();
                HorasMoto = myReader1["HorasActualesMoto"].ToString();
            }

            conexionSQL.Close();

            if (HorasCarro == string.Empty)
            {
                HorasCarro = "0";
            }
            if (HorasMoto == string.Empty)
            {
                HorasMoto = "0";
            }

            lblActuales.Text = HorasCarro + " Horas disponibles carro y "+ HorasMoto + " Horas disponibles moto"; 
        }
    }
}
