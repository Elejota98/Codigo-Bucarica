
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoModulo", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoModulo
    {
        private string _IdModulo;
        private long _IdEstacionamiento;
        private string _IP;
        private int _Carril;
        private long _IdTipoModulo;
        private string _Extension;
        private bool _Estado;
        private string _NombreEstacionamiento;        
        private bool _EstadoEstacionamiento;        
        private string _NombreSede;       
        private string _Ciudad;        
        private bool _EstadoSede;
        private List<DtoParteModulo> _Partes = new List<DtoParteModulo>();


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
        public string NombreEstacionamiento
        {
            get { return _NombreEstacionamiento; }
            set { _NombreEstacionamiento = value; }
        }

        [DataMember]
        public bool EstadoEstacionamiento
        {
            get { return _EstadoEstacionamiento; }
            set { _EstadoEstacionamiento = value; }
        }
        [DataMember]
        public string NombreSede
        {
            get { return _NombreSede; }
            set { _NombreSede = value; }
        }
        [DataMember]
        public string Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }

        [DataMember]
        public bool EstadoSede
        {
            get { return _EstadoSede; }
            set { _EstadoSede = value; }
        }

        [DataMember]
        public List<DtoParteModulo> Partes
        {
            get { return _Partes; }
            set { _Partes = value; }
        }

    }
}
