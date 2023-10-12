
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoArqueos", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoArqueos
    {
        private long _IdArqueo;
        private DateTime _FechaInicio;
        private DateTime? _FechaFin;
        private double _Valor;
        private long _IdUsuario;
        private string _IdModulo;
        private long _IdEstacionamiento;
        private int _CantTransacciones;
        private double _Producido;
        private string _Tipo;
        private double _Conteo;
        private bool _Sincronizacion;


        [DataMember]
        public long IdArqueo
        {
            get { return _IdArqueo; }
            set { _IdArqueo = value; }
        }

        [DataMember]
        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set { _FechaInicio = value; }
        }
        [DataMember]
        public DateTime? FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }
        [DataMember]
        public double Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }
        [DataMember]
        public long IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
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
        public int CantTransacciones
        {
            get { return _CantTransacciones; }
            set { _CantTransacciones = value; }
        }
        [DataMember]
        public double Producido
        {
            get { return _Producido; }
            set { _Producido = value; }
        }
        [DataMember]
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        [DataMember]
        public double Conteo
        {
            get { return _Conteo; }
            set { _Conteo = value; }
        }
        [DataMember]
        public bool Sincronizacion
        {
            get { return _Sincronizacion; }
            set { _Sincronizacion = value; }
        }
    }
}
