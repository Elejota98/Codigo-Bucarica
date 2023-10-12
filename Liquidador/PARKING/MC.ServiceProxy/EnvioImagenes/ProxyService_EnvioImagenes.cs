using MC.BusinessObjects.DataTransferObject;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using MC.ServiceProxy.DataTransferObjectMapper;
using MC.ServiceProxy.MC_EnvioImagenesService;
using MC.Utilidades;
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
        public ResultadoOperacion EnviarImagenesServidor(List<Imagen> oLstImagen)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {

                setAlmacenaImagenesServidor_Request request = new setAlmacenaImagenesServidor_Request();

                ServiceImagen[] lstmagenes = new ServiceImagen[oLstImagen.Count];

                for (int i = 0; i < oLstImagen.Count; i++)
                {
                    ServiceImagen oServiceImage = new ServiceImagen();
                    oServiceImage.NombreImagen = oLstImagen[i].NombreImagen;
                    oServiceImage.ContenidoImagen = Generales.RetornaStreamByte(oLstImagen[i].ContenidoImagen);
                    lstmagenes[i] = oServiceImage;
                }

                request.RequestId = NuevoRequestId;
                request.oImagenes = lstmagenes;

                setAlmacenaImagenesServidor_Response response = null;

                try
                {
                    SafeProxy.DoAction<EnvioImagenesServiceClient>(_MC_EnvioImagenes, client =>
                    { response = client.setAlmacenaImagenesServidor(request); });
                }
                catch (System.Exception ex)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error " + ex.ToString();
                    return oResultadoOperacion;
                }

                if (response != null)
                {
                    if (request.RequestId == response.CorrelationId)
                    {
                        if (response.Acknowledge == ServiceProxy.MC_EnvioImagenesService.AcknowledgeType.Success)
                        {

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
                        oResultadoOperacion.Mensaje = "Error setAlmacenaImagenesServidor()";
                        return oResultadoOperacion;
                    }
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error setAlmacenaImagenesServidor()";
                    return oResultadoOperacion;
                }


            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
                return oResultadoOperacion;
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion EnviarImagenesServidorCloud(List<Imagen> oLstImagen)
        {

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            setAlmacenaImagenesServidorCloud_Request request = new setAlmacenaImagenesServidorCloud_Request();

            ServiceImagen[] lstmagenes = new ServiceImagen[oLstImagen.Count];

            for (int i = 0; i < oLstImagen.Count; i++)
            {
                ServiceImagen oServiceImage = new ServiceImagen();
                oServiceImage.NombreImagen = oLstImagen[i].NombreImagen;
                oServiceImage.ContenidoImagen = Generales.RetornaStreamByte(oLstImagen[i].ContenidoImagen);
                lstmagenes[i] = oServiceImage;
            }

            request.RequestId = NuevoRequestId;
            request.oImagenes = lstmagenes;

            setAlmacenaImagenesServidorCloud_Response response = null;

            try
            {
                SafeProxy.DoAction<EnvioImagenesServiceClient>(_MC_EnvioImagenes, client =>
                { response = client.setAlmacenaImagenesServidorCloud(request); });
            }
            catch (System.Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = "Error " + ex.ToString();
                return oResultadoOperacion;
            }

            if (response != null)
            {
                if (request.RequestId == response.CorrelationId)
                {
                    if (response.Acknowledge == ServiceProxy.MC_EnvioImagenesService.AcknowledgeType.Success)
                    {

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
                    oResultadoOperacion.Mensaje = "Error setAlmacenaImagenesServidor()";
                    return oResultadoOperacion;
                }
            }
            else
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = "Error setAlmacenaImagenesServidor()";
                return oResultadoOperacion;
            }

            return oResultadoOperacion;
        }
    }
}
