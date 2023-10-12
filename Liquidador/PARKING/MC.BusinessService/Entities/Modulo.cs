using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.Entities
{
    [DataContract(Name = "ServiceModulo", Namespace = "http://www.MillensCorp.com/types/")]
    public class Modulo
    {
        private string _IdModulo;
        private long _IdEstacionamiento;
        private string _IP;
        private int _Carril;
        private long _IdTipoModulo;
        private string _Extension;
        private bool _Estado;
        private List<ParteModulo> _Partes = new List<ParteModulo>();


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
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        [DataMember]
        public int Carril
        {
            get { return _Carril; }
            set { _Carril = value; }
        }

        [DataMember]
        public long IdTipoModulo
        {
            get { return _IdTipoModulo; }
            set { _IdTipoModulo = value; }
        }

        [DataMember]
        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }

        [DataMember]
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        [DataMember]
        public List<ParteModulo> Partes
        {
            get { return _Partes; }
            set { _Partes = value; }
        }

    }
}
