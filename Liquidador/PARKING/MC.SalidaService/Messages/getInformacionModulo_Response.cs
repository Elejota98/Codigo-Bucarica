using MC.BaseService.MessageBase;
using MC.BusinessService.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.SalidaService.Messages
{
    [DataContract(Namespace = "http://www.MillensCorp.com/types/")]
    public class getInformacionModulo_Response : ResponseBase
    {
        [DataMember]
        public DtoModulo oDatosModulo;
    }
}
