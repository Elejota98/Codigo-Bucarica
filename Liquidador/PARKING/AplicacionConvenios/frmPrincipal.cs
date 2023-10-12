using CSharpPCSC;
using GS.Apdu;
using GS.Util.Hex;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
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
    public partial class frmPrincipal : Form
    {
        public static string sKEY
        {
            get
            {
                string sKEY = ConfigurationManager.AppSettings["KEY"];
                if (!string.IsNullOrEmpty(sKEY))
                {
                    return sKEY;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string sLOAD
        {
            get
            {
                string sLOAD = ConfigurationManager.AppSettings["LOAD"];
                if (!string.IsNullOrEmpty(sLOAD))
                {
                    return sLOAD;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public int TipoVehiculo = 0;
        public int AcumuladoHoras = 0;
        int ctn = 0;
        string IdEstablecimiento = string.Empty;
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
        public string _MontoMax = string.Empty;
        PCSCReader reader = new PCSCReader();
        public static SqlConnection conexionSQL = new SqlConnection();
        public static SqlCommand comandoSQL = new SqlCommand();
        public frmPrincipal(string UsuarioLogin, string Cargo, string MontoMax)
        {
            _MontoMax = MontoMax;
            _Cargo = Cargo;
            _UsuarioLogin = UsuarioLogin;
            InitializeComponent();
        }
        private void tmrHora_Tick(object sender, EventArgs e)
        {
            lblFechaACtual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            if (pAplicarDescuento.Visible)
            {
                ctn++;

                if (ctn == 30)
                {
                    reader.Disconnect();
                    pAplicarDescuento.Visible = false;
                    tbHoras.Text = string.Empty;
                    lblFechaEntrada.Text = string.Empty;
                    lblIdTarjeta.Text = string.Empty;
                    lblTipoVehiculo.Text = string.Empty;
                    ctn = 0;
                }
            }
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                conexionSQL.ConnectionString = data1;
                IdEstablecimiento = string.Empty;
                string Nombre = string.Empty;
                string HorasActualesCarro = string.Empty;
                string HorasActualesMoto = string.Empty;
                conexionSQL.Open();

                //Formar la sentencia SQL, un SELECT en este caso
                SqlDataReader myReader1 = null;
                string strCadSQL1 = "SELECT IdEstablecimiento,Nombre,HorasActualesCarro,HorasActualesMoto FROM T_Info";
                SqlCommand myCommand1 = new SqlCommand(strCadSQL1, conexionSQL);

                //Ejecutar el comando SQL
                myReader1 = myCommand1.ExecuteReader();

                while (myReader1.Read())
                {
                    IdEstablecimiento = myReader1["IdEstablecimiento"].ToString();
                    Nombre = myReader1["Nombre"].ToString();
                    HorasActualesCarro = myReader1["HorasActualesCarro"].ToString();
                    HorasActualesMoto = myReader1["HorasActualesMoto"].ToString();
                }

                conexionSQL.Close();

                if (IdEstablecimiento != string.Empty)
                {

                    lblFechaEntrada.Text = string.Empty;
                    lblIdTarjeta.Text = string.Empty;
                    lblTipoVehiculo.Text = string.Empty;
                    tmrHora.Enabled = true;
                    TsUsuario.Text = "Usuario: " + _UsuarioLogin;
                    TsCargo.Text = "Cargo: " + _Cargo;
                    tbHoras.Text = string.Empty;
                    tsEstable.Text = "Establecimiento: "+  Nombre;
                    if (_Cargo == "ADMINISTRADOR")
                    {
                        btn_uSUARIO.Enabled = true;
                        btn_Reports.Enabled = true;
                        btn_Cargue.Enabled = true;
                    }

                }
                else
                {
                    
                    if (_Cargo == "ADMINISTRADOR")
                    {
                        MessageBox.Show(Owner, "DEBE INGRESAR POR PRIMERA VEZ LOS DATOS DEL ESTABLECIMIENTO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmCrear OCARG = new frmCrear(_UsuarioLogin);
                        OCARG.ShowDialog();
                        this.Close();
                    }
                    else 
                    {
                        MessageBox.Show(Owner, "DEBE INGRESAR POR PRIMERA VEZ LOS DATOS DEL ESTABLECIMIENTO \nPOR FAVOR INFORME A UN USUARIO ADMINISTRADOR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show(Owner, "ERROR AL OBTENER INFORMACION DEL ESTABLECIMIENTO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrHora.Enabled = false;
        }
        private void btn_LeerTarjeta_Click(object sender, EventArgs e)
        {
            try
            {
                string IdCard = string.Empty;
                TipoVehiculo = 0;

                ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

                oResultadoOperacion = reader.Connect();

                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    oResultadoOperacion = reader.ActivateCard();

                    RespApdu respApdu = reader.Exchange("FF CA 00 00 00"); // Get Card UID ...
                    if (respApdu.SW1SW2 == 0x9000)
                    {
                        IdCard = HexFormatting.ToHexString(respApdu.Data, false);
                    }


                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        if (sKEY != string.Empty)
                        {
                            bool sigue = false;
                            
                            if (sLOAD == "SI")
                            {

                                respApdu = reader.Exchange("FF 82 10 00 06 " + sKEY); // LOAD KEY
                                if (respApdu.SW1SW2 == 0x9000)
                                {
                                    sigue = true;
                                }
                                else
                                {
                                    //tmrMss.Enabled = true;
                                    MessageBox.Show(Owner, "DEBE INGRESAR UNA CLAVE VALIDA", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    reader.Disconnect();
                                }
                            }
                            else
                            {
                                sigue = true;
                            }

                            if (sigue)
                            {
                                respApdu = reader.Exchange("FF 86 00 00 05 01 00 04 60 00"); // CHECK PASS SECTOR 1 BLOQUE 0,1,2,3
                                if (respApdu.SW1SW2 == 0x9000)
                                {
                                    respApdu = reader.Exchange("FF B0 00 04 10"); // READ SECTOR 1 BLOQUE 0
                                    if (respApdu.SW1SW2 == 0x9000)
                                    {
                                        string CODE = HexFormatting.ToHexString(respApdu.Data, true);
                                        string[] Sector1Bloque0 = CODE.Split(' ');

                                        #region SECTOR 1 BLOQUE 0
                                        byte Byte0 = Convert.ToByte(Sector1Bloque0[0], 16);
                                        byte Byte1 = Convert.ToByte(Sector1Bloque0[1], 16);
                                        byte Byte2 = Convert.ToByte(Sector1Bloque0[2], 16);
                                        byte Byte3 = Convert.ToByte(Sector1Bloque0[3], 16);
                                        byte Byte4 = Convert.ToByte(Sector1Bloque0[4], 16);
                                        byte Byte5 = Convert.ToByte(Sector1Bloque0[5], 16);
                                        byte Byte6 = Convert.ToByte(Sector1Bloque0[6], 16);
                                        byte Byte7 = Convert.ToByte(Sector1Bloque0[7], 16);
                                        byte Byte8 = Convert.ToByte(Sector1Bloque0[8], 16);
                                        byte Byte9 = Convert.ToByte(Sector1Bloque0[9], 16);
                                        byte Byte10 = Convert.ToByte(Sector1Bloque0[10], 16);
                                        byte Byte11 = Convert.ToByte(Sector1Bloque0[11], 16);
                                        byte Byte12 = Convert.ToByte(Sector1Bloque0[12], 16);
                                        byte Byte13 = Convert.ToByte(Sector1Bloque0[13], 16);
                                        byte Byte14 = Convert.ToByte(Sector1Bloque0[14], 16);
                                        byte Byte15 = Convert.ToByte(Sector1Bloque0[15], 16);
                                        #endregion


                                        RespApdu respApdu2 = reader.Exchange("FF B0 00 05 10"); // READ SECTOR 1 BLOQUE 0
                                        if (respApdu2.SW1SW2 == 0x9000)
                                        {
                                            string CODE2 = HexFormatting.ToHexString(respApdu2.Data, true);
                                            string[] Sector1Bloque2 = CODE2.Split(' ');

                                            #region SECTOR 1 BLOQUE 1
                                            byte Byte20 = Convert.ToByte(Sector1Bloque2[0], 16);
                                            byte Byte21 = Convert.ToByte(Sector1Bloque2[1], 16);
                                            byte Byte22 = Convert.ToByte(Sector1Bloque2[2], 16);
                                            byte Byte23 = Convert.ToByte(Sector1Bloque2[3], 16);
                                            byte Byte24 = Convert.ToByte(Sector1Bloque2[4], 16);
                                            byte Byte25 = Convert.ToByte(Sector1Bloque2[5], 16);
                                            byte Byte26 = Convert.ToByte(Sector1Bloque2[6], 16);
                                            byte Byte27 = Convert.ToByte(Sector1Bloque2[7], 16);
                                            byte Byte28 = Convert.ToByte(Sector1Bloque2[8], 16);
                                            byte Byte29 = Convert.ToByte(Sector1Bloque2[9], 16);
                                            byte Byte210 = Convert.ToByte(Sector1Bloque2[10], 16);
                                            byte Byte211 = Convert.ToByte(Sector1Bloque2[11], 16);
                                            byte Byte212 = Convert.ToByte(Sector1Bloque2[12], 16);
                                            byte Byte213 = Convert.ToByte(Sector1Bloque2[13], 16);
                                            byte Byte214 = Convert.ToByte(Sector1Bloque2[14], 16);
                                            byte Byte215 = Convert.ToByte(Sector1Bloque2[15], 16);
                                            #endregion


                                            RespApdu respApdu3 = reader.Exchange("FF B0 00 06 10"); // READ SECTOR 1 BLOQUE 0
                                            if (respApdu3.SW1SW2 == 0x9000)
                                            {
                                                string CODE3 = HexFormatting.ToHexString(respApdu3.Data, true);
                                                string[] Sector1Bloque3 = CODE3.Split(' ');

                                                #region SECTOR 1 BLOQUE 2
                                                byte Byte30 = Convert.ToByte(Sector1Bloque3[0], 16);
                                                byte Byte31 = Convert.ToByte(Sector1Bloque3[1], 16);
                                                byte Byte32 = Convert.ToByte(Sector1Bloque3[2], 16);
                                                byte Byte33 = Convert.ToByte(Sector1Bloque3[3], 16);
                                                byte Byte34 = Convert.ToByte(Sector1Bloque3[4], 16);
                                                byte Byte35 = Convert.ToByte(Sector1Bloque3[5], 16);
                                                byte Byte36 = Convert.ToByte(Sector1Bloque3[6], 16);
                                                byte Byte37 = Convert.ToByte(Sector1Bloque3[7], 16);
                                                byte Byte38 = Convert.ToByte(Sector1Bloque3[8], 16);
                                                byte Byte39 = Convert.ToByte(Sector1Bloque3[9], 16);
                                                byte Byte310 = Convert.ToByte(Sector1Bloque3[10], 16);
                                                byte Byte311 = Convert.ToByte(Sector1Bloque3[11], 16);
                                                byte Byte312 = Convert.ToByte(Sector1Bloque3[12], 16);
                                                byte Byte313 = Convert.ToByte(Sector1Bloque3[13], 16);
                                                byte Byte314 = Convert.ToByte(Sector1Bloque3[14], 16);
                                                byte Byte315 = Convert.ToByte(Sector1Bloque3[15], 16);
                                                #endregion

                                                //SAuto = 0;
                                                CSharpPCSC.Tarjeta oTarjeta = new CSharpPCSC.Tarjeta();

                                                string INPUT = Convert.ToString(Byte1, 2);
                                                INPUT = INPUT.PadLeft(8, '0');

                                                string[] OUTPUT = INPUT.ToCharArray().Select(c => c.ToString()).ToArray();


                                                oTarjeta.ActiveCycle = Convert.ToBoolean(Byte1);
                                                
                                                oTarjeta.CodeAuthorized = Byte1 + Byte3;
                                                oTarjeta.CodeAgreement1 = Byte38 + Byte39;
                                                AcumuladoHoras = Convert.ToInt32(oTarjeta.CodeAgreement1);
                                                TipoVehiculo = Byte28;


                                                string Fecha = Byte4 + "/" + Byte3 + "/" + Byte2 + " " + Byte5 + ":" + Byte6 + ":" + Byte7;
                                                string Fechapago = Byte211 + "/" + Byte210 + "/" + Byte29 + " " + Byte212 + ":" + Byte213 + ":" + Byte214;



                                                if (Fecha != "0/0/0 0:0:0")
                                                {
                                                    oTarjeta.DateTimeEntrance = Convert.ToDateTime(Fecha);
                                                    //dFechaEntrada = oTarjeta.DateTimeEntrance;
                                                }


                                                if (Fechapago != "0/0/0 0:0:0")
                                                {
                                                    oTarjeta.PaymentDateTime = Convert.ToDateTime(Fechapago);
                                                }


                                                if (oTarjeta.ActiveCycle == false)
                                                {
                                                    //tmrMss.Enabled = true;
                                                    MessageBox.Show(Owner, "TARJETA SIN REGISTRO DE ENTRADA", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    reader.Disconnect();
                                                }
                                                else
                                                {

                                                    lblFechaEntrada.Text = oTarjeta.DateTimeEntrance.ToString();
                                                    lblIdTarjeta.Text = IdCard;

                                                    if (TipoVehiculo == 2)
                                                    {
                                                        lblTipoVehiculo.Text = "MOTO";
                                                    }
                                                    else 
                                                    {
                                                        lblTipoVehiculo.Text = "CARRO";
                                                    }

                                                    pAplicarDescuento.Visible = true;

                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //tmrMss.Enabled = true;
                                        MessageBox.Show(Owner, "ERROR AL LEER TARJETA", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        reader.Disconnect();
                                    }
                                }
                                else
                                {

                                    respApdu = reader.Exchange("FF 82 00 00 06 " + sKEY); // LOAD KEY
                                    if (respApdu.SW1SW2 == 0x9000)
                                    {
                                        //tmrMss.Enabled = true;
                                        MessageBox.Show(Owner, "VUELVA A LEER LA TARJETA", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        reader.Disconnect();
                                    }
                                }
                            }
                        }
                        else
                        {
                            //tmrMss.Enabled = true;
                            MessageBox.Show(Owner, "DEBE INGRESAR UNA CLAVE VALIDA", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            reader.Disconnect();
                        }
                    }
                    else
                    {
                        //tmrMss.Enabled = true;
                        MessageBox.Show(Owner, "ERROR AL LEER LA TARJETA ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        reader.Disconnect();
                    }

                }
                else
                {
                    //tmrMss.Enabled = true;
                    MessageBox.Show(Owner, "NO SE ENCONTRO NINGUN LECTOR CONECTADO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reader.Disconnect();
                }

            }
            catch (Exception ex)
            {
                //tmrMss.Enabled = true;
                MessageBox.Show(Owner, "VUELVA A LEER LA TARJETA", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Disconnect();
            }
        }
        private void pAplicarDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbHoras.Text != string.Empty)
                {
                    DialogResult result3 = new DialogResult();

                    if (lblTipoVehiculo.Text == "MOTO")
                    {
                        result3 = MessageBox.Show("Esta seguro de aplicar " + tbHoras.Text + " horas moto?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    }
                    else
                    {
                        result3 = MessageBox.Show("Esta seguro de aplicar " + tbHoras.Text + " horas carro?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    }

                    if (result3 == DialogResult.Yes)
                    {


                        try
                        {

                            #region Consulta

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
                            #endregion

                            if (HorasCarro == string.Empty)
                            {
                                HorasCarro = "0";
                            }
                            if (HorasMoto == string.Empty)
                            {
                                HorasMoto = "0";
                            }


                            int consultaCarros = Convert.ToInt32(HorasCarro);
                            int consultaMotos = Convert.ToInt32(HorasMoto);

                            if (lblTipoVehiculo.Text == "MOTO")
                            {
                                if (consultaMotos >= Convert.ToInt32(tbHoras.Text))
                                {

                                    if (Convert.ToInt32(_MontoMax) >= Convert.ToInt32(tbHoras.Text))
                                    {

                                        ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
                                        oResultadoOperacion = reader.Connect();

                                        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                                        {
                                            oResultadoOperacion = reader.ActivateCard();

                                            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                                            {
                                                if (sKEY != string.Empty)
                                                {
                                                    RespApdu respApdu = reader.Exchange("FF 86 00 00 05 01 00 04 60 00"); // CHECK PASS SECTOR 1 BLOQUE 0,1,2,3
                                                    if (respApdu.SW1SW2 == 0x9000)
                                                    {
                                                        int CN = Convert.ToInt32(tbHoras.Text) + AcumuladoHoras;
                                                        string hexValue = CN.ToString("X");

                                                        string Comando3 = "FF D6 00 06 10 " + "00 00 00 00 00 00 00 00 00 " + hexValue.PadLeft(2, '0') + " 00 00 00 00 00 00";
                                                        respApdu = reader.Exchange(Comando3); // WRITE SECTOR 1 BLOQUE 1 
                                                        if (respApdu.SW1SW2 == 0x9000)
                                                        {
                                                            conexionSQL.ConnectionString = data1;

                                                            conexionSQL.Open();

                                                            DateTime fecha = Convert.ToDateTime(lblFechaEntrada.Text);

                                                            int AÑO = fecha.Year;
                                                            int MES = fecha.Month;
                                                            int DIA = fecha.Day;
                                                            int HORA = fecha.Hour;
                                                            int MINUTO = fecha.Minute;
                                                            int SEG = fecha.Second;

                                                            string fECHAfIN = AÑO.ToString() + "/" + MES.ToString() + "/" + DIA.ToString() + " " + HORA.ToString() + ":" + MINUTO.ToString() + ":" + SEG.ToString();


                                                            string textoCmd = "INSERT INTO T_REGISTROS (IdEstablecimiento,FechaEntradaCliente,IdTarjeta,TipoVehiculo,FechaAplicacion,UsuarioAplica,HorasDescuento) values('" +
                                                            IdEstablecimiento + "','" + fECHAfIN + "','" + lblIdTarjeta.Text + "','" + TipoVehiculo + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + _UsuarioLogin + "'," + tbHoras.Text + ")";

                                                            SqlCommand InsertData = new SqlCommand(textoCmd, conexionSQL);
                                                            InsertData = new SqlCommand(textoCmd, conexionSQL);
                                                            InsertData.ExecuteNonQuery();

                                                            conexionSQL.Close();

                                                            conexionSQL.Open();

                                                            int final = consultaMotos - Convert.ToInt32(tbHoras.Text);

                                                            textoCmd = "UPDATE T_INFO SET HORASACTUALESMOTO =" + final;

                                                            InsertData = new SqlCommand(textoCmd, conexionSQL);
                                                            InsertData = new SqlCommand(textoCmd, conexionSQL);
                                                            InsertData.ExecuteNonQuery();

                                                            conexionSQL.Close();

                                                            MessageBox.Show(Owner, "SE APLICARON " + tbHoras.Text + " HORAS DE DESCUENTO MOTO\nLE QUEDAN " + final + " HORAS DISPONIBLES MOTO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            reader.Disconnect();
                                                            pAplicarDescuento.Visible = false;
                                                            tbHoras.Text = string.Empty;
                                                            lblFechaEntrada.Text = string.Empty;
                                                            lblIdTarjeta.Text = string.Empty;
                                                            lblTipoVehiculo.Text = string.Empty;
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show(Owner, "ERROR APLICANDO CONVENIO INTENTE DE NUEVO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            reader.Disconnect();
                                                        }

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show(Owner, "ERROR APLICANDO CONVENIO INTENTE DE NUEVO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        reader.Disconnect();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show(Owner, "ERROR AL INGRESAR KEY", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    reader.Disconnect();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show(Owner, "ERROR AL LEER LA TARJETA ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                reader.Disconnect();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show(Owner, "NO SE ENCONTRO NINGUN LECTOR CONECTADO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            reader.Disconnect();

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("SUPERA EL MONTO MAXIMO PERMITIDO PARA APLICAR DESCUENTO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        reader.Disconnect();
                                        tbHoras.Text = string.Empty;
                                    }

                                }
                                else
                                {

                                    MessageBox.Show("NO CUENTA CON HORAS DISPONIBLES MOTO PARA APLICAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    reader.Disconnect();
                                    tbHoras.Text = string.Empty;
                                }

                            }
                            else
                            {
                                if (consultaCarros >= Convert.ToInt32(tbHoras.Text))
                                {
                                    if (Convert.ToInt32(_MontoMax) >= Convert.ToInt32(tbHoras.Text))
                                    {

                                        ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
                                        oResultadoOperacion = reader.Connect();

                                        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                                        {
                                            oResultadoOperacion = reader.ActivateCard();

                                            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                                            {
                                                if (sKEY != string.Empty)
                                                {
                                                    RespApdu respApdu = reader.Exchange("FF 86 00 00 05 01 00 04 60 00"); // CHECK PASS SECTOR 1 BLOQUE 0,1,2,3
                                                    if (respApdu.SW1SW2 == 0x9000)
                                                    {

                                                        conexionSQL.ConnectionString = data1;

                                                        conexionSQL.Open();

                                                        DateTime fecha = Convert.ToDateTime(lblFechaEntrada.Text);

                                                        int AÑO = fecha.Year;
                                                        int MES = fecha.Month;
                                                        int DIA = fecha.Day;
                                                        int HORA = fecha.Hour;
                                                        int MINUTO = fecha.Minute;
                                                        int SEG = fecha.Second;

                                                        string fECHAfIN = AÑO.ToString() + "/" + MES.ToString() + "/" + DIA.ToString() + " " + HORA.ToString() + ":" + MINUTO.ToString() + ":" + SEG.ToString();

                                                        string textoCmd = "INSERT INTO T_REGISTROS (IdEstablecimiento,FechaEntradaCliente,IdTarjeta,TipoVehiculo,FechaAplicacion,UsuarioAplica,HorasDescuento) values('" +
                                                        IdEstablecimiento + "','" + fECHAfIN + "','" + lblIdTarjeta.Text + "','" + TipoVehiculo + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + _UsuarioLogin + "'," + tbHoras.Text + ")";

                                                        SqlCommand InsertData = new SqlCommand(textoCmd, conexionSQL);
                                                        InsertData = new SqlCommand(textoCmd, conexionSQL);
                                                        InsertData.ExecuteNonQuery();

                                                        conexionSQL.Close();

                                                        conexionSQL.Open();

                                                        int final = consultaCarros - Convert.ToInt32(tbHoras.Text);

                                                        textoCmd = "UPDATE T_INFO SET HORASACTUALESCARRO =" + final;

                                                        InsertData = new SqlCommand(textoCmd, conexionSQL);
                                                        InsertData = new SqlCommand(textoCmd, conexionSQL);
                                                        InsertData.ExecuteNonQuery();

                                                        conexionSQL.Close();

                                                        MessageBox.Show(Owner, "SE APLICARON " + tbHoras.Text + " HORAS DE DESCUENTO CARRO\nLE QUEDAN " + final + " HORAS DISPONIBLES CARRO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        reader.Disconnect();
                                                        pAplicarDescuento.Visible = false;
                                                        tbHoras.Text = string.Empty;
                                                        lblFechaEntrada.Text = string.Empty;
                                                        lblIdTarjeta.Text = string.Empty;
                                                        lblTipoVehiculo.Text = string.Empty;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show(Owner, "ERROR APLICANDO CONVENIO INTENTE DE NUEVO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        reader.Disconnect();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show(Owner, "ERROR AL INGRESAR KEY", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    reader.Disconnect();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show(Owner, "ERROR AL LEER LA TARJETA ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                reader.Disconnect();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show(Owner, "NO SE ENCONTRO NINGUN LECTOR CONECTADO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            reader.Disconnect();

                                        }
                                    }
                                    else 
                                    {
                                        MessageBox.Show("SUPERA EL MONTO MAXIMO PERMITIDO PARA APLICAR DESCUENTO", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        reader.Disconnect();
                                        tbHoras.Text = string.Empty;
                                    }
                                }
                                else
                                {

                                    MessageBox.Show("NO CUENTA CON HORAS DISPONIBLES CARRO PARA APLICAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    reader.Disconnect();
                                    tbHoras.Text = string.Empty;
                                }
                            }

                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }
                }
                else
                {
                    MessageBox.Show(Owner, "DEBE DIGITAR LAS HORAS QUE DESEA DESCONTAR", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reader.Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                reader.Disconnect();
            }
        }

        private void pMas_Click(object sender, EventArgs e)
        {

        }
        private void pMenos_Click(object sender, EventArgs e)
        {

        }
        private void btn_uSUARIO_Click(object sender, EventArgs e)
        {
            frm_Usuarios oUsuarios = new frm_Usuarios();
            oUsuarios.ShowDialog();
        }
        private void btn_Reports_Click(object sender, EventArgs e)
        {
            frmReports oReports = new frmReports();
            oReports.ShowDialog();
        }

        private void btn_Cargue_Click(object sender, EventArgs e)
        {
            frmCargue oCargue = new frmCargue(_UsuarioLogin);
            oCargue.ShowDialog();
        }
    }
}
