using MC.EntradaService.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MC.EntradaService.ServiceContracts
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IEntradaService
    {
        [OperationContract]
        getPartesModulo_Response getPartesModulo(getPartesModulo_Request request);

        [OperationContract]
        setRegistrarTransaccion_Response setRegistrarTransaccion(setRegistrarTransaccion_Request request);

        [OperationContract]
        setRegistrarAlarma_Response setRegistrarAlarma(setRegistrarAlarma_Request request);

        [OperationContract]
        getInformacionModulo_Response getInformacionModulo(getInformacionModulo_Request request);

        [OperationContract]
        getParametros_Response getParametros(getParametros_Request request);

        [OperationContract]
        getInfoAutorizado_Response getInfoAutorizado(getInfoAutorizado_Request request);

        [OperationContract]
        setSolucionarAlarmas_Response setSolucionarAlarmas(setSolucionarAlarmas_Request request);

        [OperationContract]
        getTarjetas_Response getTarjetas(getTarjetas_Request request);

        [OperationContract]
        getEventosDispositivo_Response getEventosDispositivo(getEventosDispositivo_Request request);

        [OperationContract]
        getEventosDispositivo_Response SetActualizarEventoDispositivo(getEventosDispositivo_Request request);

        [OperationContract]
        getValidarIngresoAutorizado_Response getValidarIngresoAutorizado(getValidarIngresoAutorizado_Request request);
    }
}
