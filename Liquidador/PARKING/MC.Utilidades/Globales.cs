using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Utilidades
{
    public class Globales
    {
        public static string sNombreImpresoraTickets
        {
            get
            {
                string sNombreImpresoraTickets = ConfigurationManager.AppSettings["NombreImpresoraTickets"];
                if (!string.IsNullOrEmpty(sNombreImpresoraTickets))
                {
                    return sNombreImpresoraTickets;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string sNombreImpresoraCarta
        {
            get
            {
                string sNombreImpresoraCarta = ConfigurationManager.AppSettings["NombreImpresoraCarta"];
                if (!string.IsNullOrEmpty(sNombreImpresoraCarta))
                {
                    return sNombreImpresoraCarta;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string sTestMode
        {
            get
            {
                string sIdeModulo = ConfigurationManager.AppSettings["TestMode"];
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
        public static string iCodigoEstacionamiento
        {
            get
            {
                string iCodigoEstacionamiento = ConfigurationManager.AppSettings["CodigoEstacionamiento"];
                if (!string.IsNullOrEmpty(iCodigoEstacionamiento))
                {
                    return iCodigoEstacionamiento;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string sCarril
        {
            get
            {
                string sCarril = ConfigurationManager.AppSettings["Carril"];
                if (!string.IsNullOrEmpty(sCarril))
                {
                    return sCarril;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string sCarrilMixto
        {
            get
            {
                string sCarrilMixto = ConfigurationManager.AppSettings["CarrilMixto"];
                if (!string.IsNullOrEmpty(sCarrilMixto))
                {
                    return sCarrilMixto;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string sPuertoLPR
        {
            get
            {
                string sPuertoLPR = ConfigurationManager.AppSettings["PuertoLPR"];
                if (!string.IsNullOrEmpty(sPuertoLPR))
                {
                    return sPuertoLPR;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string sIDLPR
        {
            get
            {
                string sIDLPR = ConfigurationManager.AppSettings["IDLPR"];
                if (!string.IsNullOrEmpty(sIDLPR))
                {
                    return sIDLPR;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string sPuerto
        {
            get
            {
                string sPuerto = ConfigurationManager.AppSettings["PuertoKYT"];
                if (!string.IsNullOrEmpty(sPuerto))
                {
                    return sPuerto;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string sPuertoPLC
        {
            get
            {
                string sPuertoPLC = ConfigurationManager.AppSettings["PuertoPLC"];
                if (!string.IsNullOrEmpty(sPuertoPLC))
                {
                    return sPuertoPLC;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static string sRuta
        {
            get
            {
                string sRuta = ConfigurationManager.AppSettings["Ruta"];
                if (!string.IsNullOrEmpty(sRuta))
                {
                    return sRuta;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public static bool bEnabledUpdates
        {
            get
            {
                string sEnabledTracking = ConfigurationManager.AppSettings["EnableUpdates"];
                if (!string.IsNullOrEmpty(sEnabledTracking))
                {
                    return Convert.ToBoolean(sEnabledTracking);
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool bEnabledTracking
        {
            get
            {
                string sEnabledTracking = ConfigurationManager.AppSettings["EnabledTracking"];
                if (!string.IsNullOrEmpty(sEnabledTracking))
                {
                    return Convert.ToBoolean(sEnabledTracking);
                }
                else
                {
                    return false;
                }
            }
        }
        public static string sRutaLog
        {
            get { return ConfigurationManager.AppSettings["LogFilePath"]; }
        }

    }
}
