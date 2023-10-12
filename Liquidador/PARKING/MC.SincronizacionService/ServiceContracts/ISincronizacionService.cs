using MC.SincronizacionService.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MC.SincronizacionService.ServiceContracts
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface ISincronizacionService
    {
        [OperationContract]
        Sincronizacion_Response getDatosSincronizacion(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosSincronizacionPago(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosSincronizacionSalida(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosPago(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosMovimientos(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosArqueos(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosAutorizaciones(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosPersonasAutorizadas(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosConsignacion(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosFacturasManuales(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getValidacionRed(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosCortesias(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosConvenios(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosTalanqueras(Sincronizacion_Request request);

        [OperationContract]
        Sincronizacion_Response getDatosUsuarios(Sincronizacion_Request request);
    }
}
