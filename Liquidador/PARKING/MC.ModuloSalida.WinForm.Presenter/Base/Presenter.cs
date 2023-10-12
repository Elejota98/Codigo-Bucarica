using MC.ModuloSalida.WinForm.Model;
using MC.ModuloSalida.WinForm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ModuloSalida.WinForm.Presenter
{
    public class Presenter<T> where T : IView
    {
        /// <summary>
        /// Gets and sets the model statically.
        /// </summary>
        protected static IModel Model { get; private set; }

        /// <summary>
        /// Static constructor
        /// </summary>
        static Presenter()
        {
            Model = new MC.ModuloSalida.WinForm.Model.Model();
        }

        /// <summary>
        /// Constructor. Sets the view.
        /// </summary>
        /// <param name="view">The view.</param>
        public Presenter(T view)
        {
            View = view;
        }

        /// <summary>
        /// Gets and sets the view.
        /// </summary>
        protected T View { get; private set; }
    }
}
