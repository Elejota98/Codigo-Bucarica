using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MC.Mensajes
{
    /// <summary>
    /// Clases para serializar a xml y utilizar como configuración para 
    /// dinamicamente definir los mensajes usado en el control 
    /// </summary>
    [Serializable()]
    public class Mensaje
    {
        string _code;

        /// <summary>
        /// Codigo del Mensaje
        /// </summary>
        [XmlElement(IsNullable = false, DataType = "string")]
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        string _Language;
        /// <summary>
        /// Idioma del Mensaje
        /// </summary>
        [XmlElement(IsNullable = false, DataType = "string")]
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        string _description;
        /// <summary>
        /// Descripción del Mensaje 
        /// </summary>
        [XmlElement(IsNullable = false, DataType = "string")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        string _modulo;
        /// <summary>
        /// Nombre del modulo al que pertenece
        /// </summary>
        [XmlElement(IsNullable = true, DataType = "string")]
        public string Modulo
        {
            get { return _modulo; }
            set { _modulo = value; }
        }
    }
}
