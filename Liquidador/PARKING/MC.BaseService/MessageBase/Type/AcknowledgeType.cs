using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BaseService.MessageBase.Type
{
    [DataContract(Namespace = "http://www.mc.com.co/types/")]
    public enum AcknowledgeType
    {
        /// <summary>
        /// Representa respuesta fallida.
        /// </summary>
        [EnumMember]
        Failure = 0,

        /// <summary>
        /// Representa respuesta satisfactoria
        /// </summary>
        [EnumMember]
        Success = 1
    }
}
