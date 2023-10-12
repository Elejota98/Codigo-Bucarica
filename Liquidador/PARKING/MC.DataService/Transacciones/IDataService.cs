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
        ResultadoOperacion ObtenerInfoPartes(Modulo oModulo);

        ResultadoOperacion RegistrarTransaccion(Transaccion oTransaccion);
        
        ResultadoOperacion RegistrarAlarma(Alarma oAlarma);

        ResultadoOperacion ObtenerInfoModulo(Modulo oModulo);

        ResultadoOperacion ObtenerParametros(long IdEstacionamiento);

        ResultadoOperacion ObtenerInfoAutorizado(Autorizado oAutorizado);

        ResultadoOperacion SolucionarTodasAlarmas(Modulo oModulo);

        ResultadoOperacion ObtenerTarjetas(Modulo oModulo);

        ResultadoOperacion RegistrarTransaccionSalida(Transaccion oTransaccion);

        ResultadoOperacion ObtenerEvento(long Secuencia);

        ResultadoOperacion ObtenerEventoDisposito();

        ResultadoOperacion ActualizarEvento(long IdEvento);

        ResultadoOperacion ValidarIngresoAuto(string IDCard);
    }
}
