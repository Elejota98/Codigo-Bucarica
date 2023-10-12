using MC.BusinessService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.DataService
{
    public partial interface IDataService
    {
        ResultadoOperacion ObtenerDatosLiquidacion(long IdEstacionamiento, long IdTipoPago, long IdTipoVehiculo, long IdConvenio, long Evento);
        ResultadoOperacion ObtenerDatosLiquidacionAutorizacion(long IdEstacionamiento, long IdTipoPago, long IdTipoVehiculo, long CodAutorizacion);
        ResultadoOperacion ObtenerDatosTransaccion(string Secuencia);
        ResultadoOperacion ObtenerTipoVehiculoMensula(string IdTarjeta);
        ResultadoOperacion ObtenerDatosPago(string Secuencia);
        ResultadoOperacion ObtenerDatosEvento(string Secuencia);
        ResultadoOperacion ObtenerDatosCasco(string Secuencia);
    }
}
