using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloCascos
{
    public partial class frmCobroCascos : Form
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
        public string _Cargo = string.Empty;
        int ctn = 0;
        public frmCobroCascos(string UsuarioLogin, string Cargo)
        {
            _Cargo = Cargo;
            _UsuarioLogin = UsuarioLogin;
            InitializeComponent();
        }
        private void frmCobroCascos_Load(object sender, EventArgs e)
        {
            try
            {
                TsUsuario.Text = "Usuario: " + _UsuarioLogin;
                TsCargo.Text = "Cargo: " + _Cargo;

                lblPlaca.Text = string.Empty;
                lblCasillero.Text = string.Empty;
                lblFechaEntrada.Text = string.Empty;
                lblValorPagar.Text = string.Empty;
                tbCasillero.Text = string.Empty;
                tbAsignarCasillero.Text = string.Empty;
                tmrHora.Enabled = true;
                btn_Arqueos.Enabled = true;
                btn_Reporte.Enabled = false;

                if (_Cargo == "ADMINISTRADOR")
                {
                    btn_uSUARIO.Enabled = true;
                    btn_Reporte.Enabled = true;
                    //btn_Arqueos.Enabled = true;
                }

                conexionSQL.ConnectionString = data1;
            }
            catch (Exception)
            {
                MessageBox.Show(Owner, "ERROR AL OBTENER INFORMACION DEL ESTABLECIMIENTO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btn_uSUARIO_Click(object sender, EventArgs e)
        {
            frm_Usuarios oUsuarios = new frm_Usuarios();
            oUsuarios.ShowDialog();
        }

        private void btn_Entrada_Click(object sender, EventArgs e)
        {
            if (tbPlaca.Text != string.Empty)
            {

                if (tbAsignarCasillero.Text != string.Empty)
                {
                    string IdMovimiento = string.Empty;

                    conexionSQL.Open();

                    //Formar la sentencia SQL, un SELECT en este caso
                    SqlDataReader myReader1 = null;
                    string strCadSQL1 = "SELECT IDMOVIMIENTO FROM  T_Movimientos WHERE ValorCobro IS NULL AND CASILLERO = '" + tbAsignarCasillero.Text + "'";
                    SqlCommand myCommand1 = new SqlCommand(strCadSQL1, conexionSQL);

                    //Ejecutar el comando SQL
                    myReader1 = myCommand1.ExecuteReader();

                    while (myReader1.Read())
                    {
                        IdMovimiento = myReader1["IdMovimiento"].ToString();
                    }

                    conexionSQL.Close();

                    if (IdMovimiento == string.Empty)
                    {

                        conexionSQL.Open();

                        string textoCmd = "INSERT INTO T_Movimientos (Modulo,FechaEntrada,Placa,Casillero,Usuario,FechaPago,ValorCobro,Iva,Subtotal) values('" +
                        "MODULOCASCO" + "','" + DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "','" + tbPlaca.Text + "','" + tbAsignarCasillero.Text + "','" + _UsuarioLogin + "'," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL" + ")";

                        SqlCommand InsertData = new SqlCommand(textoCmd, conexionSQL);
                        InsertData = new SqlCommand(textoCmd, conexionSQL);
                        InsertData.ExecuteNonQuery();

                        conexionSQL.Close();

                        MessageBox.Show(Owner, "REGISTRO CREADO CORRECTAMENTE", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        string MOV = string.Empty;

                        conexionSQL.Open();

                        //Formar la sentencia SQL, un SELECT en este caso
                        SqlDataReader myReader = null;
                        string strCadSQL = "SELECT TOP 1 IdMovimiento FROM T_Movimientos where fechapago is null and Casillero = '" + tbAsignarCasillero.Text + "'";
                        SqlCommand myCommand = new SqlCommand(strCadSQL, conexionSQL);

                        //Ejecutar el comando SQL
                        myReader = myCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            if (Environment.UserInteractive)
                                Console.WriteLine("Devuelve datos reclamo");

                            MOV = myReader["IdMovimiento"].ToString();
                        }

                        conexionSQL.Close();

                        tbAsignarCasillero.Text = string.Empty;
                        tbPlaca.Text = string.Empty;

                        TicketEntrada popup = new TicketEntrada(Convert.ToInt64(MOV));
                        popup.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show(Owner, "EL CASILLERO SE ENCUENTRA OCUPADO SELECCIONE OTRO CASILLERO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbAsignarCasillero.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show(Owner, "EL CASILLERO NO PUEDE ESTAR VACIO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbAsignarCasillero.Text = string.Empty;
                    tbPlaca.Text = string.Empty;
                }
            }
            else 
            {
                MessageBox.Show(Owner, "LA PLACA NO PUEDE ESTAR VACIA", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbAsignarCasillero.Text = string.Empty;
                tbPlaca.Text = string.Empty;
            }
        }

        private void btn_Pagar_Click(object sender, EventArgs e)
        {
            //conexionSQL.Open();
            if (tbCasillero.Text != string.Empty)
            {
                double VALOR = Convert.ToInt64(lblValorPagar.Text.Replace("$", "").Replace(".", ""));
                double SUBTOTAL = Math.Round(VALOR / 1.19, 0);
                double IVA = VALOR - SUBTOTAL;
                double TOTAL = VALOR;


                double ValorTotal = VALOR;
                double Iva = IVA;
                double Subtotal = SUBTOTAL;

                string MOV = string.Empty;
                string NUMFAC = string.Empty;

                conexionSQL.Open();

                //Formar la sentencia SQL, un SELECT en este caso
                SqlDataReader myReader = null;
                string strCadSQL = "SELECT TOP 1 FactActu FROM T_Configuracion";
                SqlCommand myCommand = new SqlCommand(strCadSQL, conexionSQL);

                //Ejecutar el comando SQL
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    if (Environment.UserInteractive)
                        Console.WriteLine("Devuelve datos reclamo");

                    NUMFAC = myReader["FactActu"].ToString();
                }

                conexionSQL.Close();

                /////////////////////////////////////////////////////////////////

                conexionSQL.Open();

                //Formar la sentencia SQL, un SELECT en este caso
                myReader = null;
                strCadSQL = "SELECT TOP 1 IdMovimiento FROM T_Movimientos where fechapago is null and Casillero = '" + tbCasillero.Text + "'";
                myCommand = new SqlCommand(strCadSQL, conexionSQL);

                //Ejecutar el comando SQL
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    if (Environment.UserInteractive)
                        Console.WriteLine("Devuelve datos reclamo");

                    MOV = myReader["IdMovimiento"].ToString();
                }

                conexionSQL.Close();


                int RESULFACT = Convert.ToInt32(NUMFAC) + 1;

                conexionSQL.Open();

                string textoCmd = "UPDATE T_Movimientos SET FechaPago = '" + DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "', ValorCobro = " + ValorTotal + ", Iva = " + Iva + ", Subtotal = " + Subtotal + ", NumeroFactura = " + RESULFACT + " WHERE IdMovimiento = " + MOV;

                SqlCommand InsertData = new SqlCommand(textoCmd, conexionSQL);
                InsertData = new SqlCommand(textoCmd, conexionSQL);
                InsertData.ExecuteNonQuery();

                conexionSQL.Close();

                conexionSQL.Open();

                string textoCmd2 = "UPDATE T_Configuracion SET FactActu =" +  RESULFACT;

                SqlCommand InsertData2 = new SqlCommand(textoCmd2, conexionSQL);
                InsertData2 = new SqlCommand(textoCmd2, conexionSQL);
                InsertData2.ExecuteNonQuery();

                conexionSQL.Close();


                //IMPRIMIR

               
                TicketCasco popup = new TicketCasco(Convert.ToInt64(MOV));
                popup.ShowDialog();

                lblFechaEntrada.Text = string.Empty;
                lblValorPagar.Text = string.Empty;
                lblCasillero.Text = string.Empty;
                tbCasillero.Text = string.Empty;
                lblPlaca.Text = string.Empty;
            }
        }
        
        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            conexionSQL.ConnectionString = data1;

            string FechaEntrada = string.Empty;
            string IdMovimiento = string.Empty;
            string Placa = string.Empty;

            conexionSQL.Open();

            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader1 = null;
            string strCadSQL1 = "SELECT IDMOVIMIENTO, FECHAENTRADA,PLACA FROM  T_Movimientos WHERE VALORCOBRO IS NULL AND CASILLERO = '" + tbCasillero.Text + "'";
            SqlCommand myCommand1 = new SqlCommand(strCadSQL1, conexionSQL);

            //Ejecutar el comando SQL
            myReader1 = myCommand1.ExecuteReader();

            while (myReader1.Read())
            {
                IdMovimiento = myReader1["IdMovimiento"].ToString();
                FechaEntrada = myReader1["FechaEntrada"].ToString();
                Placa = myReader1["Placa"].ToString();
            }

            conexionSQL.Close();

            if (IdMovimiento != string.Empty)
            {
                string ValorCobro = string.Empty;
                conexionSQL.Open();

                //Formar la sentencia SQL, un SELECT en este caso
                myReader1 = null;
                strCadSQL1 = "SELECT top 1 ValorCobro FROM  T_Configuracion";
                myCommand1 = new SqlCommand(strCadSQL1, conexionSQL);

                //Ejecutar el comando SQL
                myReader1 = myCommand1.ExecuteReader();

                while (myReader1.Read())
                {
                    ValorCobro = myReader1["ValorCobro"].ToString();
                }

                conexionSQL.Close();

                lblFechaEntrada.Text = FechaEntrada;
                lblCasillero.Text = tbCasillero.Text;
                lblPlaca.Text = Placa;
                lblValorPagar.Text = "$" + String.Format("{0:#,##0.##}", Convert.ToDouble(ValorCobro.Replace("$", "").Replace(".", "")));
            }
            else 
            {
                MessageBox.Show(Owner, "NO SE ENCONTRARON REGISTROS ACTIVOS PARA ESTE CASILLERO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void tmrHora_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            ctn++;
            if (ctn == 30)
            {
                ctn= 0;
 
            }
            
        }

        private void btn_Arqueos_Click(object sender, EventArgs e)
        {

            string Total = string.Empty;
            string FechaInicio = string.Empty;
            conexionSQL.Open();

            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            string strCadSQL = "SELECT top 1 FechaInicio FROM T_Arqueos order by FechaInicio DESC";
            SqlCommand myCommand = new SqlCommand(strCadSQL, conexionSQL);

            //Ejecutar el comando SQL
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                if (Environment.UserInteractive)
                    Console.WriteLine("Devuelve datos reclamo");

                FechaInicio = myReader["FechaInicio"].ToString();
            }

            conexionSQL.Close();

            //////////////////////////////////////////////////////////////////////////////////////////////////////777
            if (FechaInicio != string.Empty)
            {


                conexionSQL.Open();

                //2018-12-18 16:36:59.680
                DateTime FECHA = Convert.ToDateTime(FechaInicio);
                int AÑO = FECHA.Year;
                int MES = FECHA.Month;
                int DIA = FECHA.Day;

                int HORA = FECHA.Hour;
                int MINUTO = FECHA.Minute;
                int SEGUNDO = FECHA.Second;

                //Formar la sentencia SQL, un SELECT en este caso
                myReader = null;
                strCadSQL = "SELECT sum(ValorCobro) as ValorCobro FROM T_Movimientos WHERE FechaPago BETWEEN '" + AÑO + "/" + DIA + "/" + MES + " " + HORA + ":" + MINUTO + ":" + SEGUNDO + "' AND GETDATE() ";
                myCommand = new SqlCommand(strCadSQL, conexionSQL);

                //Ejecutar el comando SQL
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    if (Environment.UserInteractive)
                        Console.WriteLine("Devuelve datos reclamo");

                    Total = myReader["ValorCobro"].ToString();
                }

                conexionSQL.Close();

            }
            else
            {

                conexionSQL.Open();

                //Formar la sentencia SQL, un SELECT en este caso
                myReader = null;
                strCadSQL = "SELECT sum(ValorCobro) as ValorCobro FROM T_Movimientos WHERE FechaPago BETWEEN DATEADD(MM,-2,GETDATE()) AND GETDATE() ";
                myCommand = new SqlCommand(strCadSQL, conexionSQL);

                //Ejecutar el comando SQL
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    if (Environment.UserInteractive)
                        Console.WriteLine("Devuelve datos reclamo");

                    Total = myReader["ValorCobro"].ToString();
                }

                conexionSQL.Close();
            }


            if (Total == string.Empty)
            {
                Total = "0";
            }

            conexionSQL.Open();

            string textoCmd1 = "INSERT INTO T_ARQUEOS (FechaInicio, Valor, Usuario, Modulo) values('"
            + DateTime.Now.ToString("yyyy/dd/MM HH:mm:ss") + "','" + Total + "','" + _UsuarioLogin + "','" + "MODULOCASCO" + "')";

            SqlCommand InsertData1 = new SqlCommand(textoCmd1, conexionSQL);
            InsertData1 = new SqlCommand(textoCmd1, conexionSQL);
            InsertData1.ExecuteNonQuery();

            conexionSQL.Close();


            //IMPRIMIR


            string MOV = string.Empty;

            conexionSQL.Open();

            //Formar la sentencia SQL, un SELECT en este caso
            myReader = null;
            strCadSQL = "SELECT TOP 1 IdArqueo FROM T_Arqueos ORDER BY FechaInicio DESC";
            myCommand = new SqlCommand(strCadSQL, conexionSQL);

            //Ejecutar el comando SQL
            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                if (Environment.UserInteractive)
                    Console.WriteLine("Devuelve datos reclamo");

                MOV = myReader["IdArqueo"].ToString();
            }

            conexionSQL.Close();


            TicketArqueo popup = new TicketArqueo(Convert.ToInt64(MOV));
            popup.ShowDialog();

        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {

            frmReports popup = new frmReports();
            popup.ShowDialog();
        }

    }
}
