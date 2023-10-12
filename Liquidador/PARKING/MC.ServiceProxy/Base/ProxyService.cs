using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ServiceProxy
{
    public partial class ProxyService : IProxyService
    {
        //Definicion de los servicios
        private static MC_EntradaService.EntradaServiceClient _MC_EntradaServices { set; get; }
        private static MC_EnvioImagenesService.EnvioImagenesServiceClient _MC_EnvioImagenes { set; get; }
        private static MC_SalidaService.SalidaServiceClient _MC_SalidaService { set; get; }
        private static MC_LiquidacionService.LiquidacionServiceClient _MC_LiquidacionService { set; get; }
        private static MC_SincronizacionService.SincronizacionServiceClient _MC_SincronizacionService { set; get; }


        private Guid _NuevoRequestId;

        static ProxyService()
        {

            try
            {
                //Instanciación de los servicios
                _MC_EntradaServices = new MC_EntradaService.EntradaServiceClient();
                _MC_SalidaService = new MC_SalidaService.SalidaServiceClient();
                _MC_EnvioImagenes = new MC_EnvioImagenesService.EnvioImagenesServiceClient();
                _MC_LiquidacionService = new MC_LiquidacionService.LiquidacionServiceClient();
                _MC_SincronizacionService = new MC_SincronizacionService.SincronizacionServiceClient();
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Obtiene Id Unico
        /// </summary>
        public Guid NuevoRequestId
        {
            get { return Guid.NewGuid(); }
            set { _NuevoRequestId = value; }
        }
    }
}
