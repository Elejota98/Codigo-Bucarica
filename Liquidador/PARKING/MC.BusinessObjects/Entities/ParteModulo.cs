using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.Entities
{
    public class ParteModulo
    {
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
        private int _CantidadActual;
        private bool _Prioritario;
        private bool _Estado;


        public string IdModulo
        {
            get { return _IdModulo; }
            set { _IdModulo = value; }
        }

        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }

        public string TipoParte
        {
            get { return _TipoParte; }
            set { _TipoParte = value; }
        }

        public string NombreParte
        {
            get { return _NombreParte; }
            set { _NombreParte = value; }
        }

        public double Denominacion
        {
            get { return _Denominacion; }
            set { _Denominacion = value; }
        }

        public double CantidadMin
        {
            get { return _CantidadMin; }
            set { _CantidadMin = value; }
        }

        public double CantidadMax
        {
            get { return _CantidadMax; }
            set { _CantidadMax = value; }
        }

        public string IPDispositivo
        {
            get { return _IPDispositivo; }
            set { _IPDispositivo = value; }
        }

        public double CantidadAlarma
        {
            get { return _CantidadAlarma; }
            set { _CantidadAlarma = value; }
        }

        public double DineroActual
        {
            get { return _DineroActual; }
            set { _DineroActual = value; }
        }

        public int CantidadActual
        {
            get { return _CantidadActual; }
            set { _CantidadActual = value; }
        }

        public bool Prioritario
        {
            get { return _Prioritario; }
            set { _Prioritario = value; }
        }

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}
