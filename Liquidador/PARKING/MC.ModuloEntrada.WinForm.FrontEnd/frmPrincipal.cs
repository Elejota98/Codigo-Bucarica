using EGlobalT.Device.SmartCard;
using EGlobalT.Device.SmartCardReaders;
using EGlobalT.Device.SmartCardReaders.Entities;
using MC.BusinessObjects.DataTransferObject;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using MC.ModuloEntrada.WinForm.Presenter;
using MC.ModuloEntrada.WinForm.View;
using MC.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC.ModuloEntrada.WinForm.FrontEnd
{
    public partial class frmPrincipal : Form, IView_Principal
    {

        #region Rutas
        
        //Audio
        private string _sPathBienvenido = string.Empty;
        private string _sPathAutoVencida = string.Empty;
        private string _sPathSinTarjetasDispensador = string.Empty;
        private string _sPathSistemaSuspendido = string.Empty;
        private string _sPathTarjetaInvalida = string.Empty;
        private string _sPathTarjetaSinRegistroSalida = string.Empty;
        private string _sPathVehiculoEntrando = string.Empty;

        #endregion
       
        #region Definiciones
        Lectora_CRT602U Lector = new Lectora_CRT602U();
        Rspsta_Conexion_LECTOR RspConexion = new Rspsta_Conexion_LECTOR();
        Rspsta_DetectarTarjeta_LECTOR RspDetectar = new Rspsta_DetectarTarjeta_LECTOR();
        Rspsta_CodigoTarjeta_LECTOR RspIdCard = new Rspsta_CodigoTarjeta_LECTOR();
        Rspsta_Leer_Tarjeta_LECTOR RspLeerCard = new Rspsta_Leer_Tarjeta_LECTOR();
        private frmPrincipal_Presenter _frmPrincipal_Presenter;
        Transaccion oTransaccion = new Transaccion();
        string IdTarjeta = string.Empty;
        private int _cnt_timeout;
        public int cnt_timeout
        {
            get { return _cnt_timeout; }
            set { _cnt_timeout = value; }
        }
        private Pantalla _Presentacion = Pantalla.SalvaPantallas;
        private bool _KytReady = false;
        public bool KytReady
        {
            get { return _KytReady; }
            set { _KytReady = value; }
        }
        private bool _CardKytReady = false;
        public bool CardKytReady
        {
            get { return _CardKytReady; }
            set { _CardKytReady = value; }
        }
        private bool _CleanCardKyt = false;
        public bool CleanCardKyt
        {
            get { return _CleanCardKyt; }
            set { _CleanCardKyt = value; }
        }
        private bool _RemoveCard = false;
        public bool RemoveCard
        {
            get { return _RemoveCard; }
            set { _RemoveCard = value; }
        }
        private string _IdCard = string.Empty;
        public string IdCard
        {
            get { return _IdCard; }
            set { _IdCard = value; }
        }
        private Tarjeta _Tarjeta = new Tarjeta();
        public Tarjeta Tarjeta
        {
            get { return _Tarjeta; }
            set { _Tarjeta = value; }
        }
        private bool _WriteCard = false;
        public bool WriteCard
        {
            get { return _WriteCard; }
            set { _WriteCard = value; }
        }
        private bool _CRTReady = false;
        public bool CRTReady
        {
            get { return _CRTReady; }
            set { _CRTReady = value; }
        }
        private string _IdCardAutorizado = string.Empty;
        public string IdCardAutorizado
        {
            get { return _IdCardAutorizado; }
            set { _IdCardAutorizado = value; }
        }
        string SecuenciaTransaccion = string.Empty;
        private List<DtoAutorizado> _lstDtoAutorizado = new List<DtoAutorizado>();
        public List<DtoAutorizado> lstDtoAutorizado
        {
            get { return _lstDtoAutorizado; }
            set { _lstDtoAutorizado = value; }
        }        
        private bool _CicloActivo = false;
        public bool CicloActivo
        {
            get { return _CicloActivo; }
            set { _CicloActivo = value; }
        }
        private DtoModulo _DtoModulo = new DtoModulo();
        public DtoModulo DtoModulo
        {
            get { return _DtoModulo; }
            set { _DtoModulo = value; }
        }
        private Transaccion _Transaccion = new Transaccion();
        int CntAuto = 0;
        bool soundSuspen = false;
        int Ssuspe = 0;
        bool soundSinTar = false;
        int SsinTar = 0;
        bool InfoModulo = false;
        private bool _SinTarjetas = false;
        public bool SinTarjetas
        {
            get { return _SinTarjetas; }
            set { _SinTarjetas = value; }
        }
        bool Camara = false;
        bool VehiculoMoto = false;
        private List<DtoTarjetas> _lstDtoTarjetas = new List<DtoTarjetas>();
        public List<DtoTarjetas> lstDtoTarjetas
        {
            get { return _lstDtoTarjetas; }
            set { _lstDtoTarjetas = value; }
        }
        public DateTime _FechaCompleta = new DateTime();
        private string _Barrera = string.Empty;
        public string Barrera
        {
            get { return _Barrera; }
            set { _Barrera = value; }
        }
        private string _sPlaca = string.Empty;
        public string sPlaca
        {
            get { return sPlaca; }
            set { sPlaca = value; }
        }

        #endregion

        #region EventosFormulario
        public frmPrincipal()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _frmPrincipal_Presenter = new frmPrincipal_Presenter(this);
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        #endregion

        #region EventosControles
        private void tmrTimeOut_Tick(object sender, EventArgs e)
        {
            SsinTar++;
            Ssuspe++;
            cnt_timeout++;
            switch (_Presentacion)
            {
                case Pantalla.SalvaPantallas:

                    //Presentacion = Pantalla.RetireTarjeta;

                    _SinTarjetas = false;
                    bool Tarval = false;
                    //_frmPrincipal_Presenter.ConectarCRT();

                    if (_frmPrincipal_Presenter.TestConexionDispositivos())
                    {
                        _frmPrincipal_Presenter.StateDispenser();

                        if (!_SinTarjetas)
                        {
                            if (_frmPrincipal_Presenter.VehiculoMueble())
                            {

                                General_Events = "(FrontEnd Antes CapturaPlaca)";

                                Thread ohilo = new Thread(unused => CapturaPlaca());
                                ohilo.Start();

                                General_Events = "(FrontEnd CapturaPlaca) " + _sPlaca;

                                _frmPrincipal_Presenter.AlistarTarjeta();

                                _frmPrincipal_Presenter.LimpiarTarjeta();
                                if (_CleanCardKyt == true)
                                {
                                    SoundPlayer simpleSound = new SoundPlayer(_sPathBienvenido);
                                    simpleSound.Play();

                                    SecuenciaTransaccion = DateTime.Now.ToString("yyyyMMddHHmmss") + Globales.sCarril + Globales.iCodigoEstacionamiento;

                                    string ano = SecuenciaTransaccion.Substring(0, 4);
                                    string mes = SecuenciaTransaccion.Substring(4, 2);
                                    string dia = SecuenciaTransaccion.Substring(6, 2);
                                    string hora = SecuenciaTransaccion.Substring(8, 2);
                                    string min = SecuenciaTransaccion.Substring(10, 2);
                                    string seg = SecuenciaTransaccion.Substring(12, 2);

                                    string FechaCompleta = dia + "/" + mes + "/" + ano + " " + hora + ":" + min + ":" + seg;

                                    _FechaCompleta = Convert.ToDateTime(FechaCompleta);

                                    ohilo = new Thread(unused => _frmPrincipal_Presenter.CapturaFoto("1", SecuenciaTransaccion));
                                    ohilo.Start();

                                   

                                    _Tarjeta.EntrancePlate = _sPlaca;
                                    _Tarjeta.ActiveCycle = true;
                                    _Tarjeta.DateTimeEntrance = _FechaCompleta;
                                    _Tarjeta.EntranceModule = Globales.sSerial;

                                    if (Globales.sCarrilMixto == "SI")
                                    {
                                        if (_frmPrincipal_Presenter.ValidacionMotoMueble() == false)
                                        {
                                            VehiculoMoto = true;
                                            _frmPrincipal_Presenter.EscribirCard(_Tarjeta, true);
                                        }
                                        else
                                        {
                                            VehiculoMoto = false;
                                            _frmPrincipal_Presenter.EscribirCard(_Tarjeta, false);
                                        }
                                    }
                                    else
                                    {
                                        VehiculoMoto = false;
                                        General_Events = "(FrontEnd Antes de escribir)";
                                        _frmPrincipal_Presenter.EscribirCard(_Tarjeta, false);
                                        General_Events = "(FrontEnd Tarjeta Escrita)";
                                    }



                                    if (_WriteCard)
                                    {
                                        _frmPrincipal_Presenter.DispensarTarjeta();
                                        Presentacion = Pantalla.RetireTarjeta;
                                    }
                                    else
                                    {
                                        _frmPrincipal_Presenter.DesecharCard();
                                        _frmPrincipal_Presenter.AlistarTarjeta();
                                        _frmPrincipal_Presenter.LimpiarTarjeta();
                                    }
                                }
                            }
                            else
                            {
                                if (_frmPrincipal_Presenter.ObtenerEventoDispo())
                                {
                                    string[] Resul = _Barrera.Split(';');

                                    if (Resul[0].ToString() == Globales.sSerial)
                                    {
                                        _frmPrincipal_Presenter.AbrirTalanquera();
                                    }

                                    _frmPrincipal_Presenter.ActualizarEventoDispo(Convert.ToInt64(Resul[1]));
                                }
                            }
                        }                        
                    }
                    break;

                case Pantalla.SistemaSuspendido:
                    if (!_CardKytReady)
                    {
                        string Descripcion = "Dispensador no conectado";
                        int NivelError = 1;
                        string Parte = "kyt_Dispenser";
                        string TipoError = "Error_Conexion_Dispensador";

                        _frmPrincipal_Presenter.RegistrarAlarma(Descripcion, NivelError, Parte, TipoError);


                        _frmPrincipal_Presenter.AlistarTarjeta();

                        if (!InfoModulo && _CardKytReady)
                        {
                            _frmPrincipal_Presenter.TestConexionSuspendidoDispositivos();
                        }
                    }
                   
                    if (Ssuspe == 45)
                    {
                        soundSuspen = false;
                        Ssuspe = 0;
                    }

                    break;

                case Pantalla.RetireTarjeta:

                    _frmPrincipal_Presenter.PocisionCard();
                    _frmPrincipal_Presenter.GetIdCard();

                    bool bAutoVencida = false;
                    bool bTarjetaInvalida = false;
                    bool ok = false;
                    //RspDetectar = Lector.DetectarTarjeta();

                    if (RemoveCard)
                    {
                        RegistroEntrada();
                    }
                    else if (_IdCardAutorizado != string.Empty)
                    {
                        CntAuto = 0;
                        bool TarOK = false;
                        _frmPrincipal_Presenter.DevolverTarjeta();
                        //RspIdCard = Lector.ObtenerIDTarjeta();
                        //VALIDAR AUTORIZADO
                        Autorizado oAutorizado = new Autorizado();
                        oAutorizado.IdTarjeta = _IdCardAutorizado;
                        General_Events = "oAutorizado.IdTarjeta : " + oAutorizado.IdTarjeta;

                        if (_frmPrincipal_Presenter.ObtenerTarjetas())
                        {
                            for (int i = 0; i < _lstDtoTarjetas.Count; i++)
                            {

                                if (_lstDtoTarjetas[i].IdTarjeta == oAutorizado.IdTarjeta && _lstDtoTarjetas[i].Estado)
                                {
                                    TarOK = true;
                                    break;
                                }
                            }
                        }


                        if (TarOK)
                        {

                            if (_frmPrincipal_Presenter.ObtenerAutorizado(oAutorizado))
                            {
                                //ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
                                //ITarjeta ocard;
                                //ocard = RspLeerCard.Tarjeta;
                                //oResultadoOperacion.EntidadDatos = ocard;
                                //SMARTCARD_PARKING_V1 Scard = new SMARTCARD_PARKING_V1();
                                //Scard = (SMARTCARD_PARKING_V1)oResultadoOperacion.EntidadDatos;
                                /// validaciones autorizado

                                for (int i = 0; i < _lstDtoAutorizado.Count; i++)
                                {

                                    if (oAutorizado.IdTarjeta == _lstDtoAutorizado[i].IdTarjeta)
                                    {
                                        if (_lstDtoAutorizado[i].IdEstacionamiento == Convert.ToInt64(Globales.iCodigoEstacionamiento))
                                        {

                                            if (_lstDtoAutorizado[i].EstadoAutorizacion && _lstDtoAutorizado[i].Estado && DateTime.Now >= _lstDtoAutorizado[i].FechaInicial && DateTime.Now <= _lstDtoAutorizado[i].FechaFinal)
                                            {
                                                if (_frmPrincipal_Presenter.ValidarIngresoAuto(oAutorizado.IdTarjeta))
                                                {
                                                    ok = true;
                                                    bAutoVencida = false;
                                                    bTarjetaInvalida = false;
                                                    CntAuto = i;
                                                    break;
                                                }
                                                else
                                                {
                                                    SoundPlayer simpleSound = new SoundPlayer(_sPathTarjetaSinRegistroSalida);
                                                    simpleSound.Play();
                                                    Presentacion = Pantalla.TarjetaSinRegistroSalida;
                                                    break;
                                                    //General_Events = "TarjetaSinRegistroSalida";
                                                    //ok = true;
                                                    //bAutoVencida = false;
                                                    //bTarjetaInvalida = false;
                                                    //CntAuto = i;
                                                    //break;
                                                }
                                            }
                                            else
                                            {
                                                //Presentacion = Pantalla.AutorizacionVencida;
                                                bAutoVencida = true;

                                            }
                                        }
                                        else
                                        {
                                            //Presentacion = Pantalla.TarjetaInvalida;
                                            bTarjetaInvalida = true;
                                        }

                                    }
                                }

                                if (ok)
                                {
                                    RegistroEntradaAutorizado(CntAuto);
                                }
                                else if (bAutoVencida)
                                {
                                    SoundPlayer simpleSound = new SoundPlayer(_sPathAutoVencida);
                                    simpleSound.Play();
                                    Presentacion = Pantalla.AutorizacionVencida;
                                }
                                else if (bTarjetaInvalida)
                                {
                                    SoundPlayer simpleSound = new SoundPlayer(_sPathTarjetaInvalida);
                                    simpleSound.Play();
                                    Presentacion = Pantalla.TarjetaInvalida;
                                }
                            }
                            else
                            {
                                SoundPlayer simpleSound = new SoundPlayer(_sPathTarjetaInvalida);
                                simpleSound.Play();
                                Presentacion = Pantalla.TarjetaInvalida;
                            }
                        }
                        else
                        {
                            SoundPlayer simpleSound = new SoundPlayer(_sPathTarjetaInvalida);
                            simpleSound.Play();
                            Presentacion = Pantalla.TarjetaInvalida;
                        }
                    }
                    else
                    {
                        //if (cnt_timeout == (int)TimeOut.TimeOut_RetireTarjeta)
                        //{
                        //    _frmPrincipal_Presenter.DevolverTarjeta();

                        //    ///si no hay tarjeta en rf generar entrada
                        //    Presentacion = Pantalla.SalvaPantallas;
                        //}

                        if (_frmPrincipal_Presenter.ObtenerEventoDispo())
                        {
                            string[] Resul = _Barrera.Split(';');

                            if (Resul[0].ToString() == Globales.sSerial)
                            {
                                _frmPrincipal_Presenter.AbrirTalanquera();
                            }

                            _frmPrincipal_Presenter.ActualizarEventoDispo(Convert.ToInt64(Resul[1]));
                        }


                        if (_frmPrincipal_Presenter.VehiculoMueble() == false)
                        {
                            _frmPrincipal_Presenter.DevolverTarjeta();
                            Presentacion = Pantalla.SalvaPantallas;
                        }
                    }
                    break;

                case Pantalla.DisfruteVisita:
                    if (_frmPrincipal_Presenter.VehiculoTalanquera())
                    {
                        bool sound = false;
                        //_frmPrincipal_Presenter.AlistarTarjeta();
                        if (!sound)
                        {
                            SoundPlayer simpleSound = new SoundPlayer(_sPathVehiculoEntrando);
                            simpleSound.Play();
                            sound = true;
                        }
                        //EnvioImagenes();
                        Presentacion = Pantalla.VehiculoEntrando;
                    }
                    break;
                case Pantalla.DisfruteVisitaAuto:
                    if (_frmPrincipal_Presenter.VehiculoTalanquera())
                    {
                        bool sound = false;

                        if (!sound)
                        {
                            SoundPlayer simpleSound = new SoundPlayer(_sPathVehiculoEntrando);
                            simpleSound.Play();
                            sound = true;
                        }
                        //EnvioImagenes();
                        Presentacion = Pantalla.VehiculoEntrando;
                    }
                    break;
                case Pantalla.VehiculoEntrando:
                    if (_frmPrincipal_Presenter.VehiculoSalioTalanquera())
                    {
                        
                        if (_frmPrincipal_Presenter.LimpiarValoresPLC())
                        {
                            Presentacion = Pantalla.SalvaPantallas;
                        }
                    }
                    break;

                case Pantalla.TarjetaInvalida:
                    if (cnt_timeout == (int)TimeOut.TimeOut_Alertas)
                    {
                        Presentacion = Pantalla.SalvaPantallas;
                    }
                    break;

                case Pantalla.AutorizacionVencida:
                    if (cnt_timeout == (int)TimeOut.TimeOut_Alertas)
                    {
                        Presentacion = Pantalla.SalvaPantallas;
                    }
                    break;

                case Pantalla.TarjetaSinRegistroSalida:
                    if (cnt_timeout == (int)TimeOut.TimeOut_Alertas)
                    {
                        Presentacion = Pantalla.SalvaPantallas;
                    }
                    break;
                case Pantalla.SinTarjetas:
                    _frmPrincipal_Presenter.StateDispenser();
                    if (SsinTar == 45)
                    {
                        soundSinTar = false;
                        SsinTar = 0;
                    }
                    break;
            }
        }
        private void tmrEnvioImagenes_Tick(object sender, EventArgs e)
        {
            EnvioImagenes();
        }
        #endregion
        
        #region General
        private async Task Inicio()
        {
            if (Globales.sTestMode != string.Empty)
            {
                if (Convert.ToBoolean(Globales.sTestMode) != true)
                {
                    Cursor.Hide();
                    this.TopMost = true;

                }
                else
                {
                    Cursor.Show();
                    this.TopMost = false;
                }
            }
            else
            {
                Cursor.Hide();
                this.TopMost = true;
            }


            TraceHandler.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs\Log"), "INICIO REGISTRO", TipoLog.TRAZA);

            if (CargaRecursos())
            {
                if (CargaImagenes())
                {
                    if (CargaSonidos())
                    {
                        if (CargaAnimaciones())
                        {
                            if (Globales.sSerial != string.Empty)
                            {
                                if (CargarParametros())
                                {

                                    _frmPrincipal_Presenter.SolucionarTodasAlarmas();

                                    var th1 = await ConectarDispositivos();

                                    if (th1)
                                    {
                                        Presentacion = Pantalla.SalvaPantallas;
                                    }
                                    else
                                    {
                                        //MessageBox.Show("SISTEMA SUSPENDIDO");
                                        Presentacion = Pantalla.SistemaSuspendido;
                                    }
                                }
                                else
                                {
                                    InfoModulo = true;
                                    Presentacion = Pantalla.SistemaSuspendido;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Antes de iniciar el punto de pago debe configurar el nombre del modulo.");
                                Presentacion = Pantalla.SistemaSuspendido;
                            }
                        }
                        else
                        {
                            //Presentacion = Pantalla.SistemaSuspendido;
                        }
                    }

                }

            }

        }
        private bool CargarParametros()
        {
            bool ok = false;

            if (_frmPrincipal_Presenter.ObtenerInfoModulo())
            {
                if (_frmPrincipal_Presenter.ObtenerPartes())
                {
                    if (_frmPrincipal_Presenter.ObtenerParametros())
                    {
                        ok = true;
                    }
                }
            }

            return ok;
        }
        private bool CargaRecursos()
        {
            bool ok = false;

            try
            {
                lblHoraINgreso.BackColor = Color.Transparent;

                lblDatosAuto.BackColor = Color.Transparent;
                lblDatosAuto.Text = string.Empty;

                lblBienvenido.BackColor = Color.Transparent;
                

                Animacion_Principal.Dock = DockStyle.Fill;
                Animacion_PublicidadSecundaria.Size = new System.Drawing.Size(1024, 350);
                Animacion_PublicidadSecundaria.Location = new Point(0, 0);

                Animacion_RetireTarjeta.Size = new System.Drawing.Size(1024, 400);
                Animacion_RetireTarjeta.Location = new Point(0, 405);

                Imagen_Fondo.Dock = DockStyle.Fill;
                Imagen_SistemaSuspendido.Dock = DockStyle.Fill;
                Imagen_SistemaSuspendido.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_DisfruteVisita.Dock = DockStyle.Fill;
                Imagen_DisfruteVisita.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_VehiculoEntrando.Dock = DockStyle.Fill;
                Imagen_VehiculoEntrando.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_TarjetaInvalida.Dock = DockStyle.Fill;
                Imagen_TarjetaInvalida.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_DisfruteVisitaAuto.Dock = DockStyle.Fill;
                Imagen_DisfruteVisitaAuto.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_TarjetaSinRegistroSalida.Dock = DockStyle.Fill;
                Imagen_TarjetaSinRegistroSalida.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_AutoVencida.Dock = DockStyle.Fill;
                Imagen_AutoVencida.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_SinTarjetas.Dock = DockStyle.Fill;
                Imagen_SinTarjetas.BackgroundImageLayout = ImageLayout.Stretch;

                tmrTimeOut.Enabled = true;
                //tmrEnvioImagenes.Enabled = true;


                ok = true;

                General_Events = "(FrondEnd CargaRecursos): Carga Controles - OK";
            }
            catch (Exception ex)
            {
                General_Events = "Error (FrondEnd CargaRecursos): al cargar recursos. " + ex.ToString();
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
                Imagen_Fondo.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_Fondo_Principal.jpg"));
                Imagen_SistemaSuspendido.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_Sistema_Suspendido.jpg"));
                Imagen_DisfruteVisita.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_Disfrute_Visita.jpg"));
                Imagen_VehiculoEntrando.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_Vehiculo_Entrando.jpg"));
                Imagen_TarjetaInvalida.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_Tarjeta_Invalida.jpg"));
                Imagen_DisfruteVisitaAuto.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_Disfrute_VisitaAutorizado.jpg"));
                Imagen_TarjetaSinRegistroSalida.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_TarjetaSinRegistroSalida.jpg"));
                Imagen_AutoVencida.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_AutorizaicionVencida.jpg"));
                Imagen_SinTarjetas.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_SinTarjetas.jpg"));

                #endregion

                #region Botones

                /// Carga botones
                #endregion

                ok = true;

                General_Events = "(FrondEnd CargaImagenes): Carga Imagenes - OK";
            }
            catch (Exception ex)
            {
                General_Events = "Error (FrondEnd CargaImagenes): al cargar imagenes. " + ex.ToString();
            }

            return ok;
        }
        private bool CargaSonidos()
        {
            bool ok = false;

            try
            {
                _sPathBienvenido = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_Bienvenido.wav");
                _sPathAutoVencida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_AutoVencida.wav");
                _sPathSinTarjetasDispensador = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_SintarjetasDispensador.wav");
                _sPathSistemaSuspendido = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_SsistemaSuspendido.wav");
                _sPathTarjetaInvalida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_TarjetaInvalida.wav");
                _sPathTarjetaSinRegistroSalida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_TarjetaSinRegistroSalida.wav");
                _sPathVehiculoEntrando = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_VehiculoEntrando.wav");
                ok = true;

                //string sMensaje = "(FrondEnd CargaSonidos): Carga sonidos OK";
                //General_Events = sMensaje;
            }
            catch (Exception ex)
            {
                string sMensaje = "Error (FrondEnd CargaSonidos): al cargar sonidos. " + ex.ToString();
                //General_Events = sMensaje;
                //Presentacion = Pantalla.SistemaSuspendido;
                //_ErrorDiagnostico = "Sonidos";
            }
            return ok;
        }
        private bool CargaAnimaciones()
        {
            bool ok = false;

            try
            {

                string Principal = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Swf\Animacion_Principal.swf"));
                if (File.Exists(Principal))
                {
                    Animacion_Principal.Visible = true;
                    Animacion_Principal.Movie = Principal;
                    Animacion_Principal.CtlScale = "ExactFit";
                    Animacion_Principal.Play();
                    Animacion_Principal.BringToFront();
                }

                string PrincipalSecundario = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Swf\Animacion_PublicidadSecundaria.swf"));
                if (File.Exists(PrincipalSecundario))
                {
                    Animacion_PublicidadSecundaria.Visible = true;
                    Animacion_PublicidadSecundaria.Movie = PrincipalSecundario;
                    Animacion_PublicidadSecundaria.CtlScale = "ExactFit";
                    Animacion_PublicidadSecundaria.Play();
                    Animacion_PublicidadSecundaria.BringToFront();
                }

                string RetireTarjeta = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Swf\Animacion_RetirarTarjeta.swf"));
                if (File.Exists(RetireTarjeta))
                {
                    Animacion_RetireTarjeta.Visible = true;
                    Animacion_RetireTarjeta.Movie = RetireTarjeta;
                    Animacion_RetireTarjeta.CtlScale = "ExactFit";
                    Animacion_RetireTarjeta.Play();
                    Animacion_RetireTarjeta.BringToFront();
                }


                ok = true;

                //string sMensaje = "(FrondEnd CargaAnimaciones): Carga animaciones OK";
                //General_Events = sMensaje;
            }
            catch (Exception ex)
            {
                //string sMensaje = "Error (FrondEnd CargaAnimaciones): al cargar animaciones. " + ex.ToString();
                //General_Events = sMensaje;
                ok = false;
            }

            return ok;
        }
        private void RestablecerValores()
        {
            _IdCardAutorizado = string.Empty;
            SecuenciaTransaccion = string.Empty;
            RemoveCard = false;
            lblDatosAuto.Text = string.Empty;
            Ssuspe = 0;
            CntAuto = 0;
            _frmPrincipal_Presenter.LimpiarValoresPLC();
        }
        private async Task<bool> ConectarDispositivos()
        {
            //return true;
            bool ok = false;
            if (_frmPrincipal_Presenter.ConexionPLC())
            {
                if (_frmPrincipal_Presenter.LimpiarValoresPLC())
                {
                    _frmPrincipal_Presenter.ConectarDispensador();

                    if (KytReady)
                    {
                        _frmPrincipal_Presenter.AlistarTarjeta();

                        if (CardKytReady)
                        {
                            _frmPrincipal_Presenter.LimpiarTarjeta();
                            if (CleanCardKyt)
                            {
                                ok = true;
                            }
                        }
                    }
                }
            }
            if (ok)
            {
                _frmPrincipal_Presenter.ConectarCRT();
                ok = true;
                //RspConexion = Lector.Conectar();
                //if (RspConexion.Conectado)
                //{
                //    ok = true;
                //}
            }

            return ok;
        }
        private async Task<bool> CapturaCamara(string orden, string Secuencia)
        {
            //return true;
            bool ok = true;
            
            _frmPrincipal_Presenter.CapturaFoto(orden, Secuencia);
            Camara = false;
            return ok;
        }
        private void RegistroEntrada()
        {

            Presentacion = Pantalla.DisfruteVisita;

            _frmPrincipal_Presenter.AbrirTalanquera();

            Thread ohilo = new Thread(unused => _frmPrincipal_Presenter.CapturaFoto("2", SecuenciaTransaccion));
            ohilo.Start();

            //SecuenciaTransaccion = DateTime.Now.ToString("yyyyMMddHHmmss") + Globales.sCarril + Globales.iCodigoEstacionamiento;

            oTransaccion.IdAutorizado = 0;
            oTransaccion.CarrilEntrada = Convert.ToInt32(Globales.sCarril);
            oTransaccion.IdEstacionamiento = Convert.ToInt64(Globales.iCodigoEstacionamiento);
            oTransaccion.IdTarjeta = _IdCard;
            oTransaccion.IdTransaccion = Convert.ToInt64(SecuenciaTransaccion);
            oTransaccion.ModuloEntrada = Globales.sSerial;
            oTransaccion.PlacaEntrada = _sPlaca;
            if (VehiculoMoto)
            {
                oTransaccion.TipoVehiculo = 2;
            }
            else 
            {
                oTransaccion.TipoVehiculo = 1;
            }

            _frmPrincipal_Presenter.RegistrarEntrada(oTransaccion);

        }
        private void RegistroEntradaAutorizado(int Conteo)
        {


            //ESCRIBE TARJETA AUTORIZADO
            //SMARTCARD_PARKING_V1 oTarjeta = new SMARTCARD_PARKING_V1();

            //oTarjeta.ActiveCycle = true;
            //oTarjeta.EntranceModule = Globales.sSerial;
            //oTarjeta.DateTimeEntrance = _FechaCompleta;
            //oTarjeta.TypeCard = TYPE_TARJETAPARKING_V1.AUTHORIZED_PARKING;

            //Lector.EscribirTarjeta(oTarjeta, "M1LL3N", true, true);

            //_frmPrincipal_Presenter.WriteCard(_Tarjeta);
           
            /////////////////////////////////////////////////////////////////////////////////////////////////

            oTransaccion.CarrilEntrada = Convert.ToInt32(Globales.sCarril);
            oTransaccion.IdEstacionamiento = Convert.ToInt64(Globales.iCodigoEstacionamiento);
            oTransaccion.IdTarjeta = _IdCardAutorizado;
            oTransaccion.IdAutorizado = _lstDtoAutorizado[CntAuto].IdAutorizacion;
            oTransaccion.IdTransaccion = Convert.ToInt64(SecuenciaTransaccion);
            oTransaccion.ModuloEntrada = Globales.sSerial;

            oTransaccion.PlacaEntrada = _sPlaca;
            if (VehiculoMoto)
            {
                oTransaccion.TipoVehiculo = 2;
            }
            else
            {
                oTransaccion.TipoVehiculo = 1;
            }

            _frmPrincipal_Presenter.RegistrarEntrada(oTransaccion);



            lblDatosAuto.Text = "Sr/Sra " + _lstDtoAutorizado[CntAuto].NombresAutorizado;
            Presentacion = Pantalla.DisfruteVisitaAuto;


            Thread ohilo = new Thread(unused => _frmPrincipal_Presenter.CapturaFoto("1", SecuenciaTransaccion));
            ohilo.Start();  

            _frmPrincipal_Presenter.AbrirTalanquera();

           
           

        }
        //public void CapturaFoto(string Orden)
        //{
        //    string sFileName = string.Empty;

        //    //sFileName = ObtenerValorParametro(Parametros.RutaAlmacenamientoFotos) + sFileName;

        //    sFileName = @"C:\FOTOS\";

        //    if (!Directory.Exists(sFileName))
        //    {
        //        Directory.CreateDirectory(sFileName);
        //    }


        //    sFileName = sFileName + SecuenciaTransaccion + "_" + Globales.sSerial + "_DOMO1_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + Orden + ".jpg";
            
        //    //string sUrl = "http://" + ObtenerValorParametro(Parametros.IPCamara) + "/cgi-bin/media.cgi?action=getSnapshot";

        //    string sUrl = "http://192.168.1.64/Streaming/channels/101/picture";
        //    if (Generales.WebSiteIsAvailable(sUrl))
        //    {
        //        WebClient webClient = new WebClient();
        //        webClient.Credentials = new NetworkCredential("admin", "D3V3L0P9");
        //        try
        //        {
        //            webClient.DownloadFile(sUrl, sFileName);
        //        }
        //        catch (Exception e)
        //        {
        //            General_Events = "(Presenter CapturaFoto) Exception: " + e.InnerException + " " + e.Message + " " + e.Source;
        //        }
        //    }
        //    else
        //    {
        //        General_Events = "(Presenter CapturaFoto) Error: ALARMA CAMARA IP";
        //    }
        //}
        private void EnvioImagenes()
        {
            string currentDirName = @"C:\FOTOS";

            if (!Directory.Exists(currentDirName))
            {
                Directory.CreateDirectory(currentDirName);
            }

            string[] files = System.IO.Directory.GetFiles(currentDirName, "*.jpg");

            _Transaccion.ModuloEntrada = Globales.sSerial;
            _Transaccion.IdEstacionamiento = Convert.ToInt64(Globales.iCodigoEstacionamiento);

            try
            {
                List<Imagen> olstImagenes = new List<Imagen>();
                List<string> olstImagenesBorrar = new List<string>();

                if (Directory.Exists(currentDirName))
                {
                    DirectoryInfo info = new DirectoryInfo(currentDirName);
                    FileInfo[] oFiles = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                    if (oFiles.Length > 0)
                    {
                        cnt_timeout = 0;
                        foreach (FileInfo iFile in oFiles)
                        {
                            if (iFile.Name.Contains("Thumbs.db"))
                            {
                                continue;
                            }

                            FileStream fs = new FileStream(iFile.FullName, System.IO.FileMode.Open);
                            Image oImage = Image.FromStream(fs);

                            byte[] bImage = Generales.ImageToByteArray(oImage, ImageFormat.Jpeg);
                            Imagen oImagen = new Imagen();
                            oImagen.ContenidoImagen = bImage;
                            oImagen.NombreImagen = iFile.Name;

                            olstImagenes.Add(oImagen);
                            fs.Close();

                        }

                        if (olstImagenes != null)
                        {
                            if (olstImagenes.Count > 0)
                            {
                                if (_frmPrincipal_Presenter.EnvioImagenes(olstImagenes, _Transaccion))
                                {
                                    foreach (Imagen iImagen in olstImagenes)
                                    {
                                        File.Delete(Path.Combine(currentDirName, iImagen.NombreImagen));
                                    }                                    
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                General_Events = "(ERROR)" + "ERROR AL MOVER ARCHIVO " + ex.ToString();
                Presentacion = Pantalla.SistemaSuspendido;
            }
        }
        private void Sincronizacion()
        {
 
        }
        private void CapturaPlaca()
        {

            string Placa = string.Empty;

            try
            {
                string ipServer = _frmPrincipal_Presenter.ObtenerValorParametro(Parametros.IPLPR);
                General_Events = "(FrontEnd CapturaPlaca) ipServer: " + ipServer;

                string IDLPR = Globales.sIDLPR;
                Int32 port = Convert.ToInt32(Globales.sPuertoLPR);
                string message = "[lpr;" + IDLPR + ";1;242CF]";
                TcpClient client = new TcpClient(ipServer, port);

                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                General_Events = "(FrontEnd CapturaPlaca) message: " + message;

                data = new Byte[256];
                String responseData = String.Empty;

                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                string[] temp = responseData.Split(';');
                Placa = temp[4];
                General_Events = "(FrontEnd CapturaPlaca) Placa: " + Placa;

                if (Placa == string.Empty)
                {
                    Placa = "------";
                }

            }
            catch (Exception ex)
            {
                General_Events = "(FrontEnd ERROR CapturaPlaca) " + ex.ToString();
            }

             _sPlaca = Placa;

        }
        #endregion

        #region IView
        public Pantalla Presentacion
        {
            set
            {
                SoundPlayer simpleSound;

                switch (value)
                {

                    case Pantalla.SalvaPantallas:
                        _cnt_timeout = 0;
                        Animacion_Principal.BringToFront();
                        RestablecerValores();
                        break;

                    case Pantalla.RetireTarjeta:
                        _cnt_timeout = 0;
                        lblHoraINgreso.Text = "HORA INGRESO: " + DateTime.Now.ToString("HH:mm:ss");
                        Imagen_Fondo.BringToFront();
                        Animacion_PublicidadSecundaria.BringToFront();
                        Animacion_RetireTarjeta.BringToFront();
                        lblHoraINgreso.Parent = Imagen_Fondo;   
                        break;

                    case Pantalla.SistemaSuspendido:
                        _cnt_timeout = 0;
                        
                        if (!soundSuspen)
                        {
                            simpleSound = new SoundPlayer(_sPathSistemaSuspendido);
                            simpleSound.Play();
                            soundSuspen = true;
                        }

                        Imagen_SistemaSuspendido.BringToFront();
                        break;

                    case Pantalla.DisfruteVisita:
                        _cnt_timeout = 0;
                        Imagen_DisfruteVisita.BringToFront();                        
                        break;

                    case Pantalla.VehiculoEntrando:
                        _cnt_timeout = 0;
                        Imagen_VehiculoEntrando.BringToFront();
                        break;

                    case Pantalla.TarjetaInvalida:
                        _cnt_timeout = 0;
                        Imagen_TarjetaInvalida.BringToFront();
                        break;

                    case Pantalla.DisfruteVisitaAuto:
                        _cnt_timeout = 0;
                        Imagen_DisfruteVisitaAuto.BringToFront();
                        lblDatosAuto.Parent = Imagen_DisfruteVisitaAuto;
                        lblBienvenido.Parent = Imagen_DisfruteVisitaAuto;
                        lblDatosAuto.BringToFront();
                        lblBienvenido.BringToFront();
                        break;

                    case Pantalla.TarjetaSinRegistroSalida:
                        _cnt_timeout = 0;
                        Imagen_TarjetaSinRegistroSalida.BringToFront();
                        break;
                    case Pantalla.AutorizacionVencida:
                        _cnt_timeout = 0;
                        Imagen_AutoVencida.BringToFront();
                        break;
                    case Pantalla.SinTarjetas:
                        _cnt_timeout = 0;

                        if (!soundSinTar)
                        {
                            simpleSound = new SoundPlayer(_sPathSinTarjetasDispensador);
                            simpleSound.Play();
                            soundSinTar = true;
                        }

                        Imagen_SinTarjetas.BringToFront();
                        break;
                }

                _Presentacion = value;
            }
            get
            {
                return _Presentacion;
            }
        }
        public string General_Events
        {
            set
            {
                TraceHandler.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs\Log"), "MENSAJE: " + value, TipoLog.TRAZA);
            }
        }
        #endregion

        #region PLC
        private void btn_llegoCarro_Click(object sender, EventArgs e)
        {

            SecuenciaTransaccion = DateTime.Now.ToString("yyyyMMddHHmmss") + oTransaccion.CarrilEntrada + 2;

            Presentacion = Pantalla.RetireTarjeta;


            //_Tarjeta.CarrilEntrada = Globales.sCarril;
            //_Tarjeta.CicloActivo = true;
            //_Tarjeta.FechaHoraEntrada = DateTime.Now;
            //_Tarjeta.ModuloEntrada = Globales.sSerial;


            _frmPrincipal_Presenter.EscribirCard(_Tarjeta,false);

            if (_WriteCard)
            {
                _frmPrincipal_Presenter.DispensarTarjeta();
            }
            else
            {
                _frmPrincipal_Presenter.AlistarTarjeta();
            }

            //CapturaFoto("1");

        }
        private void btn_CarroBarrera_Click(object sender, EventArgs e)
        {
            Presentacion = Pantalla.VehiculoEntrando;
            _frmPrincipal_Presenter.AlistarTarjeta();
            _frmPrincipal_Presenter.LimpiarTarjeta();
            //CapturaFoto("2");
        }
        private void btn_CarroFuera_Click(object sender, EventArgs e)
        {
            //CapturaFoto("3");
            Presentacion = Pantalla.SalvaPantallas;
        }
        #endregion

      
    }
}
   
