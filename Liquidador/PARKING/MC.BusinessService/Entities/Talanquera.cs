using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.Entities
{
    [DataContract(Name = "ServiceTalanquera", Namespace = "http://www.MillensCorp.com/types/")]
    public class Talanquera
    {
        private long _IdEventoDispositivo;
        private long _IdEstacionamiento;
        private string _IdModulo;
        private string _Usuario;
        private string _Observacion;
        private DateTime _FechaHora;
        private bool _Estado;
        private bool _Sincronizacion;

               
        
        [DataMember]
        public long IdEventoDispositivo
        {
            get { return _IdEventoDispositivo; }
            set { _IdEventoDispositivo = value; }
        }
        [DataMember]
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }
        [DataMember]
        public string IdModulo
        {
            get { return _IdModulo; }
            set { _IdModulo = value; }
        }
        [DataMember]
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        [DataMember]
        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }
        [DataMember]
        public DateTime FechaHora
        {
            get { return _FechaHora; }
            set { _FechaHora = value; }
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
