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
        ResultadoOperacion ObtenerSincronizacionTransaccion();
        ResultadoOperacion ObtenerSincronizacionPagoTransaccion();
        ResultadoOperacion ObtenerSincronizacionSalidaTransaccion();

        ResultadoOperacion RegistrarSincronizacionTransaccion(Transaccion oTransaccion, string Conexion);
        ResultadoOperacion RegistrarSincronizacionPagoTransaccion(Transaccion oTransaccion, string Conexion);
        ResultadoOperacion RegistrarSincronizacionSalidaTransaccion(Transaccion oTransaccion, string Conexion);

        ResultadoOperacion ActualizaSincronizacionTransaccion(long Transaccion);
        ResultadoOperacion ActualizaSincronizacionPagoTransaccion(long Transaccion);
        ResultadoOperacion ActualizaSincronizacionSalidaTransaccion(long Transaccion);

        ResultadoOperacion ObtenerPagoSincronizacion();
        ResultadoOperacion RegistrarSincronizacionPago(Pago oPago, string Conexion);
        ResultadoOperacion ActualizaSincronizacionPago(string IdTransaccion, long Pago, long IdTipoPago);

        ResultadoOperacion ObtenerMovimientoSincronizacion();
        ResultadoOperacion RegistrarSincronizacionMovimiento(Movimientos oMovimiento, string Conexion);
        ResultadoOperacion ActualizaSincronizacionMovimiento(long Movimiento);

        ResultadoOperacion ObtenerArqueoSincronizacion();
        ResultadoOperacion RegistrarSincronizacionArqueo(Arqueos oArqueos, string Conexion);
        ResultadoOperacion ActualizaSincronizacionArqueo(long Arqueo);

        ResultadoOperacion ObtenerAutorizacionesSincronizacion();
        ResultadoOperacion RegistrarSincronizacionAutorizacion(Autorizado oAutorizado, string Conexion);
        ResultadoOperacion ActualizaSincronizacionAutorizacion(long IdAutorizacion, long IdEstacionamiento);
        
        
        ResultadoOperacion ObtenerPersonasAutorizadasSincronizacion();
        ResultadoOperacion RegistrarSincronizacionPersonasAutorizadas(Autorizado oAutorizado, string Conexion);
        ResultadoOperacion ActualizaPersonasSincronizacionAutorizacion(string Documento, long IdEstacionamiento);
        ResultadoOperacion ValidarExistenciaPersonasAutorizadasSincronizacionCloud(string Documento, long IdEstacionamiento, string sConexion);
        ResultadoOperacion ActualizaPersonasAutorizadasCloud(Autorizado oAutorizado, string sConexion);

        ResultadoOperacion ObtenerConsignacionSincronizacion();
        ResultadoOperacion RegistrarSincronizacionConsignacion(Consignacion oConsignacion, string Conexion);
        ResultadoOperacion ActualizaConsignacionSincronizacion(long IdConsignacion);

        ResultadoOperacion ObtenerFacturasManualesSincronizacion();
        ResultadoOperacion RegistrarSincronizacionFacturasManuales(FacturasManuales oFacturasManuales, string Conexion);
        ResultadoOperacion ActualizaFacturasManualesSincronizacion(long IdEstacionamiento, string NumeroFactura);

        ResultadoOperacion ObtenerDocumentoPermisosEstacionamientoSincronizacion(long IdEstacionamiento,string Conexion);
        ResultadoOperacion ObtenerInfoPersonasAutorizadasSincronizacion(string Documento,long IdEstacionamiento,string Conexion);
        ResultadoOperacion ValidarExistenciaPersonasAutorizadasSincronizacion(string Documento, long IdEstacionamiento);
        ResultadoOperacion RegistrarPersonasAutoRed(Autorizado oAutorizado);
        ResultadoOperacion ActualizaPersonasAutorizadasRed(Autorizado oAutorizado);
        ResultadoOperacion ActualizaPersonasAutorizadasRedCloud(string Documento, long IdEstacionamiento, string Conexion);

        ResultadoOperacion ObtenerCortesiasSincronizacion();
        ResultadoOperacion RegistrarSincronizacionCortesias(Cortesias oCortesias, string Conexion);
        ResultadoOperacion ActualizaCortesiasSincronizacion(long IdTransaccion, long IdEstacionamiento);

        ResultadoOperacion ObtenerConveniosSincronizacion();
        ResultadoOperacion RegistrarSincronizacionConvenios(Convenios oConvenios, string Conexion);
        ResultadoOperacion ActualizaConveniosSincronizacion(long IdEstacionamiento, long IdConvenio);

        ResultadoOperacion ObtenerEventosSincronizacion();
        ResultadoOperacion RegistrarSincronizacionEventos(Talanquera oTalanquera, string Conexion);
        ResultadoOperacion ActualizaEventoDispositivoSincronizacion(long IdEvento);

        ResultadoOperacion ObtenerUsuariosSincronizacion();
        ResultadoOperacion RegistrarSincronizacionUsuarios(Usuarios oUsuarios, string Conexion);
        ResultadoOperacion ActualizaUsuariosSincronizacion(long Documento);
    }
}
