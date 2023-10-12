using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.Entities
{
    public class Modulo
    {
        private string _IdModulo;
        private long _IdEstacionamiento;
        private string _IP;
        private int _Carril;
        private long _IdTipoModulo;
        private string _Extension;
        private bool _Estado;
        private List<ParteModulo> _Partes = new List<ParteModulo>();


        
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

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        public int Carril
        {
            get { return _Carril; }
            set { _Carril = value; }
        }

        public long IdTipoModulo
        {
            get { return _IdTipoModulo; }
            set { _IdTipoModulo = value; }
        }

        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }

        public bool Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public List<ParteModulo> Partes
        {
            get { return _Partes; }
            set { _Partes = value; }
        }

    }
}
