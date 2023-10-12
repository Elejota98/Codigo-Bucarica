
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoTransaccion", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoTransaccion
    {
        private long _IdTransaccion;
        private int _CarrilEntrada;
        private string _ModuloEntrada;
        private long _IdEstacionamiento;
        private string _IdTarjeta;
        private string _PlacaEntrada;
        private DateTime _FechaEntrada;
        private DateTime? _FechaSalida;
        private string _ModuloSalida;
        private int? _CarrilSalida;
        private string _PlacaSalida;
        private int _IdTipoVehiculo;
        private long _Cortesia;
        private long _IdAutorizado;
        private long _Convenio1;
        private long _Convenio2;
        private long _Convenio3;
        private double _ValorRecibido;
        private double _Cambio;
        private bool _Sincronizacion;
        private bool _SincronizacionPago;
        private bool _SincronizacionSalida;

        
       
        [DataMember]
        public long IdTransaccion
        {
            get { return _IdTransaccion; }
            set { _IdTransaccion = value; }
        }
        [DataMember]
        public int CarrilEntrada
        {
            get { return _CarrilEntrada; }
            set { _CarrilEntrada = value; }
        }
        [DataMember]
        public string ModuloEntrada
        {
            get { return _ModuloEntrada; }
            set { _ModuloEntrada = value; }
        }
        [DataMember]
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }
        [DataMember]
        public string IdTarjeta
        {
            get { return _IdTarjeta; }
            set { _IdTarjeta = value; }
        }
        [DataMember]
        public string PlacaEntrada
        {
            get { return _PlacaEntrada; }
            set { _PlacaEntrada = value; }
        }

        [DataMember]
        public string ModuloSalida
        {
            get { return _ModuloSalida; }
            set { _ModuloSalida = value; }
        }

        [DataMember]
        public string PlacaSalida
        {
            get { return _PlacaSalida; }
            set { _PlacaSalida = value; }
        }

        [DataMember]
        public int? CarrilSalida
        {
            get { return _CarrilSalida; }
            set { _CarrilSalida = value; }
        }

        [DataMember]
        public int IdTipoVehiculo
        {
            get { return _IdTipoVehiculo; }
            set { _IdTipoVehiculo = value; }
        }

        [DataMember]
        public DateTime FechaEntrada
        {
            get { return _FechaEntrada; }
            set { _FechaEntrada = value; }
        }

        [DataMember]
        public DateTime? FechaSalida
        {
            get { return _FechaSalida; }
            set { _FechaSalida = value; }
        }

        [DataMember]
        public long Cortesia
        {
            get { return _Cortesia; }
            set { _Cortesia = value; }
        }

        [DataMember]
        public long IdAutorizado
        {
            get { return _IdAutorizado; }
            set { _IdAutorizado = value; }
        }

        [DataMember]
        public long Convenio1
        {
            get { return _Convenio1; }
            set { _Convenio1 = value; }
        }

        [DataMember]
        public long Convenio2
        {
            get { return _Convenio2; }
            set { _Convenio2 = value; }
        }

        [DataMember]
        public long Convenio3
        {
            get { return _Convenio3; }
            set { _Convenio3 = value; }
        }

        [DataMember]
        public double ValorRecibido
        {
            get { return _ValorRecibido; }
            set { _ValorRecibido = value; }
        }

        [DataMember]
        public double Cambio
        {
            get { return _Cambio; }
            set { _Cambio = value; }
        }

        [DataMember]
        public bool Sincronizacion
        {
            get { return _Sincronizacion; }
            set { _Sincronizacion = value; }
        }


        [DataMember]
        public bool SincronizacionPago
        {
            get { return _SincronizacionPago; }
            set { _SincronizacionPago = value; }
        }

        [DataMember]
        public bool SincronizacionSalida
        {
            get { return _SincronizacionSalida; }
            set { _SincronizacionSalida = value; }
        }
    }
}
