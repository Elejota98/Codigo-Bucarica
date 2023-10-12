using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.DataTransferObject
{
    public class DtoParametros
    {
        private long _IdEstacionamiento;
        private string _Codigo;
        private string _Valor;
        private string _Descripcion;
        private bool _Estado;


        
        public long IdEstacionamiento
        {
            get { return _IdEstacionamiento; }
            set { _IdEstacionamiento = value; }
        }

        
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        
        public string Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        
        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
    }
}
