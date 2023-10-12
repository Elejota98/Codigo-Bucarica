using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.DataTransferObject
{
    public class DtoDatosLiquidacion
    {
        private int _Tipo = 0;
        
        public int Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        private double _SubTotal = 0;
        
        public double SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
        private double _Iva = 0;
        
        public double Iva
        {
            get { return _Iva; }
            set { _Iva = value; }
        }
        private double _Total = 0;
        
        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }



    }
}
