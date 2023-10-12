using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.Entities
{
    [DataContract(Name = "ServiceMovimientos", Namespace = "http://www.MillensCorp.com/types/")]
    public class Movimientos
    {
        private long _IdMovimiento;
        private long? _IdTransaccion;        
        private long _IdEstacionamiento;        
        private long? _IdCancelacion;        
        private long? _IdCarga;        
        private long? _IdArqueo;        
        private string _IdModulo;        
        private string _Parte;        
        private string _Accion;        
        private double _Denominacion;        
        private int _Cantidad;        
        private double _Valor;        
        private DateTime _FechaMovimiento;        
        private bool _Sincronizacion;       


        [DataMember]
        public long IdMovimiento
        {
            get { return _IdMovimiento; }
            set { _IdMovimiento = value; }
        }
        [DataMember]
        public long? IdTransaccion
        {
            get { return _IdTransaccion; }
            set { _IdTransaccion = value; }
        }
        [DataMember]
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }
        [DataMember]
        public long? IdCancelacion
        {
            get { return _IdCancelacion; }
            set { _IdCancelacion = value; }
        }
        [DataMember]
        public long? IdCarga
        {
            get { return _IdCarga; }
            set { _IdCarga = value; }
        }
        [DataMember]
        public long? IdArqueo
        {
            get { return _IdArqueo; }
            set { _IdArqueo = value; }
        }
        [DataMember]
        public string IdModulo
        {
            get { return _IdModulo; }
            set { _IdModulo = value; }
        }
        [DataMember]
        public string Parte
        {
            get { return _Parte; }
            set { _Parte = value; }
        }
        [DataMember]
        public string Accion
        {
            get { return _Accion; }
            set { _Accion = value; }
        }
        [DataMember]
        public double Denominacion
        {
            get { return _Denominacion; }
            set { _Denominacion = value; }
        }
        [DataMember]
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
        [DataMember]
        public double Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }
        [DataMember]
        public DateTime FechaMovimiento
        {
            get { return _FechaMovimiento; }
            set { _FechaMovimiento = value; }
        }
        [DataMember]
        public bool Sincronizacion
        {
            get { return _Sincronizacion; }
            set { _Sincronizacion = value; }
        }


        
    }
}
