using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.Entities
{
    public class Alarma
    {
        private string _IdModulo;
        private long _IdEstacionamiento;
        private string _TipoError;
        private string _Parte;
        private string _Descripcion;
        private int _NivelError;

        
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

        
        public string TipoError
        {
            get { return _TipoError; }
            set { _TipoError = value; }
        }

        
        public string Parte
        {
            get { return _Parte; }
            set { _Parte = value; }
        }

        
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        
        public int NivelError
        {
            get { return _NivelError; }
            set { _NivelError = value; }
        }

    }
}
