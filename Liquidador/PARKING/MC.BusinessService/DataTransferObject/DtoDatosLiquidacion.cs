using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.DataTransferObject
{
    [DataContract(Name = "ServiceDtoDatosLiquidacion", Namespace = "http://www.MillensCorp.com/types/")]
    public class DtoDatosLiquidacion
    {
        //Tipo=1, SubTotal=1640, Iva=360, Total=2000

        private int _Tipo = 0;
        [DataMember]
        public int Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
        private double _SubTotal = 0;
        [DataMember]
        public double SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
        private double _Iva = 0;
        [DataMember]
        public double Iva
        {
            get { return _Iva; }
            set { _Iva = value; }
        }
        private double _Total = 0;
        [DataMember]
        public double Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        


        
        
    }
}
