using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Mensajes
{
    /// <summary>
    /// Clase para el manejo de los mensajes usados en la 
    /// aplicación
    /// </summary>
    public class AdministradorMensaje
    {

        #region Properties
        ConfiguracionMensaje _msgConfiguracion;
        private const string LG_ErrorSQL = "LG_ErrorSQL";
        static LenguajeMensaje _msgLenguaje;
        #endregion

        #region Singleton pattern implementation thread safe
        static AdministradorMensaje instance = null;

        static readonly object padlock = new object();

        public AdministradorMensaje()
        {

            _msgConfiguracion = GetConfiguration();



        }

        public static AdministradorMensaje Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AdministradorMensaje();
                        LoadLenguage(ConfigurationManager.AppSettings["LenguajeMensaje"]);
                    }

                    return instance;
                }
            }
        }
        #endregion

        private static void LoadLenguage(string sLang)
        {
            switch (sLang)
            {
                case "EN": //English
                    _msgLenguaje = LenguajeMensaje.EN;

                    break;

                case "ES": //Español
                    _msgLenguaje = LenguajeMensaje.ES;

                    break;

                case "FR": //French
                    _msgLenguaje = LenguajeMensaje.FR;

                    break;

                case "PR": //Portuges
                    _msgLenguaje = LenguajeMensaje.PR;

                    break;
                default:
                    _msgLenguaje = LenguajeMensaje.ES;
                    break;
            }
        }

        #region Message Manager
        /// <summary>
        /// Carga el archivo de Recursos con la configuración de mensajes que usa el control
        /// </summary>
        /// <param name="sPathConfig"></param>
        /// <returns></returns>
        private ConfiguracionMensaje GetConfiguration()
        {

            string sPathConfig = string.Empty;

            if (ConfigurationManager.AppSettings["XmlMensajes"].Contains(":"))
            {
                sPathConfig = string.Format("{0}", ConfigurationManager.AppSettings["XmlMensajes"]);
            }
            else
            {
                sPathConfig = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["XmlMensajes"]);
            }
            XmlDocument docxml = new XmlDocument();
            ConfiguracionMensaje configuration = null;
            try
            {
                docxml.Load(sPathConfig);

            }
            catch (System.Exception)
            {
                //throw new ApplicationObjectException("Error recuperando la ruta del archivo de configuración", exec);
            }
            configuration = Utils.DeserializeObject<ConfiguracionMensaje>(docxml.OuterXml);
            return configuration;
        }
        /// <summary>
        /// Obtiene un mensaje del archivo de recursos 
        /// </summary>
        /// <param name="sCode">Código del mensaje</param>
        /// <returns></returns>
        public string GetMensajePorCodigo(string sCode)
        {
            foreach (Mensaje message in _msgConfiguracion)
            {
                if (message.Code.Equals(sCode) && message.Language.Equals(_msgLenguaje.ToString()))
                {
                    return message.Description;
                }
            }
            return null;
        }


        /// <summary>
        /// Obtiene un mensaje de error de SQL Server
        /// </summary>
        /// <param name="numeroError">Numero del errro de SQL</param>
        /// <param name="sLang">Idioma del Mensaje</param>
        /// <returns></returns>
        private string GetMensajeSQLError(int numeroError)
        {
            string errorCodigo = string.Format("{0}{1}", LG_ErrorSQL, numeroError);
            errorCodigo = GetMensajePorCodigo(errorCodigo);
            if (errorCodigo == null)
            {
                return "";
            }
            else
            {
                return errorCodigo;
            }
        }
        #endregion
    }
}
