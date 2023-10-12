
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoConsignacion", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoConsignacion
    {
        private long _IdConsignacion;
        private long _IdEstacionamiento;
        private DateTime _FechaConsignacion;
        private double _Valor;
        private string _Referencia;
        private long _DocumentoUsuario;
        private bool _Sincronizacion;


        [DataMember]
        public long IdConsignacion
        {
            get { return _IdConsignacion; }
            set { _IdConsignacion = value; }
        }
        [DataMember]
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }

        [DataMember]
        public DateTime FechaConsignacion
        {
            get { return _FechaConsignacion; }
            set { _FechaConsignacion = value; }
        }
        [DataMember]
        public double Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }
        [DataMember]
        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }
        [DataMember]
        public long DocumentoUsuario
        {
            get { return _DocumentoUsuario; }
            set { _DocumentoUsuario = value; }
        }
        [DataMember]
        public bool Sincronizacion
        {
            get { return _Sincronizacion; }
            set { _Sincronizacion = value; }
        }
        
    }
}
