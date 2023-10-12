using MC.BaseService.MessageBase;
using MC.BaseService.MessageBase.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BaseService
{
    public class ServiceBase
    {

        /// <summary>
        /// Valida Request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        public bool ValidRequest(RequestBase request, ResponseBase response)
        {
            bool bRequestValido = true;

            if (request.RequestId == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = "Request ID de servicio no válido...";
                return false;
            }

            return bRequestValido;
        }

    }
}
