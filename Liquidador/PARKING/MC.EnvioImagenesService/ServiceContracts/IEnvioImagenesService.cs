using MC.EnvioImagenesService.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MC.EnvioImagenesService.ServiceContracts
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IEnvioImagenesService
    {
        [OperationContract]
        [ServiceKnownType(typeof(MemoryStream))]
        setAlmacenaImagenesServidor_Response setAlmacenaImagenesServidor(setAlmacenaImagenesServidor_Request request);

        [OperationContract]
        [ServiceKnownType(typeof(MemoryStream))]
        setAlmacenaImagenesServidorCloud_Response setAlmacenaImagenesServidorCloud(setAlmacenaImagenesServidorCloud_Request request);

    }
}
