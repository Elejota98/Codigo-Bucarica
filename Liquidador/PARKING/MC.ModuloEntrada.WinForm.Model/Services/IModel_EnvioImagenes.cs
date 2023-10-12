using MC.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ModuloEntrada.WinForm.Model
{
    public partial interface IModel
    {
        ResultadoOperacion EnviarImagenesServidor(List<Imagen> oLstImagen, Transaccion oTransaccion);
    }
}
