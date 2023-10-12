using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.DataTransferObject
{
    public class DtoTarjetas
    {
        private long _IdEstacionamiento;
        private string _IdTarjeta;
        private bool _Estado;


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

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
      
    }
}
