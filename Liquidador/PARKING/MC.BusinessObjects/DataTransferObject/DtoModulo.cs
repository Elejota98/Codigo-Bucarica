using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.DataTransferObject
{
    public class DtoModulo
    {
        private string _IdModulo;
        private long _IdEstacionamiento;
        private string _IP;
        private int _Carril;
        private long _IdTipoModulo;
        private string _Extension;
        private bool _Estado;
        private string _NombreEstacionamiento;
        private bool _EstadoEstacionamiento;
        private string _NombreSede;
        private string _Ciudad;
        private bool _EstadoSede;
        private List<DtoParteModulo> _Partes = new List<DtoParteModulo>();
        private List<DtoParametros> _Parametros = new List<DtoParametros>();


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
        
        public string NombreEstacionamiento
        {
            get { return _NombreEstacionamiento; }
            set { _NombreEstacionamiento = value; }
        }

        
        public bool EstadoEstacionamiento
        {
            get { return _EstadoEstacionamiento; }
            set { _EstadoEstacionamiento = value; }
        }
        
        public string NombreSede
        {
            get { return _NombreSede; }
            set { _NombreSede = value; }
        }
        
        public string Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }

        
        public bool EstadoSede
        {
            get { return _EstadoSede; }
            set { _EstadoSede = value; }
        }

        
        public List<DtoParteModulo> Partes
        {
            get { return _Partes; }
            set { _Partes = value; }
        }

        public List<DtoParametros> Parametros
        {
            get { return _Parametros; }
            set { _Parametros = value; }
        }

    }
}
