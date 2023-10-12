
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoFacturasManuales", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoFacturasManuales
    {
        private string _IdModulo;
        private long _IdEstacionamiento;
        private DateTime _FechaPago;
        private double _Subtotal;
        private double _Iva;
        private double _Total;
        private string _Prefijo;
        private string _NumeroFactura;
        private int _IdTipoVehiculo;
        private long _DocumentoUsuario;
        private bool _Sincronizacion;



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
        public DateTime FechaPago
        {
            get { return _FechaPago; }
            set { _FechaPago = value; }
        }
        [DataMember]
        public double Subtotal
        {
            get { return _Subtotal; }
            set { _Subtotal = value; }
        }
        [DataMember]
        public double Iva
        {
            get { return _Iva; }
            set { _Iva = value; }
        }
        [DataMember]
        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        [DataMember]
        public string Prefijo
        {
            get { return _Prefijo; }
            set { _Prefijo = value; }
        }
        [DataMember]
        public string NumeroFactura
        {
            get { return _NumeroFactura; }
            set { _NumeroFactura = value; }
        }
        [DataMember]
        public int IdTipoVehiculo
        {
            get { return _IdTipoVehiculo; }
            set { _IdTipoVehiculo = value; }
        }
        [DataMember]
        public long DocumentoUsuario
        {
            get { return _DocumentoUsuario; }
            set { _DocumentoUsuario = value; }
        }
        [DataMember]
        public bool Sincronizacion
        {
            get { return _Sincronizacion; }
            set { _Sincronizacion = value; }
        }
    }
}
