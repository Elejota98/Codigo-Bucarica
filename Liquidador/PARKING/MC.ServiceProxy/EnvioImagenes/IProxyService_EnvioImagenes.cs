using MC.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ServiceProxy
{
    public partial interface IProxyService
    {
        ResultadoOperacion EnviarImagenesServidor(List<Imagen> oLstImagen);
        ResultadoOperacion EnviarImagenesServidorCloud(List<Imagen> oLstImagen);
    }
}
