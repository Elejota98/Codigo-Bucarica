using MC.BusinessService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.DataService
{
    public partial interface IDataService
    {
        ResultadoOperacion ListarRutaFoto(Modulo oModulo);
        ResultadoOperacion ListarRutaFotoCloud(Modulo oModulo);
        ResultadoOperacion ObtenerDatosEstacionamiento(long IdEstacionamiento);
    }
}
