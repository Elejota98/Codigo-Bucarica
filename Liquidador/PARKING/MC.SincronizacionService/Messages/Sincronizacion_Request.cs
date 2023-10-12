using MC.BaseService.MessageBase;
using MC.BusinessService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.SincronizacionService.Messages
{
    [DataContract(Namespace = "http://www.MillensCorp.com/types/")]
    public class Sincronizacion_Request : RequestBase
    {
        [DataMember]
        public string sConexion = string.Empty;

        [DataMember]
        public Transaccion oTransaccion;

        [DataMember]
        public Pago oPago;

        [DataMember]
        public Movimientos oMovimientos;

        [DataMember]
        public Arqueos oArqueos;

        [DataMember]
        public Autorizado oAutorizado;

        [DataMember]
        public Consignacion oConsignacion;

        [DataMember]
        public FacturasManuales oFacturasManuales;

        [DataMember]
        public Cortesias oCortesias;

        [DataMember]
        public Convenios oConvenios;

        [DataMember]
        public Talanquera oTalanquera;

        [DataMember]
        public Usuarios oUsuarios;

        [DataMember]
        public string sDocumento;

        [DataMember]
        public long lIdEstacionamiento;

    }
}
