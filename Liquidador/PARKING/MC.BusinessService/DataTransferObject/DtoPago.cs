
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoPago", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoPago
    {
        private long _IdPago;
        private string _IdTransaccion;
        private long _IdAutorizado;
        private long _IdEstacionamiento;
        private string _IdModulo;
        private long _IdFacturacion;
        private long _IdTipoPago;
        private DateTime _FechaPago;
        private double _Subtotal;
        private double _Iva;
        private double _Total;
        private string _NumeroFactura;
        private bool _Sincronizacion;
        private bool _PagoMensual;
        private bool _Anulada;


        [DataMember]
        public long IdPago
        {
            get { return _IdPago; }
            set { _IdPago = value; }
        }
        [DataMember]
        public string IdTransaccion
        {
            get { return _IdTransaccion; }
            set { _IdTransaccion = value; }
        }
        [DataMember]
        public long IdAutorizado
        {
            get { return _IdAutorizado; }
            set { _IdAutorizado = value; }
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
        public long IdFacturacion
        {
            get { return _IdFacturacion; }
            set { _IdFacturacion = value; }
        }
        [DataMember]
        public long IdTipoPago
        {
            get { return _IdTipoPago; }
            set { _IdTipoPago = value; }
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
        public string NumeroFactura
        {
            get { return _NumeroFactura; }
            set { _NumeroFactura = value; }
        }
        [DataMember]
        public bool Sincronizacion
        {
            get { return _Sincronizacion; }
            set { _Sincronizacion = value; }
        }
        [DataMember]
        public bool PagoMensual
        {
            get { return _PagoMensual; }
            set { _PagoMensual = value; }
        }
        [DataMember]
        public bool Anulada
        {
            get { return _Anulada; }
            set { _Anulada = value; }
        }
    }
}
