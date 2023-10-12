using MC.BaseService;
using MC.BaseService.MessageBase.Type;
using MC.BusinessService.DataTransferObject;
using MC.BusinessService.Entities;
using MC.BusinessService.Enums;
using MC.DataService;
using MC.EntradaService.Messages;
using MC.EntradaService.ServiceContracts;
using MC.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MC.EntradaService.ServiceImplementations
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class EntradaService : ServiceBase, IEntradaService
    {
        public static IDataService _DataService = new DataService.DataService();

        public getPartesModulo_Response getPartesModulo(getPartesModulo_Request request)
        {
            getPartesModulo_Response response = new getPartesModulo_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerInfoPartes(request.oModulo);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                List<DtoParteModulo> olstDtoParteModulo = (List<DtoParteModulo>)oResultadoOperacion.ListaEntidadDatos;
                response.olstDtoParteModulo = olstDtoParteModulo;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public setRegistrarTransaccion_Response setRegistrarTransaccion(setRegistrarTransaccion_Request request)
        {
            setRegistrarTransaccion_Response response = new setRegistrarTransaccion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.RegistrarTransaccion(request.oTransaccion);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                long idTransaccion = (long)oResultadoOperacion.EntidadDatos;
                response.lIdTransaccion = idTransaccion;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public setRegistrarAlarma_Response setRegistrarAlarma(setRegistrarAlarma_Request request)
        {
            setRegistrarAlarma_Response response = new setRegistrarAlarma_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.RegistrarAlarma(request.oAlarma);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {

            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public getInformacionModulo_Response getInformacionModulo(getInformacionModulo_Request request)
        {
            getInformacionModulo_Response response = new getInformacionModulo_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerInfoModulo(request.oModulo);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoModulo oDtoModulo = (DtoModulo)oResultadoOperacion.EntidadDatos;
                response.oDatosModulo = oDtoModulo;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public getParametros_Response getParametros(getParametros_Request request)
        {
            getParametros_Response response = new getParametros_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerParametros(request.IdEstacionamiento);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                List<DtoParametros> olstDtoParametros = (List<DtoParametros>)oResultadoOperacion.ListaEntidadDatos;
                response.olstDtoParametros = olstDtoParametros;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public getInfoAutorizado_Response getInfoAutorizado(getInfoAutorizado_Request request)
        {
            getInfoAutorizado_Response response = new getInfoAutorizado_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerInfoAutorizado(request.oAutorizado);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                List<DtoAutorizado> olstDtoAutorizado = (List<DtoAutorizado>)oResultadoOperacion.ListaEntidadDatos;
                response.olstDtoAutorizado = olstDtoAutorizado;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public setSolucionarAlarmas_Response setSolucionarAlarmas(setSolucionarAlarmas_Request request)
        {
            setSolucionarAlarmas_Response response = new setSolucionarAlarmas_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.SolucionarTodasAlarmas(request.oModulo);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                response.sResult = oResultadoOperacion.EntidadDatos.ToString();
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public getTarjetas_Response getTarjetas(getTarjetas_Request request)
        {
            getTarjetas_Response response = new getTarjetas_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerTarjetas(request.oModulo);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                List<DtoTarjetas> olstDtoTarjetas = (List<DtoTarjetas>)oResultadoOperacion.ListaEntidadDatos;
                response.olstDtoTarjetas = olstDtoTarjetas;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public getEventosDispositivo_Response getEventosDispositivo(getEventosDispositivo_Request request)
        {
            getEventosDispositivo_Response response = new getEventosDispositivo_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerEventoDisposito();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                response.oResult = (string)oResultadoOperacion.EntidadDatos;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public getEventosDispositivo_Response SetActualizarEventoDispositivo(getEventosDispositivo_Request request)
        {
            getEventosDispositivo_Response response = new getEventosDispositivo_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ActualizarEvento(request.oIdEvento);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                if (oResultadoOperacion.EntidadDatos.ToString() != string.Empty)
                {
                    response.bRegistro = true;
                }
                else
                {
                    response.bRegistro = false;
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public getValidarIngresoAutorizado_Response getValidarIngresoAutorizado(getValidarIngresoAutorizado_Request request)
        {
            getValidarIngresoAutorizado_Response response = new getValidarIngresoAutorizado_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ValidarIngresoAuto(request.sIdCard);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                if (oResultadoOperacion.EntidadDatos.ToString() != string.Empty)
                {
                    response.bAutoIngreso = false;
                }
                else
                {
                    response.bAutoIngreso = true;
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }
    }
}
