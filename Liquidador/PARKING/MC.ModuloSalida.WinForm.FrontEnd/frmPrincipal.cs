using EGlobalT.Device.SmartCard;
using EGlobalT.Device.SmartCardReaders;
using EGlobalT.Device.SmartCardReaders.Entities;
using MC.BusinessObjects.DataTransferObject;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using MC.ModuloSalida.WinForm.Presenter;
using MC.ModuloSalida.WinForm.View;
using MC.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC.ModuloSalida.WinForm.FrontEnd
{
    public partial class frmPrincipal : Form, IView_Principal
    {
        #region Rutas

        //Audio
        private string _sPathInserteTarjeta = string.Empty;
        private string _sPathAutoVencida = string.Empty;
        private string _sPathExcedioTiempo = string.Empty;
        private string _sPathSistemaSuspendido = string.Empty;
        private string _sPathTarjetaInvalida = string.Empty;
        private string _sPathTarjetaSinRegistroEntrada = string.Empty;
        private string _sPathVehiculoSaliendo = string.Empty;
        private string _sPathGraciasVisita = string.Empty;
        private string _sPathProcesandoTransaccion = string.Empty;
        private string _sPathSinPago = string.Empty;

        #endregion

        #region Definiciones
        private string _sPlaca = string.Empty;
        public string sPlaca
        {
            get { return sPlaca; }
            set { sPlaca = value; }
        }
        Lectora_CRT602U Lector = new Lectora_CRT602U();
        Rspsta_Conexion_LECTOR RspConexion = new Rspsta_Conexion_LECTOR();
        Rspsta_DetectarTarjeta_LECTOR RspDetectar = new Rspsta_DetectarTarjeta_LECTOR();
        Rspsta_CodigoTarjeta_LECTOR RspIdCard = new Rspsta_CodigoTarjeta_LECTOR();
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
        private List<DtoTarjetas> _lstDtoTarjetas = new List<DtoTarjetas>();
        public List<DtoTarjetas> lstDtoTarjetas
        {
            get { return _lstDtoTarjetas; }
            set { _lstDtoTarjetas = value; }
        }
        int CntAuto = 0;
        bool soundSuspen = false;
        int Ssuspe = 0;
        bool soundSinTar = false;
        int SsinTar = 0;
        bool InfoModulo = false;
        private bool _CardKytReceptorReady = false;
        public bool CardKytReceptorReady
        {
            get { return _CardKytReceptorReady; }
            set { _CardKytReceptorReady = value; }
        }
        private bool _CardReadKytReceptorReady = false;
        public bool CardReadKytReceptorReady
        {
            get { return _CardReadKytReceptorReady; }
            set { _CardReadKytReceptorReady = value; }
        }
        private List<DtoDatosLiquidacion> _lstDtoLiquidacion = new List<DtoDatosLiquidacion>();
        public List<DtoDatosLiquidacion> lstDtoLiquidacion
        {
            get { return _lstDtoLiquidacion; }
            set { _lstDtoLiquidacion = value; }
        }
        private string _ValorAPagar = string.Empty;
        public string ValorAPagar
        {
            get { return _ValorAPagar; }
            set { _ValorAPagar = value; }
        }
        private string _Horas = string.Empty;
        public string Horas
        {
            get { return _Horas; }
            set { _Horas = value; }
        }
        private string _Barrera = string.Empty;
        public string Barrera
        {
            get { return _Barrera; }
            set { _Barrera = value; }
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

                    //Presentacion = Pantalla.InserteTarjeta;
                    //_frmPrincipal_Presenter.ConectarCRT();

                    if (_frmPrincipal_Presenter.TestConexionDispositivos())
                    {
                        if (_frmPrincipal_Presenter.VehiculoMueble())
                        {

                            SoundPlayer simpleSound = new SoundPlayer(_sPathInserteTarjeta);
                            simpleSound.Play();

                            Presentacion = Pantalla.InserteTarjeta;
                        }
                        if (_frmPrincipal_Presenter.ObtenerEventoDispo())
                        {
                            string[] Resul = _Barrera.Split(';');

                            if (Resul[0].ToString() == Globales.sSerial)
                            {
                                _frmPrincipal_Presenter.AbrirTalanquera();
                            }
                            if (Resul[0].ToString() == Globales.sSerial)
                            {
                                _frmPrincipal_Presenter.ActualizarEventoDispo(Convert.ToInt64(Resul[1]));
                            }
                        }
                    }
                    break;

                case Pantalla.SistemaSuspendido:

                    if (!InfoModulo)
                    {
                        _frmPrincipal_Presenter.TestConexionSuspendidoDispositivos();
                    }
                    if (Ssuspe == 45)
                    {
                        soundSuspen = false;
                        Ssuspe = 0;
                    }

                    break;

                case Pantalla.InserteTarjeta:

                    if (_frmPrincipal_Presenter.ObtenerEventoDispo())
                    {
                        string[] Resul = _Barrera.Split(';');

                        if (Resul[0].ToString() == Globales.sSerial)
                        {
                            _frmPrincipal_Presenter.AbrirTalanquera();
                        }
                        if (Resul[0].ToString() == Globales.sSerial)
                        {
                            _frmPrincipal_Presenter.ActualizarEventoDispo(Convert.ToInt64(Resul[1]));
                        }
                    }

                    //CapturaPlaca();
                    _frmPrincipal_Presenter.DetectarTarjeta();
                    _frmPrincipal_Presenter.GetIdCard();
                    //RspDetectar = Lector.DetectarTarjeta();
                    
                    


                    bool bAutoVencida = false;
                    bool bTarjetaInvalida = false;
                    bool ok = false;


                    if (_CardKytReceptorReady)
                    {
                        Presentacion = Pantalla.ProcesandoTransaccion;
                        _frmPrincipal_Presenter.LeerTarjeta();
                    }
                    else if (_IdCardAutorizado != string.Empty)
                    {
                        //RspIdCard = Lector.ObtenerIDTarjeta();
                        CntAuto = 0;
                        bool TarOK = false;
                        //VALIDAR AUTORIZADO
                        Autorizado oAutorizado = new Autorizado();
                        oAutorizado.IdTarjeta = _IdCardAutorizado;
                        _Tarjeta.CodeCard = oAutorizado.IdTarjeta;
                        General_Events = "ID TARJETA = " + oAutorizado.IdTarjeta;

                        if (_frmPrincipal_Presenter.ObtenerTarjetas())
                        {
                            for (int i = 0; i < _lstDtoTarjetas.Count; i++)
                            {

                                if (_lstDtoTarjetas[i].IdTarjeta == oAutorizado.IdTarjeta && _lstDtoTarjetas[i].Estado)
                                {
                                    General_Events = "TARJETA ESTADO TRUE";
                                    TarOK = true;
                                    break;
                                }
                            }
                        }

                        if (TarOK)
                        {
                            if (_frmPrincipal_Presenter.ObtenerAutorizado(oAutorizado))
                            {
                                General_Events = "Obtener Datos Autorizado ok";

                                
                                /// validaciones autorizado

                                for (int i = 0; i < _lstDtoAutorizado.Count; i++)
                                {

                                    if (oAutorizado.IdTarjeta == _lstDtoAutorizado[i].IdTarjeta)
                                    {

                                        General_Events = "Comparacion IDTARJETA OK";

                                        if (_lstDtoAutorizado[i].IdEstacionamiento == Convert.ToInt64(Globales.iCodigoEstacionamiento))
                                        {
                                            General_Events = "Comparacion IDESTACIONAMIENTO OK";

                                            if (_lstDtoAutorizado[i].EstadoAutorizacion && _lstDtoAutorizado[i].Estado && DateTime.Now >= _lstDtoAutorizado[i].FechaInicial && DateTime.Now <= _lstDtoAutorizado[i].FechaFinal)
                                            {
                                                General_Events = "Validacion Fechas Vigencia ok";

                                                if (_frmPrincipal_Presenter.ValidarSalidaAuto(oAutorizado.IdTarjeta) == true)
                                                {
                                                    ok = true;
                                                    bAutoVencida = false;
                                                    bTarjetaInvalida = false; 
                                                    CntAuto = i;
                                                    break;
                                                }
                                                else
                                                {
                                                    SoundPlayer simpleSound = new SoundPlayer(_sPathTarjetaSinRegistroEntrada);
                                                    simpleSound.Play();
                                                    Presentacion = Pantalla.TarjetaSinRegistroEntrada;
                                                    break;
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
                                    RegistroSalidaAutorizado(CntAuto);
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
                        if (cnt_timeout == (int)TimeOut.TimeOut_InserteTarjeta)
                        {
                            _frmPrincipal_Presenter.DispensarTarjeta();
                            Presentacion = Pantalla.SalvaPantallas;
                        }
                    }
                    break;

                case Pantalla.ProcesandoTransaccion:

                    if (_CardReadKytReceptorReady)
                    {
                        General_Events = "CardReadKytReceptorReady = TRUE";

                        if (_Tarjeta.ActiveCycle == false)
                        {
                            _frmPrincipal_Presenter.DispensarTarjeta();

                            SoundPlayer simpleSound = new SoundPlayer(_sPathTarjetaSinRegistroEntrada);
                            simpleSound.Play();
                            Presentacion = Pantalla.TarjetaSinRegistroEntrada;
                        }
                        else
                        {
                            try
                            {

                                bTarjetaInvalida = true;
                                General_Events = "FRONT END OBTENER TARJETAS";
                                if (_frmPrincipal_Presenter.ObtenerTarjetas())
                                {
                                    for (int i = 0; i < _lstDtoTarjetas.Count; i++)
                                    {

                                        if (_lstDtoTarjetas[i].IdTarjeta == _Tarjeta.CodeCard)
                                        {
                                            DateTime Entrada = Convert.ToDateTime(_Tarjeta.DateTimeEntrance);
                                            string IdTransaccion = Entrada.ToString("yyyyMMddHHmmss");
                                            int Carril = 0;

                                            if (_Tarjeta.EntranceModule.Length > 5)
                                            {
                                                string temp = _Tarjeta.EntranceModule.Substring(4, 2);
                                                Carril = Convert.ToInt32(temp);
                                            }
                                            else
                                            {
                                                string Modulo = _Tarjeta.EntranceModule;
                                                if (Modulo == "ADM01")
                                                {
                                                    Carril = 30;
                                                }
                                                else
                                                {
                                                    Carril = 31;
                                                }
                                            }

                                            SecuenciaTransaccion = IdTransaccion + Carril + Globales.iCodigoEstacionamiento;



                                            General_Events = "Front End Secuencia IdTranasaccion: " + SecuenciaTransaccion;



                                            if (ValidarSalida(SecuenciaTransaccion))
                                            {
                                                RegistroSalida();
                                                bTarjetaInvalida = false;
                                                break;
                                            }
                                            else
                                            {
                                                _frmPrincipal_Presenter.DispensarTarjeta();
                                                bTarjetaInvalida = false;
                                                break;
                                            }

                                        }
                                    }

                                    if (bTarjetaInvalida)
                                    {
                                        Presentacion = Pantalla.TarjetaInvalida;
                                    }

                                }
                                else
                                {
                                    Presentacion = Pantalla.TarjetaInvalida;
                                }

                            }
                            catch (Exception ex)
                            {
                                General_Events = "ERROR" + ex.ToString();
                            }
                        }
                    }
                    else
                    {
                        if (cnt_timeout == (int)TimeOut.TimeOut_TarjetaMocha)
                        {
                            cnt_timeout = 0;
                            _frmPrincipal_Presenter.DispensarTarjeta();
                            SoundPlayer simpleSound = new SoundPlayer(_sPathTarjetaInvalida);
                            simpleSound.Play();
                            Presentacion = Pantalla.TarjetaInvalida;
                        }
                    }
                    break;

                case Pantalla.GraciasVisita:
                    if (_frmPrincipal_Presenter.VehiculoTalanquera())
                    {
                        bool sound = false;
                        if (!sound)
                        {
                            SoundPlayer simpleSound = new SoundPlayer(_sPathVehiculoSaliendo);
                            simpleSound.Play();
                            sound = true;
                        }
                        Presentacion = Pantalla.VehiculoSaliendo;
                    }
                    break;
                case Pantalla.GraciasVisitaAuto:
                    if (_frmPrincipal_Presenter.VehiculoTalanquera())
                    {
                        bool sound = false;

                        if (!sound)
                        {
                            SoundPlayer simpleSound = new SoundPlayer(_sPathVehiculoSaliendo);
                            simpleSound.Play();
                            sound = true;
                        }
                        Presentacion = Pantalla.VehiculoSaliendo;
                    }
                    break;
                case Pantalla.VehiculoSaliendo:
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

                case Pantalla.TarjetaSinRegistroEntrada:
                    if (cnt_timeout == (int)TimeOut.TimeOut_Alertas)
                    {
                        Presentacion = Pantalla.SalvaPantallas;
                    }
                    break;

                case Pantalla.TarjetaSinPago:
                    if (cnt_timeout == (int)TimeOut.TimeOut_Alertas)
                    {
                        Presentacion = Pantalla.SalvaPantallas;
                    }
                    break;

                case Pantalla.ExcedioTiempo:
                    if (cnt_timeout == (int)TimeOut.TimeOut_Alertas)
                    {
                        Presentacion = Pantalla.SalvaPantallas;
                    }
                    break;

                case Pantalla.AutorizacionVence1:
                    if (_frmPrincipal_Presenter.VehiculoTalanquera())
                    {
                        bool sound = false;

                        if (!sound)
                        {
                            SoundPlayer simpleSound = new SoundPlayer(_sPathVehiculoSaliendo);
                            simpleSound.Play();
                            sound = true;
                        }
                        Presentacion = Pantalla.VehiculoSaliendo;
                    }
                    break;
                case Pantalla.AutorizacionVence2:
                    if (_frmPrincipal_Presenter.VehiculoTalanquera())
                    {
                        bool sound = false;

                        if (!sound)
                        {
                            SoundPlayer simpleSound = new SoundPlayer(_sPathVehiculoSaliendo);
                            simpleSound.Play();
                            sound = true;
                        }
                        Presentacion = Pantalla.VehiculoSaliendo;
                    }
                    break;
                case Pantalla.AutorizacionVence3:
                    if (_frmPrincipal_Presenter.VehiculoTalanquera())
                    {
                        bool sound = false;

                        if (!sound)
                        {
                            SoundPlayer simpleSound = new SoundPlayer(_sPathVehiculoSaliendo);
                            simpleSound.Play();
                            sound = true;
                        }
                        Presentacion = Pantalla.VehiculoSaliendo;
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

            _frmPrincipal_Presenter.Liquidar("BE8CC5CB", 1, true, false, "");
            //ValidarSalida("2019111418004021");
            //_frmPrincipal_Presenter.ValidarSalidaAuto("FB3059D0");
         
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
                lblDatosAuto.BackColor = Color.Transparent;
                lblDatosAuto.Text = string.Empty;

                lblVuelvaPronto.BackColor = Color.Transparent;


                Animacion_Principal.Dock = DockStyle.Fill;
                Animacion_PublicidadSecundaria.Size = new System.Drawing.Size(1024, 500);
                Animacion_PublicidadSecundaria.Location = new Point(0, 0);

                Animacion_InserteTarjeta.Size = new System.Drawing.Size(1024, 380);
                Animacion_InserteTarjeta.Location = new Point(0, 400);


                Imagen_Fondo.Dock = DockStyle.Fill;
                Imagen_SistemaSuspendido.Dock = DockStyle.Fill;
                Imagen_SistemaSuspendido.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_TarjetaInvalida.Dock = DockStyle.Fill;
                Imagen_TarjetaInvalida.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_TarjetaSinRegistroEntrada.Dock = DockStyle.Fill;
                Imagen_TarjetaSinRegistroEntrada.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_AutoVencida.Dock = DockStyle.Fill;
                Imagen_AutoVencida.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_VehiculoSaliendo.Dock = DockStyle.Fill;
                Imagen_VehiculoSaliendo.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_SinPago.Dock = DockStyle.Fill;
                Imagen_SinPago.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_ProcesandoTransaccion.Dock = DockStyle.Fill;
                Imagen_ProcesandoTransaccion.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_GraciasVisita.Dock = DockStyle.Fill;
                Imagen_GraciasVisita.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_ExcedioTiempo.Dock = DockStyle.Fill;
                Imagen_ExcedioTiempo.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_GraciasVistaAuto.Dock = DockStyle.Fill;
                Imagen_GraciasVistaAuto.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_AutoVence1.Dock = DockStyle.Fill;
                Imagen_AutoVence1.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_AutoVence2.Dock = DockStyle.Fill;
                Imagen_AutoVence2.BackgroundImageLayout = ImageLayout.Stretch;
                Imagen_AutoVence3.Dock = DockStyle.Fill;
                Imagen_AutoVence3.BackgroundImageLayout = ImageLayout.Stretch;

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
                Imagen_TarjetaInvalida.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_Tarjeta_Invalida.jpg"));
                Imagen_TarjetaSinRegistroEntrada.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_TarjetaSinEntrada.jpg"));
                Imagen_AutoVencida.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_AutorizaicionVencida.jpg"));
                Imagen_AutoVence1.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_AutorizaicionVencida1Dia.jpg"));
                Imagen_AutoVence2.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_AutorizaicionVencida2Dias.jpg"));
                Imagen_AutoVence3.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_AutorizaicionVencida3Dias.jpg"));

                Imagen_VehiculoSaliendo.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_VehiculoSaliendo.jpg"));
                Imagen_SinPago.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_SinPago.jpg"));
                Imagen_ProcesandoTransaccion.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_ProcesandoTransaccion.jpg"));
                Imagen_GraciasVisita.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_GraciasVisita.jpg"));
                Imagen_ExcedioTiempo.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_ExcedisteTiempo.jpg"));
                Imagen_GraciasVistaAuto.BackgroundImage = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Jpg\Imagen_GraciasVisitaAuto.jpg"));
                


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
                _sPathInserteTarjeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_InserteTarjeta.wav");
                _sPathAutoVencida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_AutoVencida.wav");
                _sPathExcedioTiempo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_ExcedioTiempo.wav");
                _sPathSistemaSuspendido = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_SsistemaSuspendido.wav");
                _sPathTarjetaInvalida = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_TarjetaInvalida.wav");
                _sPathTarjetaSinRegistroEntrada = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_TrajetaSinEntrada.wav");
                _sPathVehiculoSaliendo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_VehiculoSaliendo.wav");
                _sPathGraciasVisita = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_GraciasVisita.wav");
                _sPathProcesandoTransaccion = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_ProcesandoTransaccion.wav");
                _sPathSinPago = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Wav\Sonido_SinPago.wav");

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

                string RetireTarjeta = (Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Medios\Swf\Animacion_InserteTarjeta.swf"));
                if (File.Exists(RetireTarjeta))
                {
                    Animacion_InserteTarjeta.Visible = true;
                    Animacion_InserteTarjeta.Movie = RetireTarjeta;
                    Animacion_InserteTarjeta.CtlScale = "ExactFit";
                    Animacion_InserteTarjeta.Play();
                    Animacion_InserteTarjeta.BringToFront();
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
            _CardKytReady = false;
            _CardKytReceptorReady = false;
            _CardReadKytReceptorReady = false;
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
                    _frmPrincipal_Presenter.ConectarReceptor();

                    if (KytReady)
                    {
                        ok = true;
                    }
                }
            }
            if (ok)
            {
                _frmPrincipal_Presenter.ConectarCRT();
                if (CRTReady)
                {
                    ok = true;
                }
            }
         
            return ok;
        }
        private void RegistroSalida()
        {

            Presentacion = Pantalla.GraciasVisita;

            _frmPrincipal_Presenter.AbrirTalanquera();


            SoundPlayer simpleSound = new SoundPlayer(_sPathGraciasVisita);
            simpleSound.Play();

            Thread ohilo = new Thread(unused => _frmPrincipal_Presenter.CapturaFoto("1", SecuenciaTransaccion));
            ohilo.Start();

            oTransaccion.CarrilSalida = Convert.ToInt32(Globales.sCarril);
            oTransaccion.IdEstacionamiento = Convert.ToInt64(Globales.iCodigoEstacionamiento);
            oTransaccion.IdTarjeta = _Tarjeta.CodeCard;
            oTransaccion.IdTransaccion = Convert.ToInt64(SecuenciaTransaccion);
            oTransaccion.ModuloSalida = Globales.sSerial;
            oTransaccion.PlacaSalida = _sPlaca;

            _frmPrincipal_Presenter.RegistrarSalida(oTransaccion);


            _frmPrincipal_Presenter.CapturarTarjeta();

        }
        private void RegistroSalidaAutorizado(int Conteo)
        {

            //SecuenciaTransaccion = "2017032612371512";
            DateTime Entrada = Convert.ToDateTime(_Tarjeta.DateTimeEntrance);
            string IdTransaccion = Entrada.ToString("yyyyMMddHHmmss");
            int Carril = 0;
            
            string Modulo = _Tarjeta.EntranceModule;
            if (Modulo == "ADM01")
            {
                Carril = 30;
            }
            else
            {
                Carril = 31;
            }
            SecuenciaTransaccion = IdTransaccion + Carril + Globales.iCodigoEstacionamiento;
            General_Events = "Secuencia " + SecuenciaTransaccion;
            DateTime fechahoy = DateTime.Now;
            DateTime fechafinauto = Convert.ToDateTime(_lstDtoAutorizado[CntAuto].FechaFinal);

            DateTime FechaEntrada = fechahoy;
            DateTime FechaActual = fechafinauto;
            TimeSpan Calculo = FechaActual - FechaEntrada;

            if (Calculo.Days == 3)
            {
                Presentacion = Pantalla.AutorizacionVence3;
            }
            else if (Calculo.Days == 2)
            {
                Presentacion = Pantalla.AutorizacionVence2;
            }
            else if (Calculo.Days == 1)
            {
                Presentacion = Pantalla.AutorizacionVence1;
            }
            else 
            {
                lblDatosAuto.Text = "Sr/Sra " + _lstDtoAutorizado[CntAuto].NombresAutorizado;
                Presentacion = Pantalla.GraciasVisitaAuto;
            }
                       

            Thread ohilo = new Thread(unused => _frmPrincipal_Presenter.CapturaFoto("1", SecuenciaTransaccion));
            ohilo.Start();

           
            //ESCRIBE TARJETA AUTORIZADO
            _Tarjeta.ActiveCycle = false;
            _Tarjeta.EntranceModule = "";
            _Tarjeta.DateTimeEntrance = null;
            _Tarjeta.TypeCard = TYPE_TARJETAPARKING_V1.AUTHORIZED_PARKING;

            _frmPrincipal_Presenter.WriteCard(_Tarjeta);
            //Lector.EscribirTarjeta(oTarjeta, "florid", true, true);
            /////////////////////////////////////////////////////////////////////////////////////////////////

            _frmPrincipal_Presenter.AbrirTalanquera();

            SoundPlayer simpleSound = new SoundPlayer(_sPathGraciasVisita);
            simpleSound.Play();


            oTransaccion.CarrilSalida = Convert.ToInt32(Globales.sCarril);
            oTransaccion.IdTarjeta = _lstDtoAutorizado[CntAuto].IdTarjeta;
            oTransaccion.IdTransaccion = Convert.ToInt64(SecuenciaTransaccion);
            oTransaccion.ModuloSalida = Globales.sSerial;
            oTransaccion.IdEstacionamiento = Convert.ToInt64(Globales.iCodigoEstacionamiento);
            oTransaccion.PlacaSalida = "------";

            General_Events = "RegistrarSalida ";

            _frmPrincipal_Presenter.RegistrarSalida(oTransaccion);

        }
        private bool ValidarSalida(string SecuenciaTransaccion)
        {

            bool ok = false;
            //SecuenciaTransaccion = "2018122013421928";

            try
            {
                Liquidacion oLiquidacion = new Liquidacion();


                if (_Tarjeta.Courtesy == false)
                {
                    //_Tarjeta.PaymentDateTime = Convert.ToDateTime("25/05/2018 3:26:29 p. m.");
                    DateTime ff = Convert.ToDateTime(_Tarjeta.PaymentDateTime);
                    General_Events = ff.ToString();
                    if (ff.Year != 0001)
                    {
                        General_Events = "ANTES DE OBTENER EVENTO";
                        //VALIDAR EVENTO 
                        _frmPrincipal_Presenter.ObtenerEvento(Convert.ToInt64(SecuenciaTransaccion));
                        //////////////                    
                        General_Events = "DESPUES DE OBTENER EVENTO";
                        DateTime FechaPago = Convert.ToDateTime(_Tarjeta.PaymentDateTime);
                        DateTime FechaActual = DateTime.Now;

                        TimeSpan Calculo = FechaActual - FechaPago;

                        General_Events = "HORAS " + _Horas;
                        if (_Horas != string.Empty)
                        {
                            General_Events = "HORAS NO ES VACIO";
                            #region CalculoTiempo
                            double TotalHoras = Calculo.TotalHours;
                            int TotalMinutes = Convert.ToInt32(Calculo.TotalMinutes);
                            double valorConDecimal = TotalHoras;
                            long valorSinDecimal = (long)valorConDecimal;
                            double decimales = valorConDecimal - (double)valorSinDecimal;
                            General_Events = "valorSinDecimal " + decimales;

                            valorSinDecimal = (long)TotalHoras;


                            if (valorSinDecimal <= 0)
                            {
                                valorSinDecimal = 1;
                            }
                            #endregion

                            long tiempofinal = valorSinDecimal - Convert.ToInt64(_Horas);

                            if (tiempofinal <= 0)
                            {
                                tiempofinal = 0;
                                General_Events = "TIMEPO FINAL = 0";
                                //ok = true;
                            }
                            else
                            {
                                General_Events = "TIMEPO FINAL > 0";
                                oLiquidacion.IdTipoPago = 1;
                                oLiquidacion.Convenios = _Tarjeta.CodeAgreement1 + ";" + _Tarjeta.CodeAgreement2 + ";" + _Tarjeta.CodeAgreement3 + ";" + _Tarjeta.CodeAgreement4;
                                oLiquidacion.Convenios = oLiquidacion.Convenios.TrimEnd(';', ' ');
                                oLiquidacion.Secuencia = SecuenciaTransaccion;

                                General_Events = "ANTES DE LIQUIDAR";
                                if (_frmPrincipal_Presenter.Liquidar(oLiquidacion.Secuencia.ToString(), Convert.ToInt32(oLiquidacion.IdTipoPago), false, false, oLiquidacion.Convenios))
                                {
                                    General_Events = "LIQUIDAR OK";
                                    //for (int i = 0; i < _lstDtoLiquidacion.Count; i++)
                                    //{
                                    double Valor = Convert.ToDouble(_ValorAPagar);
                                    if (Valor > 0)
                                    {
                                        SoundPlayer simpleSound = new SoundPlayer(_sPathSinPago);
                                        simpleSound.Play();
                                        Presentacion = Pantalla.TarjetaSinPago;
                                        ok = false;
                                        //break;
                                    }
                                    else
                                    {
                                        ok = true;
                                    }
                                    //}

                                }
                                else
                                {
                                    General_Events = "ERROR AL LIQUIDAR";
                                }
                            }
                        }
                        else
                        {
                            General_Events = "HORAS VACIO CALCULA TIMEPO DE REPAGO";
                            double TotalMinutos = Calculo.TotalMinutes;

                            if (TotalMinutos > Convert.ToInt32(_frmPrincipal_Presenter.ObtenerValorParametro(Parametros.Repago)))
                            {
                                SoundPlayer simpleSound = new SoundPlayer(_sPathExcedioTiempo);
                                simpleSound.Play();
                                Presentacion = Pantalla.ExcedioTiempo;
                                ok = false;
                            }
                            else
                            {
                                ok = true;
                            }
                        }
                    }
                    else
                    {
                        //DateTime FechaPago = Convert.ToDateTime("2019-06-26 17:24:17");
                        DateTime FechaPago = Convert.ToDateTime(_Tarjeta.DateTimeEntrance);
                        DateTime FechaActual = DateTime.Now;
                        TimeSpan Calculo = FechaActual - FechaPago;

                        oLiquidacion.IdTipoPago = 1;
                        //oLiquidacion.Convenios = "3" + ";" + "" + ";" + "" + ";" + "";
                        //oLiquidacion.Convenios = _Tarjeta.CodeAgreement1 + ";" + _Tarjeta.CodeAgreement2 + ";" + _Tarjeta.CodeAgreement3;
                        oLiquidacion.Convenios = _Tarjeta.CodeAgreement1.ToString();
                        //oLiquidacion.Convenios = oLiquidacion.Convenios.TrimEnd(';', ' ');
                        oLiquidacion.Secuencia = SecuenciaTransaccion;
                        //ok = true;

                        if (_frmPrincipal_Presenter.Liquidar(oLiquidacion.Secuencia.ToString(), Convert.ToInt32(oLiquidacion.IdTipoPago), false, false, oLiquidacion.Convenios))
                        {

                            //for (int i = 0; i < _lstDtoLiquidacion.Count; i++)
                            //{
                            if (_ValorAPagar != string.Empty)
                            {
                                double Valor = Convert.ToDouble(_ValorAPagar);
                                if (Valor <= 0)
                                {
                                    ok = true;
                                    //break;
                                }
                                else
                                {
                                    SoundPlayer simpleSound = new SoundPlayer(_sPathSinPago);
                                    simpleSound.Play();
                                    Presentacion = Pantalla.TarjetaSinPago;
                                    //break;
                                }
                                //}
                            }
                            else 
                            {
                                ok = false;
                            }
                        }
                        else
                        {
                            ok = false;
                        }
                    }
                }
                else
                {
                    ok = true;
                }

            }
            catch (Exception ex)
            {
                General_Events = "Error" + ex.ToString();
            }

            return ok;
        }
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

                    case Pantalla.InserteTarjeta:
                        _cnt_timeout = 0;
                        Imagen_Fondo.BringToFront();
                        Animacion_PublicidadSecundaria.BringToFront();
                        Animacion_InserteTarjeta.BringToFront();
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

                    case Pantalla.TarjetaInvalida:
                        _cnt_timeout = 0;
                        Imagen_TarjetaInvalida.BringToFront();
                        break;

                    case Pantalla.TarjetaSinRegistroEntrada:
                        _cnt_timeout = 0;
                        Imagen_TarjetaSinRegistroEntrada.BringToFront();
                        break;
                    
                    case Pantalla.AutorizacionVencida:
                        _cnt_timeout = 0;
                        Imagen_AutoVencida.BringToFront();
                        break;
                    
                    case Pantalla.VehiculoSaliendo:
                        _cnt_timeout = 0;
                        Imagen_VehiculoSaliendo.BringToFront();
                        break;
                    
                    case Pantalla.TarjetaSinPago:
                        _cnt_timeout = 0;
                        Imagen_SinPago.BringToFront();
                        break;

                    case Pantalla.ProcesandoTransaccion:
                        _cnt_timeout = 0;
                        Imagen_ProcesandoTransaccion.BringToFront();
                        break;

                    case Pantalla.GraciasVisita:
                        _cnt_timeout = 0;
                        Imagen_GraciasVisita.BringToFront();
                        break;

                    case Pantalla.ExcedioTiempo:
                        _cnt_timeout = 0;
                        Imagen_ExcedioTiempo.BringToFront();
                        break;

                    case Pantalla.GraciasVisitaAuto:
                        _cnt_timeout = 0;
                        Imagen_GraciasVistaAuto.BringToFront();
                        lblDatosAuto.Parent = Imagen_GraciasVistaAuto;
                        lblVuelvaPronto.Parent = Imagen_GraciasVistaAuto;
                        lblDatosAuto.BringToFront();
                        lblVuelvaPronto.BringToFront();
                        break;
                    case Pantalla.AutorizacionVence1:
                        _cnt_timeout = 0;
                        Imagen_AutoVence1.BringToFront();
                        break;
                    case Pantalla.AutorizacionVence2:
                        _cnt_timeout = 0;
                        Imagen_AutoVence2.BringToFront();
                        break;
                    case Pantalla.AutorizacionVence3:
                        _cnt_timeout = 0;
                        Imagen_AutoVence3.BringToFront();
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
        public DtoTarjetas oDtoTarjetas
        {
            set
            {
                oDtoTarjetas = value;
            }
        }
        #endregion

    }
}
