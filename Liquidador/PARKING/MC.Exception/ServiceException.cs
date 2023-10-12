using MC.Global;
using MC.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Exception
{
    public class ServiceException : System.Exception
    {
        public ServiceException(string sMensajeError, System.Exception eException)
            : base(sMensajeError, eException)
        {
            //Escribe en el Log
            TraceHandler.WriteLine(LOG.NombreArchivoLogService, sMensajeError, TipoLog.ERROR);
        }
    }
}
