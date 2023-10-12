using MC.BusinessObjects.Entities;
using MC.Global;
using MC.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MC.EnvioImagenes
{
    public partial class EnvioImagenesService : ServiceBase
    {

        #region Definiciones

        ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
        private Timer oTimer;

        private static object objLock = new object();
        private static EnvioImagenesService Agente = new EnvioImagenesService();
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
                    EnvioImagenesService.Run(Agente);
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

        public EnvioImagenesService()
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
                TraceHandler.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs\Archivos"), "El servicio inicia revision", TipoLog.TRAZA);
                lock (objLock)
                {

                    
                    List<Imagen> olstImagenes = new List<Imagen>();
                    List<string> olstImagenesBorrar = new List<string>();

                    if (Directory.Exists(_RutaImagenesEnvio))
                    {

                        TraceHandler.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs\Archivos"), "RUTA IMAGENES: " + _RutaImagenesEnvio, TipoLog.TRAZA);
                        DirectoryInfo info = new DirectoryInfo(_RutaImagenesEnvio);
                        FileInfo[] oFiles = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                        if (oFiles.Length > 0)
                        {

                            TraceHandler.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs\Archivos"), "oFiles.Length" , TipoLog.TRAZA);
                            int iNumeroArchivos = 0;
                            string sSecuenciaImagen = string.Empty;
                            foreach (FileInfo iFile in oFiles)
                            {
                                if (iFile.Name.Contains("Thumbs.db"))
                                {
                                    continue;
                                }


                                FileStream fs = new FileStream(iFile.FullName, System.IO.FileMode.Open);
                                Image oImage = Image.FromStream(fs);
                                //Image oImage = Image.FromFile(iFile.FullName);

                                byte[] bImage = Generales.ImageToByteArray(oImage, ImageFormat.Jpeg);
                                Imagen oImagen = new Imagen();
                                oImagen.ContenidoImagen = bImage;
                                oImagen.NombreImagen = iFile.Name;

                                olstImagenes.Add(oImagen);
                                iNumeroArchivos++;

                                fs.Close();


                                if (iNumeroArchivos == _NumeroImagenesModulo)
                                {
                                    break;
                                }

                            }

                            if (olstImagenes != null)
                            {
                                if (olstImagenes.Count > 0)
                                {
                                    TraceHandler.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs\Archivos"), "INICIO EnviarImagenesServidor", TipoLog.TRAZA);
                                    oResultadoOperacion = _ProxyServicios.EnviarImagenesServidor(olstImagenes);
                                    if (oResultadoOperacion.oEstado == BusinessObjects.Enums.TipoRespuesta.Exito)
                                    {
                                        //Borrar imagenes

                                        if (Environment.UserInteractive)
                                            Console.WriteLine("Empieza a eliminar imagenes.");

                                        foreach (Imagen iImagen in olstImagenes)
                                        {
                                            File.Delete(Path.Combine(_RutaImagenesEnvio, iImagen.NombreImagen));
                                        }

                                        if (Environment.UserInteractive)
                                            Console.WriteLine("Sale de solicitud actual borrando imagenes.");
                                        TraceHandler.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs\Archivos"), "Proceso OK", TipoLog.TRAZA);
                                    }
                                    else
                                    {
                                        TraceHandler.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs\Archivos"), "ERROR" + " " + oResultadoOperacion.Mensaje, TipoLog.TRAZA);
                                        File.Delete(Path.Combine(_RutaImagenesEnvio, oResultadoOperacion.Mensaje));
                                        if (Environment.UserInteractive)
                                            Console.WriteLine("Servicio de Registro de Imagenes No disponible");
                                        
                                    }
                                }
                            }
                        }
                        oTimer.Enabled = true;
                    }
                    else
                    {
                        oTimer.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string sFechaFile = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                TraceHandler.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs\Archivos"), "ERROR" + " " + ex.ToString() + " " + oResultadoOperacion.Mensaje, TipoLog.TRAZA);

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
