using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.Entities
{
    public class Transaccion
    {
        private long _IdTransaccion;
        private int _CarrilEntrada;
        private string _ModuloEntrada;
        private long _IdEstacionamiento;
        private string _IdTarjeta;
        private string _PlacaEntrada;
        private long _IdAutorizado;
        private int _CarrilSalida;
        private string _ModuloSalida;
        private string _PlacaSalida;
        private int _TipoVehiculo;

        public long IdTransaccion
        {
            get { return _IdTransaccion; }
            set { _IdTransaccion = value; }
        }
        public int CarrilEntrada
        {
            get { return _CarrilEntrada; }
            set { _CarrilEntrada = value; }
        }
        public string ModuloEntrada
        {
            get { return _ModuloEntrada; }
            set { _ModuloEntrada = value; }
        }
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }
        public string IdTarjeta
        {
            get { return _IdTarjeta; }
            set { _IdTarjeta = value; }
        }
        public string PlacaEntrada
        {
            get { return _PlacaEntrada; }
            set { _PlacaEntrada = value; }
        }
        public long IdAutorizado
        {
            get { return _IdAutorizado; }
            set { _IdAutorizado = value; }
        }
        public int CarrilSalida
        {
            get { return _CarrilSalida; }
            set { _CarrilSalida = value; }
        }
        public string ModuloSalida
        {
            get { return _ModuloSalida; }
            set { _ModuloSalida = value; }
        }
        public string PlacaSalida
        {
            get { return _PlacaSalida; }
            set { _PlacaSalida = value; }
        }
        public int TipoVehiculo
        {
            get { return _TipoVehiculo; }
            set { _TipoVehiculo = value; }
        }
    }
}
