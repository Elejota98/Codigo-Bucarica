using EGlobalT.Device.SmartCard;
using EGlobalT.Device.SmartCardReaders;
using EGlobalT.Device.SmartCardReaders.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC.ModuloManual.WinForm.FrontEnd
{
    public partial class frmPrincipal : Form
    {
        #region Definiciones
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
        Lectora_ACR122U Lector = new Lectora_ACR122U();
        Rspsta_Conexion_LECTOR RespCin = new Rspsta_Conexion_LECTOR();
        Rspsta_DetectarTarjeta_LECTOR RespDetect = new Rspsta_DetectarTarjeta_LECTOR();
        Rspsta_Escribir_Tarjeta_LECTOR RespEscri = new Rspsta_Escribir_Tarjeta_LECTOR();
        Rspsta_BorrarTarjeta_LECTOR RespBorrar = new Rspsta_BorrarTarjeta_LECTOR();
        SqlConnection conexionSQL = new SqlConnection();
        SqlCommand comandoSQL = new SqlCommand();
        string NombreAuto = string.Empty;
        string IdTarjeta = string.Empty;
        int NumAuto = 0;
        #endregion

        #region EventosFormulario
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
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
                }
            }
        }
        private bool CargaRecursos()
        {
            bool ok = false;

            try
            {
                tmrHora.Enabled = true;
                tbPlaca.Text = string.Empty;
                btn_RegistrarEntrada.LockPush = false;
                btn_RegistrarEntrada.Text = string.Empty;
                btn_LeerTI.LockPush = false;
                btn_LeerTI.Text = string.Empty;
                btn_LeerTIAuto.LockPush = false;
                btn_LeerTIAuto.Text = string.Empty;
                Btn_IngresoAuto.LockPush = false;
                Btn_IngresoAuto.Text = string.Empty;
                btn_Pay.LockPush = false;
                btn_Pay.Text = string.Empty;

                lblNombreAutorizado.Text = string.Empty;

                string data = @"" + sSerial + "";

                conexionSQL.ConnectionString = data;

                


                ok = true;

                //General_Events = "(FrondEnd CargaRecursos): Carga Controles - OK";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar aplicacion");
                this.Close();
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
                //Imagen_SinTarjetas.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_SinTarjetas.jpg"));

                #endregion

                #region Botones
                btn_RegistrarEntrada.ImageSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_Tarjeta.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_Tarjeta.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_Tarjeta.png"));
                Btn_IngresoAuto.ImageSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_Tarjeta.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_Tarjeta.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_Tarjeta.png"));

                btn_LeerTIAuto.ImageSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_LeerTI.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_LeerTI.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_LeerTI.png"));
                btn_LeerTI.ImageSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_LeerTI.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_LeerTI.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_LeerTI.png"));
                btn_Pay.ImageSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_Pay.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_Pay.png"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Img_Pay.png"));
                /// Carga botones
                #endregion

                this.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Png\Imagen_Fondo.png"));
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
        #endregion

        #region EventosControles
        private void tmrHora_Tick(object sender, EventArgs e)
        {
            TsFechaHora.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
            lblFechaIngresoIn.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
            lblFechaInAuto.Text = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
        }
        #endregion

        #region Botones
        private void btn_RegistrarEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = cbTipo.SelectedItem.ToString();

                if (tipo != string.Empty)
                {

                    if (tbPlaca.Text != string.Empty)
                    {
                        RespCin = Lector.Conectar(true);
                        if (RespCin.Conectado)
                        {
                            RespDetect = Lector.DetectarTarjeta();
                            if (RespDetect.TarjetaDetectada)
                            {
                                Lector.BorrarTarjetaLECTORA(TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1, false);

                                Rspsta_CodigoTarjeta_LECTOR IDTARJETA = Lector.ObtenerIDTarjeta();

                                Rspsta_EstablecerClave_LECTOR resp1 = Lector.EstablecerClaveLECTOR(sKEY);

                                Rspsta_Leer_Tarjeta_LECTOR resp2 = Lector.LeerTarjeta(TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1, false);
                                if (resp2.TarjetaLeida)
                                {
                                    SMARTCARD_PARKING_V1 myTarjeta = (SMARTCARD_PARKING_V1)resp2.Tarjeta;

                                    string SecuenciaTransaccion = DateTime.Now.ToString("yyyyMMddHHmmss") + 1 + 10;

                                    string ano = SecuenciaTransaccion.Substring(0, 4);
                                    string mes = SecuenciaTransaccion.Substring(4, 2);
                                    string dia = SecuenciaTransaccion.Substring(6, 2);
                                    string hora = SecuenciaTransaccion.Substring(8, 2);
                                    string min = SecuenciaTransaccion.Substring(10, 2);
                                    string seg = SecuenciaTransaccion.Substring(12, 2);

                                    string FechaCompleta = dia + "/" + mes + "/" + ano + " " + hora + ":" + min + ":" + seg;

                                    DateTime _FechaCompleta = Convert.ToDateTime(FechaCompleta);


                                    myTarjeta.ActiveCycle = true;
                                    myTarjeta.DateTimeEntrance = _FechaCompleta;
                                    myTarjeta.EntranceModule = "ENTR01";
                                    myTarjeta.EntrancePlate = tbPlaca.Text;
                                    myTarjeta.TypeCard = TYPE_TARJETAPARKING_V1.VISITOR;


                                    int TIPOV = 0;

                                    if (tipo == "CARRO")
                                    {
                                        myTarjeta.TypeVehicle = TYPEVEHICLE_TARJETAPARKING_V1.AUTOMOBILE;
                                        TIPOV = 1;
                                    }
                                    else if (tipo == "MOTO")
                                    {
                                        myTarjeta.TypeVehicle = TYPEVEHICLE_TARJETAPARKING_V1.MOTORCYCLE;
                                        TIPOV = 2;
                                    }

                                    Rspsta_Escribir_Tarjeta_LECTOR resp4 = Lector.EscribirTarjeta(myTarjeta, false, false);

                                    conexionSQL.Open();

                                    //insert into T_Transacciones with(RowLock) (IdTransaccion,CarrilEntrada,ModuloEntrada,IdEstacionamiento,IdTarjeta,PlacaEntrada,FechaEntrada,FechaSalida,ModuloSalida,CarrilSalida,PlacaSalida,IdTipoVehiculo,IdCortesia,IdAutorizado,IdConvenio1,IdConvenio2,IdConvenio3,ValorRecibido,Cambio,Sincronizacion,SincronizacionPago,SincronizacionSalida)
                                    //values (@IdTransaccion,@CarrilEntrada,@ModuloEntrada,@IdEstacionamiento,@IdTarjeta,@PlacaEntrada,GETDATE(),'',NULL,NULL,NULL,1,NULL,@IdAutorizado,NULL,NULL,NULL,NULL,NULL,0,0,0)

                                    string textoCmd1 = "insert into T_Transacciones with(RowLock) (IdTransaccion,CarrilEntrada,ModuloEntrada,IdEstacionamiento,IdTarjeta,PlacaEntrada,FechaEntrada,FechaSalida,ModuloSalida,CarrilSalida,PlacaSalida,IdTipoVehiculo,IdCortesia,IdAutorizado,IdConvenio1,IdConvenio2,IdConvenio3,ValorRecibido,Cambio,Sincronizacion,SincronizacionPago,SincronizacionSalida) values("
                                    + SecuenciaTransaccion + "," + 1 + ",'" + "ENTR01" + "'," + 10 + ",'" + IDTARJETA.CodigoTarjeta + "','" + tbPlaca.Text + "'," + "GETDATE()" + "," + "''" + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + TIPOV + "," + "NULL" + "," + 0 + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + 0 + "," + 0 + "," + 0 + ")";

                                    SqlCommand InsertData1 = new SqlCommand(textoCmd1, conexionSQL);
                                    InsertData1 = new SqlCommand(textoCmd1, conexionSQL);
                                    InsertData1.ExecuteNonQuery();

                                    conexionSQL.Close();

                                    if (resp4.TarjetaEscrita)
                                    {
                                        MessageBox.Show("Entrada registrada correctamente");
                                        tbPlaca.Text = string.Empty;

                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al escribir tarjeta");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error al escribir tarjeta");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se detecto la tarjeta");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontro ningun lector conectado");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe escribir la placa del vehiculo");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el tipo de vehiculo");
                }
                Lector.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar entrada");
                Lector.Desconectar();
            }
        }
        private void Btn_IngresoAuto_Click(object sender, EventArgs e)
        {
            try
            {
                string tipo = cbTipoAuto.SelectedItem.ToString();

                if (tipo != string.Empty)
                {

                    if (tbPlacaAuto.Text != string.Empty)
                    {
                        RespCin = Lector.Conectar(true);
                        if (RespCin.Conectado)
                        {
                            RespDetect = Lector.DetectarTarjeta();
                            if (RespDetect.TarjetaDetectada)
                            {
                                Rspsta_CodigoTarjeta_LECTOR IDTARJETA = Lector.ObtenerIDTarjeta();

                                Rspsta_EstablecerClave_LECTOR resp1 = Lector.EstablecerClaveLECTOR(sKEY);

                                Rspsta_Leer_Tarjeta_LECTOR resp2 = Lector.LeerTarjeta(TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1, false);
                                if (resp2.TarjetaLeida)
                                {
                                    SMARTCARD_PARKING_V1 myTarjeta = (SMARTCARD_PARKING_V1)resp2.Tarjeta;

                                    string SecuenciaTransaccion = DateTime.Now.ToString("yyyyMMddHHmmss") + 1 + 10;

                                    string ano = SecuenciaTransaccion.Substring(0, 4);
                                    string mes = SecuenciaTransaccion.Substring(4, 2);
                                    string dia = SecuenciaTransaccion.Substring(6, 2);
                                    string hora = SecuenciaTransaccion.Substring(8, 2);
                                    string min = SecuenciaTransaccion.Substring(10, 2);
                                    string seg = SecuenciaTransaccion.Substring(12, 2);

                                    string FechaCompleta = dia + "/" + mes + "/" + ano + " " + hora + ":" + min + ":" + seg;

                                    DateTime _FechaCompleta = Convert.ToDateTime(FechaCompleta);


                                    myTarjeta.ActiveCycle = true;
                                    myTarjeta.DateTimeEntrance = _FechaCompleta;
                                    myTarjeta.EntranceModule = "ENTR01";
                                    myTarjeta.EntrancePlate = tbPlacaAuto.Text;
                                    myTarjeta.TypeCard = TYPE_TARJETAPARKING_V1.AUTHORIZED_PARKING;


                                    int TIPOV = 0;

                                    if (tipo == "CARRO")
                                    {
                                        myTarjeta.TypeVehicle = TYPEVEHICLE_TARJETAPARKING_V1.AUTOMOBILE;
                                        TIPOV = 1;
                                    }
                                    else if (tipo == "MOTO")
                                    {
                                        myTarjeta.TypeVehicle = TYPEVEHICLE_TARJETAPARKING_V1.MOTORCYCLE;
                                        TIPOV = 2;
                                    }

                                    Rspsta_Escribir_Tarjeta_LECTOR resp4 = Lector.EscribirTarjeta(myTarjeta, false, false);

                                    conexionSQL.Open();

                                    //insert into T_Transacciones with(RowLock) (IdTransaccion,CarrilEntrada,ModuloEntrada,IdEstacionamiento,IdTarjeta,PlacaEntrada,FechaEntrada,FechaSalida,ModuloSalida,CarrilSalida,PlacaSalida,IdTipoVehiculo,IdCortesia,IdAutorizado,IdConvenio1,IdConvenio2,IdConvenio3,ValorRecibido,Cambio,Sincronizacion,SincronizacionPago,SincronizacionSalida)
                                    //values (@IdTransaccion,@CarrilEntrada,@ModuloEntrada,@IdEstacionamiento,@IdTarjeta,@PlacaEntrada,GETDATE(),'',NULL,NULL,NULL,1,NULL,@IdAutorizado,NULL,NULL,NULL,NULL,NULL,0,0,0)

                                    string textoCmd1 = "insert into T_Transacciones with(RowLock) (IdTransaccion,CarrilEntrada,ModuloEntrada,IdEstacionamiento,IdTarjeta,PlacaEntrada,FechaEntrada,FechaSalida,ModuloSalida,CarrilSalida,PlacaSalida,IdTipoVehiculo,IdCortesia,IdAutorizado,IdConvenio1,IdConvenio2,IdConvenio3,ValorRecibido,Cambio,Sincronizacion,SincronizacionPago,SincronizacionSalida) values("
                                    + SecuenciaTransaccion + "," + 1 + ",'" + "ENTR01" + "'," + 10 + ",'" + IDTARJETA.CodigoTarjeta + "','" + tbPlaca.Text + "'," + "GETDATE()" + "," + "''" + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + TIPOV + "," + "NULL" + "," + NumAuto + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + "NULL" + "," + 0 + "," + 0 + "," + 0 + ")";

                                    SqlCommand InsertData1 = new SqlCommand(textoCmd1, conexionSQL);
                                    InsertData1 = new SqlCommand(textoCmd1, conexionSQL);
                                    InsertData1.ExecuteNonQuery();

                                    conexionSQL.Close();

                                    if (resp4.TarjetaEscrita)
                                    {
                                        MessageBox.Show("Entrada registrada correctamente");
                                        tbPlaca.Text = string.Empty;

                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al escribir tarjeta");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error al escribir tarjeta");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se detecto la tarjeta");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontro ningun lector conectado");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe escribir la placa del vehiculo");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el tipo de vehiculo");
                }
                Lector.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar entrada");
                Lector.Desconectar();
            }
        }
        private void btn_LeerTI_Click(object sender, EventArgs e)
        {
            try
            {
                RespCin = Lector.Conectar(true);
                if (RespCin.Conectado)
                {
                    RespDetect = Lector.DetectarTarjeta();
                    if (RespDetect.TarjetaDetectada)
                    {
                        Rspsta_CodigoTarjeta_LECTOR IDTARJETA = Lector.ObtenerIDTarjeta();

                        Rspsta_EstablecerClave_LECTOR resp1 = Lector.EstablecerClaveLECTOR(sKEY);

                        Rspsta_Leer_Tarjeta_LECTOR resp2 = Lector.LeerTarjeta(TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1, false);
                        if (resp2.TarjetaLeida)
                        {
                            SMARTCARD_PARKING_V1 myTarjeta = (SMARTCARD_PARKING_V1)resp2.Tarjeta;

                            lblIdTarjeta.Text = IDTARJETA.CodigoTarjeta;
                            lblTipoTarjeta.Text = myTarjeta.TypeCard.ToString();
                            lblTipoVehiculo.Text = myTarjeta.TypeVehicle.ToString();
                            lblFechaEntrada.Text = myTarjeta.DateTimeEntrance.ToString();
                            lblFechaPago.Text = myTarjeta.PaymentDateTime.ToString();

                            if (myTarjeta.ActiveCycle == true)
                            {
                                cbCiclo.Checked = true;
                            }
                            else
                            {
                                cbCiclo.Checked = false;
                            }

                            if (myTarjeta.Courtesy == true)
                            {
                                cbCortesia.Checked = true;
                            }
                            else
                            {
                                cbCortesia.Checked = false;
                            }

                            if (myTarjeta.Replacement == true)
                            {
                                cbRepo.Checked = true;
                            }
                            else
                            {
                                cbRepo.Checked = false;
                            }



                        }
                        else
                        {
                            MessageBox.Show("Error al leer tarjeta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se detecto la tarjeta");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro ningun lector conectado");
                }

                Lector.Desconectar();
            }
            catch (Exception ex)
            {
                Lector.Desconectar();
            }
        }
        private void btn_LeerTIAuto_Click(object sender, EventArgs e)
        {
            try
            {
                RespCin = Lector.Conectar(true);
                if (RespCin.Conectado)
                {
                    RespDetect = Lector.DetectarTarjeta();
                    if (RespDetect.TarjetaDetectada)
                    {
                        Rspsta_CodigoTarjeta_LECTOR IDTARJETA = Lector.ObtenerIDTarjeta();

                        Rspsta_EstablecerClave_LECTOR resp1 = Lector.EstablecerClaveLECTOR(sKEY);

                        Rspsta_Leer_Tarjeta_LECTOR resp2 = Lector.LeerTarjeta(TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1, false);
                        if (resp2.TarjetaLeida)
                        {
                            SMARTCARD_PARKING_V1 myTarjeta = (SMARTCARD_PARKING_V1)resp2.Tarjeta;

                            if (myTarjeta.ActiveCycle == true)
                            {
                                MessageBox.Show("TARJETA SIN REGISTRO DE SALIDA");
                            }

                            conexionSQL.Open();
                            
                            NombreAuto = string.Empty;
                            IdTarjeta = string.Empty;
                            NumAuto = 0;


                            //IdTarjeta = IDTARJETA.CodigoTarjeta;
                            IdTarjeta = "4E9FC8CB";

                            SqlDataReader myReader = null;
                            string strCadSQL = "SELECT dbo.T_PersonasAutorizadas.Documento, dbo.T_Autorizaciones.IdAutorizacion, dbo.T_PersonasAutorizadas.Estado, dbo.T_Autorizaciones.Estado AS EstadoAutorizacion,dbo.T_PersonasAutorizadas.IdTarjeta,dbo.T_PersonasAutorizadas.NombreApellidos, dbo.T_PersonasAutorizadas.FechaInicio, dbo.T_PersonasAutorizadas.FechaFin,dbo.T_Autorizaciones.IdEstacionamiento FROM dbo.T_PersonasAutorizadas INNER JOIN dbo.T_Autorizaciones ON dbo.T_PersonasAutorizadas.IdAutorizacion = dbo.T_Autorizaciones.IdAutorizacion WHERE dbo.T_PersonasAutorizadas.IdTarjeta ='"+ IdTarjeta +"' order by dbo.T_Autorizaciones.IdEstacionamiento  desc";
                            SqlCommand myCommand = new SqlCommand(strCadSQL, conexionSQL);

                            //Ejecutar el comando SQL
                            myReader = myCommand.ExecuteReader();

                            while (myReader.Read())
                            {
                                if (Environment.UserInteractive)
                                    Console.WriteLine("Devuelve datos");

                                NombreAuto = myReader["NombreApellidos"].ToString();
                                NumAuto = Convert.ToInt32(myReader["IdAutorizacion"]);
                            }

                            conexionSQL.Close();

                            lblNombreAutorizado.Text = NombreAuto;
                           
                        }
                        else
                        {
                            MessageBox.Show("Error al leer tarjeta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se detecto la tarjeta");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro ningun lector conectado");
                }

                Lector.Desconectar();
            }
            catch (Exception ex)
            {
                Lector.Desconectar();
            }
        }
        private void btn_Pay_Click(object sender, EventArgs e)
        {
            try
            {

                RespCin = Lector.Conectar(true);
                if (RespCin.Conectado)
                {
                    RespDetect = Lector.DetectarTarjeta();
                    if (RespDetect.TarjetaDetectada)
                    {
                        Rspsta_CodigoTarjeta_LECTOR IDTARJETA = Lector.ObtenerIDTarjeta();

                        Rspsta_EstablecerClave_LECTOR resp1 = Lector.EstablecerClaveLECTOR(sKEY);

                        Rspsta_Leer_Tarjeta_LECTOR resp2 = Lector.LeerTarjeta(TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1, false);
                        if (resp2.TarjetaLeida)
                        {


                            SMARTCARD_PARKING_V1 myTarjeta = (SMARTCARD_PARKING_V1)resp2.Tarjeta;

                            DateTime Entrada = Convert.ToDateTime(myTarjeta.DateTimeEntrance);
                            string IdTransaccion = Entrada.ToString("yyyyMMddHHmmss");
                            string SecuenciaTransaccion = IdTransaccion + 1 + 10;

                            Lector.BorrarTarjetaLECTORA(TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1, false);

                            conexionSQL.Open();

                            //Update T_Transacciones set 	CarrilSalida = @CarrilSalida, ModuloSalida = @ModuloSalida, PlacaSalida = @PlacaSalida, FechaSalida = GETDATE()
                            //FROM T_Transacciones
                            //WHERE IdTransaccion = @IdTransaccion

                            string textoCmd1 = "Update T_Transacciones set 	CarrilSalida = " + 1 + ", ModuloSalida = " + "'SALI01'" + ", PlacaSalida = '------', FechaSalida = GETDATE() FROM T_Transacciones WHERE IdTransaccion = " + SecuenciaTransaccion;

                            SqlCommand InsertData1 = new SqlCommand(textoCmd1, conexionSQL);
                            InsertData1 = new SqlCommand(textoCmd1, conexionSQL);
                            InsertData1.ExecuteNonQuery();

                            conexionSQL.Close();

                            MessageBox.Show("Salida registrada correctamente");
                            
                        }
                        else
                        {
                            MessageBox.Show("Error al escribir tarjeta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se detecto la tarjeta");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontro ningun lector conectado");
                }

                Lector.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar entrada");
                Lector.Desconectar();
            }
        }
        #endregion

    }
}
