using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConvenios.Model
{
    public partial class Model : IModel
    {

        private static MC.ServiceProxy.IProxyService _ProxyServicios;

        static Model()
        {
            //Inicializador de Servicios
            _ProxyServicios = new MC.ServiceProxy.ProxyService();
        }
    }
}
