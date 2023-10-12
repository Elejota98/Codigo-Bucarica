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
        ResultadoOperacion ObtenerPartesModuloSalida(Modulo oModulo);
        ResultadoOperacion RegistrarMovimientoSalida(Transaccion oTransaccion);
        ResultadoOperacion RegistrarAlarmaSalida(Alarma oAlarma);
        ResultadoOperacion ObtenerInformacionModuloSalida(Modulo oModulo);
        ResultadoOperacion ObtenerParametrosSalida(long IdEstacionamiento);
        ResultadoOperacion ObtenerAutorizadoSalida(Autorizado oAutorizado);
        ResultadoOperacion SolucionarTodasAlarmasSalida(Modulo oModulo);
        ResultadoOperacion ObtenerTarjetasSalida(Modulo oModulo);
        ResultadoOperacion ObtenerEvento(long Secuencia);
        ResultadoOperacion ObtenerEventoDispositivoSalida();
        ResultadoOperacion ActualizarEventoDispositivoSalida(long IdEventoDsipo);
        ResultadoOperacion ValidarSalidaAuto(string IDCARD);
    }
}
