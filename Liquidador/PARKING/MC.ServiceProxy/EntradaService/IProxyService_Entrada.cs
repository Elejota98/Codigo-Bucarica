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
        ResultadoOperacion ObtenerPartesModulo(Modulo oModulo);
        ResultadoOperacion RegistrarMovimiento(Transaccion oTransaccion);
        ResultadoOperacion RegistrarAlarma(Alarma oAlarma);
        ResultadoOperacion ObtenerInformacionModulo(Modulo oModulo);
        ResultadoOperacion ObtenerParametros(long IdEstacionamiento);
        ResultadoOperacion ObtenerAutorizado(Autorizado oAutorizado);
        ResultadoOperacion SolucionarTodasAlarmas(Modulo oModulo);
        ResultadoOperacion ObtenerTarjetas(Modulo oModulo);

        ResultadoOperacion ObtenerEventoDispositivo();
        ResultadoOperacion ActualizarEventoDispositivo(long IdEventoDsipo);
        ResultadoOperacion ValidarIngresoAuto(string IDCARD);
    }
}
