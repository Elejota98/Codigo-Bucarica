using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoLiquidacion", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoLiquidacion
    {
        private long _IdTarifa;
        private long _IdEstacionamiento;
        private string _Estacionamiento;
        private long _IdTipoPago;
        private string _TipoPago;
        private long _IdTipoVehiculo;
        private long _IdAutorizacion;
        private long _IdConvenio;
        private long _IdConvenio2;
        private long _IdConvenio3;
        private long _IdEvento;

       
        private string _TipoVehiculo;
        private double _Valor;
        private string _TipoCobro;
        private bool _Estado;

        [DataMember]
        public long IdTarifa
        {
            get { return _IdTarifa; }
            set { _IdTarifa = value; }
        }
        [DataMember]
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }
        [DataMember]
        public string Estacionamiento
        {
            get { return _Estacionamiento; }
            set { _Estacionamiento = value; }
        }
        [DataMember]
        public long IdTipoPago
        {
            get { return _IdTipoPago; }
            set { _IdTipoPago = value; }
        }
        [DataMember]
        public string TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }
        [DataMember]
        public long IdTipoVehiculo
        {
            get { return _IdTipoVehiculo; }
            set { _IdTipoVehiculo = value; }
        }
        [DataMember]
        public long IdAutorizacion
        {
            get { return _IdAutorizacion; }
            set { _IdAutorizacion = value; }
        }
        [DataMember]
        public string TipoVehiculo
        {
            get { return _TipoVehiculo; }
            set { _TipoVehiculo = value; }
        }
        [DataMember]
        public double Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }
        [DataMember]
        public string TipoCobro
        {
            get { return _TipoCobro; }
            set { _TipoCobro = value; }
        }
        [DataMember]
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        [DataMember]
        public long IdConvenio
        {
            get { return _IdConvenio; }
            set { _IdConvenio = value; }
        }

        [DataMember]
        public long IdEvento
        {
            get { return _IdEvento; }
            set { _IdEvento = value; }
        }
        [DataMember]
        public long IdConvenio2
        {
            get { return _IdConvenio2; }
            set { _IdConvenio2 = value; }
        }
        [DataMember]
        public long IdConvenio3
        {
            get { return _IdConvenio3; }
            set { _IdConvenio3 = value; }
        }
        
    }
}
