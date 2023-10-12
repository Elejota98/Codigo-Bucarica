using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.Entities
{
    [DataContract(Name = "ServiceConvenios", Namespace = "http://www.MillensCorp.com/types/")]
    public class Convenios
    {
        private long _IdConvenio;
        private string _Nombre;
        private string _Descripcion;
        private long _IdEstacionamiento;
        private DateTime _FechaInicial;
        private DateTime _FechaFinal;
        private bool _Estado;
        private bool _Sincronizacion;
        
        
        [DataMember]
        public long IdConvenio
        {
            get { return _IdConvenio; }
            set { _IdConvenio = value; }
        }
        [DataMember]
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        [DataMember]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        [DataMember]
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }
        [DataMember]
        public DateTime FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }
        [DataMember]
        public DateTime FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }
        [DataMember]
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        [DataMember]
        public bool Sincronizacion
        {
            get { return _Sincronizacion; }
            set { _Sincronizacion = value; }
        }
       
    }
}
