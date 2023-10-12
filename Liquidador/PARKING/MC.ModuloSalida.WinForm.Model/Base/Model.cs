using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ModuloSalida.WinForm.Model
{
    public partial class Model : IModel
    {
        private static MC.ServiceProxy.IProxyService _ProxyServicios;

        static Model()
        {
            _ProxyServicios = new MC.ServiceProxy.ProxyService();
        }
    }
}
