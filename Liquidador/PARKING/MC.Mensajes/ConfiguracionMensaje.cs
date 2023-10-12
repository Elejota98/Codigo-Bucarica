using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MC.Mensajes
{
    #region Messages

    /// <summary>
    /// Coleccion (array) de Clases Message para permitir la configuracipón de los mensajes 
    /// usado en el control
    /// </summary>
    [XmlRoot(ElementName = "ConfiguracionMensaje", Namespace = "")]
    public class ConfiguracionMensaje : List<Mensaje>
    {
        public ConfiguracionMensaje()
        {

        }
    }


    #endregion
}
