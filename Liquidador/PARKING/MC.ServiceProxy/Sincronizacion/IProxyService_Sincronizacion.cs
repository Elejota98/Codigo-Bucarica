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
        ResultadoOperacion GenerarSincronizacion(string Conexion);
        ResultadoOperacion GenerarSincronizacionPago(string Conexion);
        ResultadoOperacion GenerarSincronizacionSalida(string Conexion);

        ResultadoOperacion GenerarPagoSincronizacion(string Conexion);
        ResultadoOperacion GenerarMovimientosSincronizacion(string Conexion);
        ResultadoOperacion GenerarArqueosSincronizacion(string Conexion);

        ResultadoOperacion GenerarAutorizacionesSincronizacion(string Conexion);
        ResultadoOperacion GenerarPersonasAutorizadasSincronizacion(string Conexion);

        ResultadoOperacion GenerarConsignacionSincronizacion(string Conexion);
        ResultadoOperacion GenerarFacturasManualesSincronizacion(string Conexion);

        ResultadoOperacion GenerarCortesiasSincronizacion(string Conexion);
        ResultadoOperacion GenerarConveniosSincronizacion(string Conexion);
        ResultadoOperacion GenerarEventosDispositivosSincronizacion(string Conexion);

        ResultadoOperacion ValidacionAutorizadosSincronizacion(string Conexion, long sIdEstacionamiento);

        ResultadoOperacion GenerarUsuariosSincronizacion(string Conexion);
    }
}
