using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.Entities
{
    public class Imagen
    {
        private string _NombreImagen;
        private byte[] _ContenidoImagen;

        public string NombreImagen
        {
            get { return _NombreImagen; }
            set { _NombreImagen = value; }
        }

        public byte[] ContenidoImagen
        {
            get { return _ContenidoImagen; }
            set { _ContenidoImagen = value; }
        }

    }
}
