using MC.BusinessObjects.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.Entities
{
    public class ResultadoOperacion
    {

        private TipoRespuesta _TipoRespuesta = TipoRespuesta.Exito;
        private string _Mensaje = string.Empty;
        private IList _ListaEntidadDatos = null;
        private object _EntidadDatos = null;
        private int _IdeEntidad = 0;


        /// <summary>
        /// Mensaje de error retornado
        /// </summary>
        public string Mensaje
        {
            get { return _Mensaje; }
            set { _Mensaje = value; }
        }

        /// <summary>
        /// Tipo de respuesta retornado..Error o Satisfactorio
        /// </summary>
        public TipoRespuesta oEstado
        {
            get { return _TipoRespuesta; }
            set { _TipoRespuesta = value; }
        }

        /// <summary>
        /// Listado de datos (DTO) retornado
        /// </summary>
        public IList ListaEntidadDatos
        {
            get { return _ListaEntidadDatos; }
            set { _ListaEntidadDatos = value; }
        }

        /// <summary>
        /// datos (DTO) retornado
        /// </summary>
        public object EntidadDatos
        {
            get { return _EntidadDatos; }
            set { _EntidadDatos = value; }
        }

        /// <summary>
        /// Identificador un registro insertado en una entidad
        /// </summary>
        public int IdeEntidad
        {
            get { return _IdeEntidad; }
            set { _IdeEntidad = value; }
        }
    }
}
