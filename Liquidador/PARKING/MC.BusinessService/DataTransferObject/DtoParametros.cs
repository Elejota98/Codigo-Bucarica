
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoParametros", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoParametros
    {
        private long _IdEstacionamiento;
        private string _Codigo;
        private string _Valor;
        private string _Descripcion;
        private bool _Estado;


        [DataMember]
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }

        [DataMember]
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        [DataMember]
        public string Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        [DataMember]
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}
