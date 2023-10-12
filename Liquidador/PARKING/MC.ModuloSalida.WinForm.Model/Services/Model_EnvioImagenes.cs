using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ModuloSalida.WinForm.Model
{
    public partial class Model : IModel
    {
        public ResultadoOperacion EnviarImagenesServidor(List<Imagen> oLstImagen, Transaccion oTransaccion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            //oResultadoOperacion = _ProxyServicios.EnviarImagenesServidor(oLstImagen, oTransaccion);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion Liquidacion(string sSecuencia, int iTipoVehiculo, bool bMensualidad, bool bReposicion,string Convenios)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.ObtenerDatosLiquidacion(sSecuencia, iTipoVehiculo, bMensualidad, bReposicion, Convenios);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }
    }
}
