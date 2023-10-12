using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.Entities
{
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

       

       
        public long IdTarifa
        {
            get { return _IdTarifa; }
            set { _IdTarifa = value; }
        }

        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }

        public string Estacionamiento
        {
            get { return _Estacionamiento; }
            set { _Estacionamiento = value; }
        }

        public long IdTipoPago
        {
            get { return _IdTipoPago; }
            set { _IdTipoPago = value; }
        }

        public string TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }

        public long IdTipoVehiculo
        {
            get { return _IdTipoVehiculo; }
            set { _IdTipoVehiculo = value; }
        }

        public string TipoVehiculo
        {
            get { return _TipoVehiculo; }
            set { _TipoVehiculo = value; }
        }

        public double Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        public string TipoCobro
        {
            get { return _TipoCobro; }
            set { _TipoCobro = value; }
        }

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public DateTime FechaEntrada
        {
            get { return _FechaEntrada; }
            set { _FechaEntrada = value; }
        }

        public string Convenios
        {
            get { return _Convenios; }
            set { _Convenios = value; }
        }

        public string Secuencia
        {
            get { return _Secuencia; }
            set { _Secuencia = value; }
        }


    }
}
