using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConvenios.Model
{
    public partial class Model : IModel
    {
        public ResultadoOperacion ValidarClave(string Usuario, string Clave)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.Login(Usuario, Clave);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }
    }
}
