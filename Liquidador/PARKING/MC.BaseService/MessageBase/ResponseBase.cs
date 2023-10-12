using MC.BaseService.MessageBase.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BaseService.MessageBase
{
    [DataContract(Namespace = "http://www.mc.com.co/types/")]
    public class ResponseBase
    {
        /// <summary>
        /// Una bandera que indica el éxito o el fracaso de la respuesta del servicio web de nuevo a el cliente
        /// por defecto es satisfactorio
        /// </summary>
        [DataMember]
        public AcknowledgeType Acknowledge = AcknowledgeType.Success;

        /// <summary>
        /// Retorna el IDCorrelación de cada cliente
        /// </summary>
        [DataMember]
        public Guid CorrelationId;

        /// <summary>
        /// Mensaje retornado al cliente. Usado normalmente cuando el servicio falla 
        /// </summary>
        [DataMember]
        public string Message;

        /// <summary>
        /// Número de reserva emitido por el servicio web
        /// </summary>
        [DataMember]
        public string ReservationId;

        /// <summary>
        /// Numero deregistros afectados por "Creación", "Actualización", o "Borrado".
        /// </summary>
        [DataMember]
        public int RowsAffected;

        /// <summary>
        /// Id de registro insertado
        /// </summary>
        [DataMember]
        public double IdInsert;

    }
}
