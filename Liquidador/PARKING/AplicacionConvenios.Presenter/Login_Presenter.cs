using AplicacionConvenios.View;
using MC.BusinessObjects.DataTransferObject;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConvenios.Presenter
{
    public class Login_Presenter : Presenter<IView_Principal>
    {
        public Login_Presenter(IView_Principal view)
            : base(view)
        {
        }



        public bool ValidarClave(string Usuario, string Clave)
        {
            bool ok = false;

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = Model.ValidarClave(Usuario, Clave);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.DtoUsuario = (DtoUsuario)oResultadoOperacion.EntidadDatos;
                if (!View.DtoUsuario.Estado)
                {
                    ok = false;
                }
                else
                {
                    ok = true;
                }
            }

            return ok;
        }
    }
}
