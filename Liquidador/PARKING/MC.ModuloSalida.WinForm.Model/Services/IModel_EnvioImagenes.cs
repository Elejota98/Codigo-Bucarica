using MC.BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ModuloSalida.WinForm.Model
{
    public partial interface IModel
    {
        ResultadoOperacion EnviarImagenesServidor(List<Imagen> oLstImagen, Transaccion oTransaccion);
        ResultadoOperacion Liquidacion(string sSecuencia, int iTipoVehiculo, bool bMensualidad, bool bReposicion, string Convenios);
    }
}
