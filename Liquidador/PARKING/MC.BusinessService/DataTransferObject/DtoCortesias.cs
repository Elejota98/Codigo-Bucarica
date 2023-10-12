using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoCortesias", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoCortesias
    {
        private long _IdTransaccion;
        private long _IdEstacionamiento;
        private DateTime _FechaCortesia;
        private long _DocumentoUsuario;
        private long _IdMotivo;
        private string _Observacion;
        private bool _Sincronizacion;



        [DataMember]
        public long IdTransaccion
        {
            get { return _IdTransaccion; }
            set { _IdTransaccion = value; }
        }
        [DataMember]
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }
        [DataMember]
        public DateTime FechaCortesia
        {
            get { return _FechaCortesia; }
            set { _FechaCortesia = value; }
        }
        [DataMember]
        public long DocumentoUsuario
        {
            get { return _DocumentoUsuario; }
            set { _DocumentoUsuario = value; }
        }
        [DataMember]
        public long IdMotivo
        {
            get { return _IdMotivo; }
            set { _IdMotivo = value; }
        }
        [DataMember]
        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }
        [DataMember]
        public bool Sincronizacion
        {
            get { return _Sincronizacion; }
            set { _Sincronizacion = value; }
        }
        


        
        
    }
}
