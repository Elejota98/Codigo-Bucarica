using MC.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConvenios.Model
{
    public partial interface IModel
    {
        ResultadoOperacion ValidarClave(string Usuario, string Clave);
    }
}
