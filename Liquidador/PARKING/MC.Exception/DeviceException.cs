using MC.Global;
using MC.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Exception
{
    public class DeviceException : System.Exception
    {
        public DeviceException(string sMensajeError, System.Exception eException)
            : base(sMensajeError, eException)
        {
            //Escribe en el Log
            TraceHandler.WriteLine(LOG.NombreArchivoLogDevice, sMensajeError, TipoLog.ERROR);
        }
    }
}
