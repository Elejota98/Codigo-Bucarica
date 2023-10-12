using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoParteModulo", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoParteModulo
    {
        private long _IdParte;
        private string _IdModulo;
        private long _IdEstacionamiento;
        private string _TipoParte;
        private string _NombreParte;
        private double _Denominacion;
        private double _CantidadMin;
        private double _CantidadMax;
        private string _IPDispositivo;
        private double _CantidadAlarma;
        private double _DineroActual;
        private double _CantidadActual;
        private bool _Prioritario;
        private bool _Estado;


        [DataMember]
        public long IdParte
        {
            get { return _IdParte; }
            set { _IdParte = value; }
        }

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
        public string TipoParte
        {
            get { return _TipoParte; }
            set { _TipoParte = value; }
        }

        [DataMember]
        public string NombreParte
        {
            get { return _NombreParte; }
            set { _NombreParte = value; }
        }

        [DataMember]
        public double Denominacion
        {
            get { return _Denominacion; }
            set { _Denominacion = value; }
        }

        [DataMember]
        public double CantidadMin
        {
            get { return _CantidadMin; }
            set { _CantidadMin = value; }
        }

        [DataMember]
        public double CantidadMax
        {
            get { return _CantidadMax; }
            set { _CantidadMax = value; }
        }

        [DataMember]
        public string IPDispositivo
        {
            get { return _IPDispositivo; }
            set { _IPDispositivo = value; }
        }

        [DataMember]
        public double CantidadAlarma
        {
            get { return _CantidadAlarma; }
            set { _CantidadAlarma = value; }
        }

        [DataMember]
        public double DineroActual
        {
            get { return _DineroActual; }
            set { _DineroActual = value; }
        }

        [DataMember]
        public double CantidadActual
        {
            get { return _CantidadActual; }
            set { _CantidadActual = value; }
        }

        [DataMember]
        public bool Prioritario
        {
            get { return _Prioritario; }
            set { _Prioritario = value; }
        }

        [DataMember]
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        
    }
}
