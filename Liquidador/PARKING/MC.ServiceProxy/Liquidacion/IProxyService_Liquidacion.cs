using MC.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ServiceProxy
{
    public partial interface IProxyService
    {
        ResultadoOperacion ObtenerDatosLiquidacion(string sSecuencia, int iTipoVehiculo, bool bMensualidad, bool bReposicion, string Convenios);
    }
}
