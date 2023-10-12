using MC.BusinessObjects.DataTransferObject;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using MC.ServiceProxy.DataTransferObjectMapper;
using MC.ServiceProxy.MC_LiquidacionService;
using MC.WCFProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ServiceProxy
{
    public partial class ProxyService : IProxyService
    {
        public ResultadoOperacion ObtenerDatosLiquidacion(string sSecuencia,int iTipoVehiculo,bool bMensualidad,bool bReposicion, string Convenios)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            List<DtoDatosLiquidacion> olstDtoLiquidacion = new List<DtoDatosLiquidacion>();

            Liquidacion_Request request = new Liquidacion_Request();
            request.RequestId = NuevoRequestId;

            request.bMensualidad = bMensualidad;
            request.bReposicion = bReposicion;
            request.iTipoVehiculo = iTipoVehiculo;
            request.sSecuencia = sSecuencia;
            request.sConvenios = Convenios;


            Liquidacion_Response response = null;


            try
            {
                SafeProxy.DoAction<LiquidacionServiceClient>(_MC_LiquidacionService, client =>
                { response = client.getDatosLiquidacion(request); });
            }
            catch (System.Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_LiquidacionService.AcknowledgeType.Success)
                {
                    olstDtoLiquidacion = Mapper.FromDataTransferObjects(response.olstDtoLiquidacion);
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = response.Message;
                    return oResultadoOperacion;
                }

            }
            else
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = "ObtenerInformacionModulo() error response == null";
                return oResultadoOperacion;
            }

            oResultadoOperacion.ListaEntidadDatos = olstDtoLiquidacion;
            if (olstDtoLiquidacion.Count > 0)
            {
                oResultadoOperacion.EntidadDatos = olstDtoLiquidacion[0].Total;
            }
            else
            {
                oResultadoOperacion.EntidadDatos = string.Empty;
            }
            return oResultadoOperacion;
        }
    }
}
