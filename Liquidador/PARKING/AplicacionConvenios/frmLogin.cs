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
        public string data1 = @"" + sSerial + "";
                
        public frmLogin()
        {
            InitializeComponent();            
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (tbUser.Text != string.Empty && tbPass.Text != string.Empty)
            {

                conexionSQL.ConnectionString = data1;
                string User = string.Empty;
                string Pass = string.Empty;
                string Cargo = string.Empty;
                string Estado = string.Empty;
                string MontoMax = string.Empty;
                conexionSQL.Open();

                //Formar la sentencia SQL, un SELECT en este caso
                SqlDataReader myReader1 = null;
                string strCadSQL1 = "SELECT Documento,Usuario,Clave, Estado,Cargo,MontoMaximo FROM  T_Usuarios WHERE  Usuario = '" + tbUser.Text + "' AND CLAVE = '" + tbPass.Text + "'";
                SqlCommand myCommand1 = new SqlCommand(strCadSQL1, conexionSQL);

                //Ejecutar el comando SQL
                myReader1 = myCommand1.ExecuteReader();

                while (myReader1.Read())
                {
                    User = myReader1["Usuario"].ToString();
                    Pass = myReader1["Clave"].ToString();
                    Cargo = myReader1["Cargo"].ToString();
                    Estado = myReader1["Estado"].ToString();
                    MontoMax = myReader1["MontoMaximo"].ToString();
                }

                conexionSQL.Close();

                if (MontoMax == string.Empty)
                {
                    MontoMax = "0";
                }

                if (Estado == "True")
                {
                    frmPrincipal oPrincipal = new frmPrincipal(User,Cargo,MontoMax);
                    tbUser.Text = string.Empty;
                    tbPass.Text = string.Empty;

                    this.Hide();
                    oPrincipal.ShowDialog();
                    if (oPrincipal.DialogResult == System.Windows.Forms.DialogResult.Abort)
                    {
                        this.Close();
                    }
                    else if (oPrincipal.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        this.Show();
                        tbUser.Text = string.Empty;
                        tbPass.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña invalidos", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbUser.Text = string.Empty;
                    tbPass.Text = string.Empty;
                }
            }
            else 
            {
                MessageBox.Show("Debe digitar un usuario y contraseña validos", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbUser.Text = string.Empty;
                tbPass.Text = string.Empty;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            tbUser.Focus();
        }

        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (tbUser.Text != string.Empty && tbPass.Text != string.Empty)
                {

                    conexionSQL.ConnectionString = data1;
                    string User = string.Empty;
                    string Pass = string.Empty;
                    string Cargo = string.Empty;
                    string Estado = string.Empty;
                    string MontoMax = string.Empty;
                    conexionSQL.Open();

                    //Formar la sentencia SQL, un SELECT en este caso
                    SqlDataReader myReader1 = null;
                    string strCadSQL1 = "SELECT Documento,Usuario,Clave, Estado,Cargo,MontoMaximo FROM  T_Usuarios WHERE  Usuario = '" + tbUser.Text + "' AND CLAVE = '" + tbPass.Text + "'";
                    SqlCommand myCommand1 = new SqlCommand(strCadSQL1, conexionSQL);

                    //Ejecutar el comando SQL
                    myReader1 = myCommand1.ExecuteReader();

                    while (myReader1.Read())
                    {
                        User = myReader1["Usuario"].ToString();
                        Pass = myReader1["Clave"].ToString();
                        Cargo = myReader1["Cargo"].ToString();
                        Estado = myReader1["Estado"].ToString();
                        MontoMax = myReader1["MontoMaximo"].ToString();
                    }

                    conexionSQL.Close();

                    if (MontoMax == string.Empty)
                    {
                        MontoMax = "0";
                    }

                    if (Estado == "True")
                    {
                        frmPrincipal oPrincipal = new frmPrincipal(User, Cargo, MontoMax);
                        tbUser.Text = string.Empty;
                        tbPass.Text = string.Empty;

                        this.Hide();
                        oPrincipal.ShowDialog();
                        if (oPrincipal.DialogResult == System.Windows.Forms.DialogResult.Abort)
                        {
                            this.Close();
                        }
                        else if (oPrincipal.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                        {
                            this.Show();
                            tbUser.Text = string.Empty;
                            tbPass.Text = string.Empty;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña invalidos", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbUser.Text = string.Empty;
                        tbPass.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Debe digitar un usuario y contraseña validos", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbUser.Text = string.Empty;
                    tbPass.Text = string.Empty;
                }
            }
        }

        private void btn_CambioClave_Click(object sender, EventArgs e)
        {
            frmCambioClave oCargue = new frmCambioClave();
            oCargue.ShowDialog();
        }
    }
}
