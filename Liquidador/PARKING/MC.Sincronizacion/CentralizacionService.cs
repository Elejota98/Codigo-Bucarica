using MC.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MC.Sincronizacion
{
    public partial class CentralizacionService : ServiceBase
    {

        #region Definiciones


        private Timer oTimer;

        private static object objLock = new object();
        private static CentralizacionService Agente = new CentralizacionService();
        private static ServiceProxy.IProxyService _ProxyServicios;


        private static int _PeriodoEjecucionSegundos
        {
            get
            {
                string sPeriodoEjecucionSegundos = ConfigurationManager.AppSettings["PeriodoEjecucionSegundos"];
                if (string.IsNullOrEmpty(sPeriodoEjecucionSegundos))
                {
                    return 10;
                }
                else
                {
                    return Convert.ToInt32(sPeriodoEjecucionSegundos);
                }
            }
        }

        private static int _NumeroImagenesModulo
        {
            get
            {
                string sNumeroImagenesModulo = ConfigurationManager.AppSettings["NumeroImagenesModulo"];
                if (string.IsNullOrEmpty(sNumeroImagenesModulo))
                {
                    return 5;
                }
                else
                {
                    return Convert.ToInt32(sNumeroImagenesModulo);
                }
            }
        }

        private static string _RutaImagenesEnvio
        {
            get
            {
                string sRutaImagenesEnvio = ConfigurationManager.AppSettings["RutaImagenesEnvio"];
                if (string.IsNullOrEmpty(sRutaImagenesEnvio))
                {
                    return sRutaImagenesEnvio;
                }
                else
                {
                    return sRutaImagenesEnvio;
                }
            }
        }

        private static string _RutaPDFEnvio
        {
            get
            {
                string sRutaPDFEnvio = ConfigurationManager.AppSettings["RutaPDFEnvio"];
                if (string.IsNullOrEmpty(sRutaPDFEnvio))
                {
                    return sRutaPDFEnvio;
                }
                else
                {
                    return sRutaPDFEnvio;
                }
            }
        }

        private static string _CodigoCliente
        {
            get
            {
                string sCodigoCliente = ConfigurationManager.AppSettings["Cliente"];
                if (string.IsNullOrEmpty(sCodigoCliente))
                {
                    return sCodigoCliente;
                }
                else
                {
                    return sCodigoCliente;
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

        public static string sSerialLocal
        {
            get
            {
                string sIdeModulo = ConfigurationManager.AppSettings["serialLocal"];
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


        #endregion

        static void Main(string[] args)
        {
            Process.GetCurrentProcess().Exited += new EventHandler(EnvioArchivos_Exited);

            try
            {
                if (System.Diagnostics.Process.GetProcessesByName
                    (System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
                    throw new ApplicationException("Existe otra instancia del servicio en ejecución.");

                if (!Environment.UserInteractive)
                    CentralizacionService.Run(Agente);
                else
                {
                    if (Environment.UserInteractive)
                        Console.ForegroundColor = ConsoleColor.Green;

                    Agente.OnStart(null);

                    if (Environment.UserInteractive)
                        Console.ForegroundColor = ConsoleColor.Green;

                    if (Environment.UserInteractive)
                        Console.WriteLine("El servicio se inicio correctamente y queda en espera de atender solicitudes.");

                    System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
                }
            }
            catch (Exception ex)
            {
                if (Environment.UserInteractive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ocurrió un error iniciando el servicio.");
                    Console.WriteLine(ex.Message);
                    System.Threading.Thread.Sleep(new TimeSpan(0, 1, 0));
                }
            }
        }

        public CentralizacionService()
        {
            _ProxyServicios = new ServiceProxy.ProxyService();
            oTimer = new Timer(_PeriodoEjecucionSegundos * 1000);
            oTimer.Elapsed += new ElapsedEventHandler(oTimer_Elapsed);

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            oTimer.Enabled = true;
        }

        protected override void OnStop()
        {
            oTimer.Enabled = false;
        }

        void oTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                oTimer.Enabled = false;

                if (Environment.UserInteractive)
                    Console.WriteLine("El servicio inicia revision");

                lock (objLock)
                {

                    ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

                    #region T_Transacciones

                    //OBTENER DATOS SINCRONIZACION TRANSACCIONES

                    oResultadoOperacion = _ProxyServicios.GenerarSincronizacion(sSerial);
                    if (oResultadoOperacion.oEstado == BusinessObjects.Enums.TipoRespuesta.Exito)
                    {
                        if (Environment.UserInteractive)
                            Console.WriteLine("Sincronizo registro ok");
                    }

                    //OBTENER DATOS SINCRONIZACIONPAGO TRANSACCIONES
                    oResultadoOperacion = _ProxyServicios.GenerarSincronizacionPago(sSerial);
                    if (oResultadoOperacion.oEstado == BusinessObjects.Enums.TipoRespuesta.Exito)
                    {
                        if (Environment.UserInteractive)
                            Console.WriteLine("Sincronizo registro transaccion pago ok");
                    }

                    //OBTENER DATOS SINCRONIZACIONSALIDA TRANSACCIONES
                    oResultadoOperacion = _ProxyServicios.GenerarSincronizacionSalida(sSerial);
                    if (oResultadoOperacion.oEstado == BusinessObjects.Enums.TipoRespuesta.Exito)
                    {
                        if (Environment.UserInteractive)
                            Console.WriteLine("Sincronizo registro transaccion Salida ok");
                    }

                    #endregion

                    #region T_Pagos
                    oResultadoOperacion = _ProxyServicios.GenerarPagoSincronizacion(sSerial);
                    if (oResultadoOperacion.oEstado == BusinessObjects.Enums.TipoRespuesta.Exito)
                    {
                        if (Environment.UserInteractive)
                            Console.WriteLine("Sincronizo pago ok");
                    }
                    #endregion

                    #region T_Movimientos
                    oResultadoOperacion = _ProxyServicios.GenerarMovimientosSincronizacion(sSerial);
                    if (oResultadoOperacion.oEstado == BusinessObjects.Enums.TipoRespuesta.Exito)
                    {
                        if (Environment.UserInteractive)
                            Console.WriteLine("Sincronizo Movimiento ok");
                    }
                    #endregion

                    #region T_Arqueos
                    oResultadoOperacion = _ProxyServicios.GenerarArqueosSincronizacion(sSerial);
                    if (oResultadoOperacion.oEstado == BusinessObjects.Enums.TipoRespuesta.Exito)
                    {
                        if (Environment.UserInteractive)
                            Console.WriteLine("Sincronizo Movimiento ok");
                    }
                    #endregion

                    #region T_PersonasAutorizadas
                    #endregion

                    #region T_Tarjetas
                    #endregion


                    oTimer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                string sFechaFile = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                //TraceHandler.WriteLine(LOG.NombreArchivoLogRegistraArchivos + sFechaFile, "SERVICIO WINDOWS: excepcion servicio: " + ex.Source + " " + ex.StackTrace + " " + ex.Message, TipoLog.TRAZA);

                oTimer.Enabled = true;
            }
        }


        static void EnvioArchivos_Exited(object sender, EventArgs e)
        {
            try
            {
                if (!Environment.UserInteractive)
                {
                    Agente.OnStop();
                    Agente = null;
                }
            }
            catch { }
        }
    }
}
