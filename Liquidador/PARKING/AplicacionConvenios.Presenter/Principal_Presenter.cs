using AplicacionConvenios.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConvenios.Presenter
{
    public class Principal_Presenter : Presenter<IView_Principal>
    {
        public Principal_Presenter(IView_Principal view)
            : base(view)
        {
        }
    }
}
