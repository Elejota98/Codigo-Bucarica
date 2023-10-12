using MC.BaseService.MessageBase;
using MC.BusinessService.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.SincronizacionService.Messages
{
    [DataContract(Namespace = "http://www.MillensCorp.com/types/")]
    public class Sincronizacion_Response : ResponseBase
    {
        [DataMember]
        public DtoTransaccion oDtoTransaccion;

        [DataMember]
        public DtoPago oDtoPago;

        [DataMember]
        public DtoMovimientos oDtoMovimientos;

        [DataMember]
        public DtoArqueos oDtoArqueos;

        [DataMember]
        public DtoCortesias oDtoCortesias;

        [DataMember]
        public DtoConvenios oDtoConvenios;

        [DataMember]
        public DtoTalanquera oDtoTalanquera;

        [DataMember]
        public string  sResult;
    }
}
