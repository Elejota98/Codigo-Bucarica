using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessService.Entities
{
    [DataContract(Name = "ServiceImagen", Namespace = "http://www.MillensCorp.com/types/")]
    public class Imagen
    {
        private string _NombreImagen;
        private Stream _ContenidoImagen;

        [DataMember]
        public string NombreImagen
        {
            get { return _NombreImagen; }
            set { _NombreImagen = value; }
        }

        [DataMember]
        public Stream ContenidoImagen
        {
            get { return _ContenidoImagen; }
            set { _ContenidoImagen = value; }
        }

    }
}
