using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.Entities
{
    [DataContract(Name = "ServiceLiquidacion", Namespace = "http://www.MillensCorp.com/types/")]
    public class Liquidacion
    {
        private long _IdTarifa;
        private long _IdEstacionamiento;
        private string _Estacionamiento;
        private long _IdTipoPago;
        private string _TipoPago;
        private long _IdTipoVehiculo;
        private string _TipoVehiculo;
        private double _Valor;
        private string _TipoCobro;
        private bool _Estado;
        private DateTime _FechaEntrada;
        private string _Convenios;
        private string _Secuencia;

       
        

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
        public DateTime FechaEntrada
        {
            get { return _FechaEntrada; }
            set { _FechaEntrada = value; }
        }

        [DataMember]
        public string Convenios
        {
            get { return _Convenios; }
            set { _Convenios = value; }
        }

        [DataMember]
        public string Secuencia
        {
            get { return _Secuencia; }
            set { _Secuencia = value; }
        }
    }
}
