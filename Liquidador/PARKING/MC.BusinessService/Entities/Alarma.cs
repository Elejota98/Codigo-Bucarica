using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.Entities
{
    [DataContract(Name = "ServiceAlarma", Namespace = "http://www.MillensCorp.com/types/")]
    public class Alarma
    {
        private string _IdModulo;
        private long _IdEstacionamiento;
        private string _TipoError;
        private string _Parte;
        private string _Descripcion;
        private int _NivelError;

        [DataMember]
        public string IdModulo
        {
            get { return _IdModulo; }
            set { _IdModulo = value; }
        }

        [DataMember]
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }

        [DataMember]
        public string TipoError
        {
            get { return _TipoError; }
            set { _TipoError = value; }
        }

        [DataMember]
        public string Parte
        {
            get { return _Parte; }
            set { _Parte = value; }
        }

        [DataMember]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        [DataMember]
        public int NivelError
        {
            get { return _NivelError; }
            set { _NivelError = value; }
        }
        
    }
}
