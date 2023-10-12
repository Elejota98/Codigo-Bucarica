using MC.BaseService;
using MC.BaseService.MessageBase.Type;
using MC.BusinessService.DataTransferObject;
using MC.BusinessService.Entities;
using MC.BusinessService.Enums;
using MC.DataService;
using MC.SincronizacionService.Messages;
using MC.SincronizacionService.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MC.SincronizacionService.ServiceImplementations
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SincronizacionService : ServiceBase, ISincronizacionService
    {
        public static IDataService _DataService = new DataService.DataService();

        public Sincronizacion_Response getDatosSincronizacion(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerSincronizacionTransaccion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoTransaccion oDtoTransaccion = (DtoTransaccion)oResultadoOperacion.EntidadDatos;

                //response.oDtoTransaccion = oDtoTransaccion;
                Transaccion oTransaccion = new Transaccion();

                oTransaccion.IdTransaccion = oDtoTransaccion.IdTransaccion;
                oTransaccion.CarrilEntrada = oDtoTransaccion.CarrilEntrada;
                oTransaccion.ModuloEntrada = oDtoTransaccion.ModuloEntrada;
                oTransaccion.IdEstacionamiento = oDtoTransaccion.IdEstacionamiento;
                oTransaccion.IdTarjeta = oDtoTransaccion.IdTarjeta;
                oTransaccion.PlacaEntrada = oDtoTransaccion.PlacaEntrada;
                oTransaccion.FechaEntrada = oDtoTransaccion.FechaEntrada;
                oTransaccion.FechaSalida = oDtoTransaccion.FechaSalida;

                if (oDtoTransaccion.ModuloSalida != string.Empty)
                {
                    oTransaccion.ModuloSalida = oDtoTransaccion.ModuloSalida;
                }
                else 
                {
                    oTransaccion.ModuloSalida = null;
                }
                oTransaccion.CarrilSalida = oDtoTransaccion.CarrilSalida;

                if (oDtoTransaccion.ModuloSalida != string.Empty)
                {
                    oTransaccion.PlacaSalida = oDtoTransaccion.PlacaSalida;
                }
                else
                {
                    oTransaccion.PlacaSalida = null;
                }
                
                oTransaccion.IdTipoVehiculo = oDtoTransaccion.IdTipoVehiculo;
                oTransaccion.Cortesia = oDtoTransaccion.Cortesia;
                oTransaccion.IdAutorizado = oDtoTransaccion.IdAutorizado;
                oTransaccion.Convenio1 = oDtoTransaccion.Convenio1;
                oTransaccion.Convenio2 = oDtoTransaccion.Convenio2;
                oTransaccion.Convenio3 = oDtoTransaccion.Convenio3;
                oTransaccion.ValorRecibido = oDtoTransaccion.ValorRecibido;
                oTransaccion.Cambio = oDtoTransaccion.Cambio;
                oTransaccion.Sincronizacion = true;
                oTransaccion.SincronizacionPago = false;
                oTransaccion.SincronizacionSalida = false;
                
                request.oTransaccion = oTransaccion;

                oResultadoOperacion = _DataService.RegistrarSincronizacionTransaccion(request.oTransaccion, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    string IdTransaccion = oResultadoOperacion.EntidadDatos.ToString();
                    long Transaccion = Convert.ToInt64(IdTransaccion);


                    oResultadoOperacion = _DataService.ActualizaSincronizacionTransaccion(Transaccion);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString(); 
                    }
                }
                else
                {

                    oResultadoOperacion = _DataService.ActualizaSincronizacionTransaccion(oTransaccion.IdTransaccion);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }
        public Sincronizacion_Response getDatosSincronizacionPago(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerSincronizacionPagoTransaccion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoTransaccion oDtoTransaccion = (DtoTransaccion)oResultadoOperacion.EntidadDatos;

                //response.oDtoTransaccion = oDtoTransaccion;
                Transaccion oTransaccion = new Transaccion();

                oTransaccion.IdTransaccion = oDtoTransaccion.IdTransaccion;
                oTransaccion.CarrilEntrada = oDtoTransaccion.CarrilEntrada;
                oTransaccion.ModuloEntrada = oDtoTransaccion.ModuloEntrada;
                oTransaccion.IdEstacionamiento = oDtoTransaccion.IdEstacionamiento;
                oTransaccion.IdTarjeta = oDtoTransaccion.IdTarjeta;
                oTransaccion.PlacaEntrada = oDtoTransaccion.PlacaEntrada;
                oTransaccion.FechaEntrada = oDtoTransaccion.FechaEntrada;
                oTransaccion.FechaSalida = oDtoTransaccion.FechaSalida;
                oTransaccion.ModuloSalida = oDtoTransaccion.ModuloSalida;
                oTransaccion.CarrilSalida = oDtoTransaccion.CarrilSalida;
                oTransaccion.PlacaSalida = oDtoTransaccion.PlacaSalida;
                oTransaccion.IdTipoVehiculo = oDtoTransaccion.IdTipoVehiculo;
                oTransaccion.Cortesia = oDtoTransaccion.Cortesia;
                oTransaccion.IdAutorizado = oDtoTransaccion.IdAutorizado;
                oTransaccion.Convenio1 = oDtoTransaccion.Convenio1;
                oTransaccion.Convenio2 = oDtoTransaccion.Convenio2;
                oTransaccion.Convenio3 = oDtoTransaccion.Convenio3;
                oTransaccion.ValorRecibido = oDtoTransaccion.ValorRecibido;
                oTransaccion.Cambio = oDtoTransaccion.Cambio;
                oTransaccion.Sincronizacion = true;
                oTransaccion.SincronizacionPago = true;
                oTransaccion.SincronizacionSalida = false;

                request.oTransaccion = oTransaccion;

                oResultadoOperacion = _DataService.RegistrarSincronizacionPagoTransaccion(request.oTransaccion, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    string IdTransaccion = oResultadoOperacion.EntidadDatos.ToString();
                    long Transaccion = Convert.ToInt64(IdTransaccion);


                    oResultadoOperacion = _DataService.ActualizaSincronizacionPagoTransaccion(Transaccion);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }
        public Sincronizacion_Response getDatosSincronizacionSalida(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerSincronizacionSalidaTransaccion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoTransaccion oDtoTransaccion = (DtoTransaccion)oResultadoOperacion.EntidadDatos;

                //response.oDtoTransaccion = oDtoTransaccion;
                Transaccion oTransaccion = new Transaccion();

                oTransaccion.IdTransaccion = oDtoTransaccion.IdTransaccion;
                oTransaccion.CarrilEntrada = oDtoTransaccion.CarrilEntrada;
                oTransaccion.ModuloEntrada = oDtoTransaccion.ModuloEntrada;
                oTransaccion.IdEstacionamiento = oDtoTransaccion.IdEstacionamiento;
                oTransaccion.IdTarjeta = oDtoTransaccion.IdTarjeta;
                oTransaccion.PlacaEntrada = oDtoTransaccion.PlacaEntrada;
                oTransaccion.FechaEntrada = oDtoTransaccion.FechaEntrada;
                oTransaccion.FechaSalida = oDtoTransaccion.FechaSalida;
                oTransaccion.ModuloSalida = oDtoTransaccion.ModuloSalida;
                oTransaccion.CarrilSalida = oDtoTransaccion.CarrilSalida;
                oTransaccion.PlacaSalida = oDtoTransaccion.PlacaSalida;
                oTransaccion.IdTipoVehiculo = oDtoTransaccion.IdTipoVehiculo;
                oTransaccion.Cortesia = oDtoTransaccion.Cortesia;
                oTransaccion.IdAutorizado = oDtoTransaccion.IdAutorizado;
                oTransaccion.Convenio1 = oDtoTransaccion.Convenio1;
                oTransaccion.Convenio2 = oDtoTransaccion.Convenio2;
                oTransaccion.Convenio3 = oDtoTransaccion.Convenio3;
                oTransaccion.ValorRecibido = oDtoTransaccion.ValorRecibido;
                oTransaccion.Cambio = oDtoTransaccion.Cambio;
                oTransaccion.Sincronizacion = true;
                oTransaccion.SincronizacionPago = true;
                oTransaccion.SincronizacionSalida = true;

                request.oTransaccion = oTransaccion;

                oResultadoOperacion = _DataService.RegistrarSincronizacionSalidaTransaccion(request.oTransaccion, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    string IdTransaccion = oResultadoOperacion.EntidadDatos.ToString();
                    long Transaccion = Convert.ToInt64(IdTransaccion);


                    oResultadoOperacion = _DataService.ActualizaSincronizacionSalidaTransaccion(Transaccion);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public Sincronizacion_Response getDatosPago(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerPagoSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoPago oDtoPago = (DtoPago)oResultadoOperacion.EntidadDatos;

                Pago oPago = new Pago();

                oPago.IdPago = oDtoPago.IdPago;
                oPago.IdTransaccion = oDtoPago.IdTransaccion;
                oPago.IdAutorizado = oDtoPago.IdAutorizado;
                oPago.IdEstacionamiento = oDtoPago.IdEstacionamiento;
                oPago.IdModulo = oDtoPago.IdModulo;
                oPago.IdFacturacion = oDtoPago.IdFacturacion;
                oPago.IdTipoPago = oDtoPago.IdTipoPago;
                oPago.FechaPago = oDtoPago.FechaPago;
                oPago.Subtotal = oDtoPago.Subtotal;
                oPago.Iva = oDtoPago.Iva;
                oPago.Total = oDtoPago.Total;
                oPago.NumeroFactura = oDtoPago.NumeroFactura;
                oPago.Sincronizacion = true;
                oPago.PagoMensual = oDtoPago.PagoMensual;
                oPago.Anulada = oDtoPago.Anulada;
                
                request.oPago = oPago;

                oResultadoOperacion = _DataService.RegistrarSincronizacionPago(request.oPago, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    string[] IdPago = oResultadoOperacion.EntidadDatos.ToString().Split(';');
                    //long Pago = Convert.ToInt64(IdPago);


                    oResultadoOperacion = _DataService.ActualizaSincronizacionPago(IdPago[0], oPago.IdPago, Convert.ToInt64(IdPago[1]));
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }
        public Sincronizacion_Response getDatosMovimientos(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerMovimientoSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoMovimientos oDtoMovimientos = (DtoMovimientos)oResultadoOperacion.EntidadDatos;

                Movimientos oMovimientos = new Movimientos();

                oMovimientos.IdMovimiento = oDtoMovimientos.IdMovimiento;
                oMovimientos.IdTransaccion = oDtoMovimientos.IdTransaccion;
                oMovimientos.IdEstacionamiento = oDtoMovimientos.IdEstacionamiento;
                oMovimientos.IdCancelacion = oDtoMovimientos.IdCancelacion;
                oMovimientos.IdCarga = oDtoMovimientos.IdCarga;
                oMovimientos.IdArqueo = oDtoMovimientos.IdArqueo;
                oMovimientos.IdModulo = oDtoMovimientos.IdModulo;
                oMovimientos.Parte = oDtoMovimientos.Parte;
                oMovimientos.Accion = oDtoMovimientos.Accion;
                oMovimientos.Denominacion = oDtoMovimientos.Denominacion;
                oMovimientos.Cantidad = oDtoMovimientos.Cantidad;
                oMovimientos.Valor = oDtoMovimientos.Valor;
                oMovimientos.FechaMovimiento = oDtoMovimientos.FechaMovimiento;
                oMovimientos.Sincronizacion = true;
                

                request.oMovimientos = oMovimientos;

                oResultadoOperacion = _DataService.RegistrarSincronizacionMovimiento(request.oMovimientos, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    //string IdMovimiento = oResultadoOperacion.EntidadDatos.ToString();
                    //long Movimiento = Convert.ToInt64(IdMovimiento);


                    oResultadoOperacion = _DataService.ActualizaSincronizacionMovimiento(oMovimientos.IdMovimiento);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }
        public Sincronizacion_Response getDatosArqueos(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerArqueoSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoArqueos oDtoArqueos = (DtoArqueos)oResultadoOperacion.EntidadDatos;

                Arqueos oArqueos = new Arqueos();

                oArqueos.IdArqueo = oDtoArqueos.IdArqueo;
                oArqueos.FechaInicio = oDtoArqueos.FechaInicio;
                oArqueos.FechaFin = oDtoArqueos.FechaFin;
                oArqueos.Valor = oDtoArqueos.Valor;
                oArqueos.IdUsuario = oDtoArqueos.IdUsuario;
                oArqueos.IdModulo = oDtoArqueos.IdModulo;
                oArqueos.IdEstacionamiento = oDtoArqueos.IdEstacionamiento;
                oArqueos.CantTransacciones = oDtoArqueos.CantTransacciones;
                oArqueos.Producido = oDtoArqueos.Producido;
                oArqueos.Tipo = oDtoArqueos.Tipo;
                oArqueos.Conteo = oDtoArqueos.Conteo;
                oArqueos.Sincronizacion = true;


                request.oArqueos = oArqueos;

                if (oArqueos.Valor > 0)
                {

                    oResultadoOperacion = _DataService.RegistrarSincronizacionArqueo(request.oArqueos, request.sConexion);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        string IdArqueo = oResultadoOperacion.EntidadDatos.ToString();
                        long Arqueo = Convert.ToInt64(IdArqueo);


                        oResultadoOperacion = _DataService.ActualizaSincronizacionArqueo(Arqueo);
                        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                        {
                            response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                        }
                    }
                    else
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = oResultadoOperacion.Mensaje;
                    }
                }
                else 
                {
                    oResultadoOperacion = _DataService.ActualizaSincronizacionArqueo(oArqueos.IdArqueo);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public Sincronizacion_Response getDatosAutorizaciones(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerAutorizacionesSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoAutorizado oDtoAutorizado = (DtoAutorizado)oResultadoOperacion.EntidadDatos;

                Autorizado oAutorizado = new Autorizado();

                oAutorizado.IdAutorizacion = oDtoAutorizado.IdAutorizacion;
                oAutorizado.IdEstacionamiento = oDtoAutorizado.IdEstacionamiento;
                oAutorizado.Regla = null;
                oAutorizado.NombreAutorizacion = oDtoAutorizado.NombreAutorizacion;
                oAutorizado.FechaInicial = oDtoAutorizado.FechaInicial;
                oAutorizado.FechaFinal = oDtoAutorizado.FechaFinal;
                oAutorizado.Estado = oDtoAutorizado.Estado;
                oAutorizado.Sincronizacion = true;;
                oAutorizado.IdTipo = oDtoAutorizado.IdTipo;
                

                request.oAutorizado = oAutorizado;

                oResultadoOperacion = _DataService.RegistrarSincronizacionAutorizacion(request.oAutorizado, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    string[] IdAutorizacion = oResultadoOperacion.EntidadDatos.ToString().Split(';');
                    //long Pago = Convert.ToInt64(IdPago);


                    oResultadoOperacion = _DataService.ActualizaSincronizacionAutorizacion(Convert.ToInt64(IdAutorizacion[0]), Convert.ToInt64(IdAutorizacion[1]));
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }
        public Sincronizacion_Response getDatosPersonasAutorizadas(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerPersonasAutorizadasSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoAutorizado oDtoAutorizado = (DtoAutorizado)oResultadoOperacion.EntidadDatos;

                Autorizado oAutorizado = new Autorizado();

                oAutorizado.Documento = oDtoAutorizado.Documento;
                oAutorizado.IdAutorizacion = oDtoAutorizado.IdAutorizacion;
                oAutorizado.IdEstacionamiento = oDtoAutorizado.IdEstacionamiento;
                oAutorizado.NombresAutorizado = oDtoAutorizado.NombresAutorizado;
                oAutorizado.IdTarjeta = oDtoAutorizado.IdTarjeta;
                oAutorizado.FechaCreacion = oDtoAutorizado.FechaCreacion;
                oAutorizado.DocumentoCreador = oDtoAutorizado.DocumentoCreador;
                oAutorizado.Estado = oDtoAutorizado.Estado;
                oAutorizado.Sincronizacion = false;
                oAutorizado.FechaInicial = oDtoAutorizado.FechaInicial;
                oAutorizado.FechaFinal = oDtoAutorizado.FechaFinal;
                oAutorizado.Telefono = oDtoAutorizado.Telefono;
                oAutorizado.Email = oDtoAutorizado.Email;
                oAutorizado.Placa1 = oDtoAutorizado.Placa1;
                oAutorizado.Placa2 = oDtoAutorizado.Placa2;

                request.oAutorizado = oAutorizado;

                oResultadoOperacion = _DataService.ValidarExistenciaPersonasAutorizadasSincronizacionCloud(oAutorizado.Documento, oAutorizado.IdEstacionamiento, request.sConexion);
                 if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                 {
                     //ACTUALIZA REGISTRO EN CLOUD
                     oResultadoOperacion = _DataService.ActualizaPersonasAutorizadasCloud(request.oAutorizado, request.sConexion);
                     if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                     {

                         oResultadoOperacion = _DataService.ActualizaPersonasSincronizacionAutorizacion(oAutorizado.Documento, oAutorizado.IdEstacionamiento);
                         if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                         {
                             response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                         }
                     }
                     else
                     {
                         response.Acknowledge = AcknowledgeType.Failure;
                         response.Message = oResultadoOperacion.Mensaje;
                     }
                 }
                 else 
                 {
                     oAutorizado.Sincronizacion = true;
                     oResultadoOperacion = _DataService.RegistrarSincronizacionPersonasAutorizadas(request.oAutorizado, request.sConexion);
                     if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                     {
                         string[] IdAutorizacion = oResultadoOperacion.EntidadDatos.ToString().Split(';');
                         //long Pago = Convert.ToInt64(IdPago);


                         oResultadoOperacion = _DataService.ActualizaPersonasSincronizacionAutorizacion(IdAutorizacion[0].ToString(), Convert.ToInt64(IdAutorizacion[1]));
                         if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                         {
                             response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                         }
                     }
                     else
                     {
                         response.Acknowledge = AcknowledgeType.Failure;
                         response.Message = oResultadoOperacion.Mensaje;
                     }
                 }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public Sincronizacion_Response getDatosConsignacion(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerConsignacionSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoConsignacion oDtoConsignacion = (DtoConsignacion)oResultadoOperacion.EntidadDatos;

                Consignacion oConsignacion = new Consignacion();

                oConsignacion.DocumentoUsuario = oDtoConsignacion.DocumentoUsuario;
                oConsignacion.FechaConsignacion = oDtoConsignacion.FechaConsignacion;
                oConsignacion.IdConsignacion = oDtoConsignacion.IdConsignacion;
                oConsignacion.IdEstacionamiento = oDtoConsignacion.IdEstacionamiento;
                oConsignacion.Referencia = oDtoConsignacion.Referencia;
                oConsignacion.Sincronizacion = true;
                oConsignacion.Valor = oDtoConsignacion.Valor;

                request.oConsignacion = oConsignacion;

                oResultadoOperacion = _DataService.RegistrarSincronizacionConsignacion(request.oConsignacion, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    string IdConsignacion = oResultadoOperacion.EntidadDatos.ToString();


                    oResultadoOperacion = _DataService.ActualizaConsignacionSincronizacion(oConsignacion.IdConsignacion);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {

                DtoConsignacion oDtoConsignacion = (DtoConsignacion)oResultadoOperacion.EntidadDatos;

                Consignacion oConsignacion = new Consignacion();
                oConsignacion.IdConsignacion = oDtoConsignacion.IdConsignacion;

                oResultadoOperacion = _DataService.ActualizaConsignacionSincronizacion(oConsignacion.IdConsignacion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                }

                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }
        public Sincronizacion_Response getDatosFacturasManuales(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerFacturasManualesSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoFacturasManuales oDtoFacturasManuales = (DtoFacturasManuales)oResultadoOperacion.EntidadDatos;

                FacturasManuales oFacturasManuales = new FacturasManuales();

                oFacturasManuales.DocumentoUsuario = oDtoFacturasManuales.DocumentoUsuario;
                oFacturasManuales.FechaPago = oDtoFacturasManuales.FechaPago;
                oFacturasManuales.IdEstacionamiento = oDtoFacturasManuales.IdEstacionamiento;
                oFacturasManuales.IdModulo = oDtoFacturasManuales.IdModulo;
                oFacturasManuales.IdTipoVehiculo = oDtoFacturasManuales.IdTipoVehiculo;
                oFacturasManuales.Iva = oDtoFacturasManuales.Iva;
                oFacturasManuales.NumeroFactura = oDtoFacturasManuales.NumeroFactura;
                oFacturasManuales.Prefijo = oDtoFacturasManuales.Prefijo;
                oFacturasManuales.Sincronizacion = true;
                oFacturasManuales.Subtotal = oDtoFacturasManuales.Subtotal;
                oFacturasManuales.Total = oDtoFacturasManuales.Total;
                

                request.oFacturasManuales = oFacturasManuales;

                oResultadoOperacion = _DataService.RegistrarSincronizacionFacturasManuales(request.oFacturasManuales, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    string[] Facturas = oResultadoOperacion.EntidadDatos.ToString().Split(';');


                    oResultadoOperacion = _DataService.ActualizaFacturasManualesSincronizacion(Convert.ToInt64(Facturas[1]), Facturas[0]);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        public Sincronizacion_Response getValidacionRed(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

        ResultadoOperacion oResultadoOperacion = _DataService.ObtenerDocumentoPermisosEstacionamientoSincronizacion(request.lIdEstacionamiento,request.sConexion);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoAutorizado oDtoAutorizado = (DtoAutorizado)oResultadoOperacion.EntidadDatos;

                Autorizado oAutorizado = new Autorizado();

                oAutorizado.Documento = oDtoAutorizado.Documento;
                request.sDocumento = oAutorizado.Documento;

                oResultadoOperacion = _DataService.ObtenerInfoPersonasAutorizadasSincronizacion(request.sDocumento, request.lIdEstacionamiento, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    DtoAutorizado oDtoAutorizado2 = (DtoAutorizado)oResultadoOperacion.EntidadDatos;

                    Autorizado oAutorizado2 = new Autorizado();

                    oAutorizado2.Documento = oDtoAutorizado2.Documento;
                    oAutorizado2.IdAutorizacion = oDtoAutorizado2.IdAutorizacion;
                    oAutorizado2.IdEstacionamiento = request.lIdEstacionamiento;
                    oAutorizado2.NombresAutorizado = oDtoAutorizado2.NombresAutorizado;
                    oAutorizado2.IdTarjeta = oDtoAutorizado2.IdTarjeta;
                    oAutorizado2.FechaCreacion = oDtoAutorizado2.FechaCreacion;
                    oAutorizado2.DocumentoCreador = oDtoAutorizado2.DocumentoCreador;
                    oAutorizado2.Estado = oDtoAutorizado2.Estado;
                    oAutorizado2.Sincronizacion = true;
                    oAutorizado2.FechaInicial = oDtoAutorizado2.FechaInicial;
                    oAutorizado2.FechaFinal = oDtoAutorizado2.FechaFinal;
                    oAutorizado2.Telefono = oDtoAutorizado2.Telefono;
                    oAutorizado2.Email = oDtoAutorizado2.Email;
                    oAutorizado2.Placa1 = oDtoAutorizado2.Placa1;
                    oAutorizado2.Placa2 = oDtoAutorizado2.Placa2;

                    request.sDocumento = oAutorizado.Documento;

                    oResultadoOperacion = _DataService.ValidarExistenciaPersonasAutorizadasSincronizacion(request.sDocumento, request.lIdEstacionamiento);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        //ACTUALIZA AUTORIZADO
                        request.oAutorizado = oAutorizado2;
                        oResultadoOperacion = _DataService.ActualizaPersonasAutorizadasRed(request.oAutorizado);
                        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                        {
                            oResultadoOperacion = _DataService.ActualizaPersonasAutorizadasRedCloud(request.sDocumento,request.lIdEstacionamiento,request.sConexion);
                            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                            {
                                response.Acknowledge = AcknowledgeType.Success;
                                response.Message = oResultadoOperacion.Mensaje;
                            }
                            else
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                response.Message = oResultadoOperacion.Mensaje;
                            }
                        }
                        else 
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = oResultadoOperacion.Mensaje;
                        }
                    }
                    else 
                    {
                        //INSERTA AUTORIZADO
                        request.oAutorizado = oAutorizado2;
                        oResultadoOperacion = _DataService.RegistrarPersonasAutoRed(request.oAutorizado);
                        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                        {
                            oResultadoOperacion = _DataService.ActualizaPersonasAutorizadasRedCloud(request.sDocumento, request.lIdEstacionamiento, request.sConexion);
                            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                            {
                                response.Acknowledge = AcknowledgeType.Success;
                                response.Message = oResultadoOperacion.Mensaje;
                            }
                            else
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                response.Message = oResultadoOperacion.Mensaje;
                            }
                        }
                        else
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = oResultadoOperacion.Mensaje;
                        }
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }

        
        public Sincronizacion_Response getDatosCortesias(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerCortesiasSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoCortesias oDtoCortesias = (DtoCortesias)oResultadoOperacion.EntidadDatos;

                Cortesias oCortesias = new Cortesias();

                oCortesias.DocumentoUsuario = oDtoCortesias.DocumentoUsuario;
                oCortesias.FechaCortesia = oDtoCortesias.FechaCortesia;
                oCortesias.IdEstacionamiento = oDtoCortesias.IdEstacionamiento;
                oCortesias.IdMotivo = oDtoCortesias.IdMotivo;
                oCortesias.IdTransaccion = oDtoCortesias.IdTransaccion;
                oCortesias.Observacion = oDtoCortesias.Observacion;
                oCortesias.Sincronizacion = true;

                request.oCortesias = oCortesias;

                oResultadoOperacion = _DataService.RegistrarSincronizacionCortesias(request.oCortesias, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    oResultadoOperacion = _DataService.ActualizaCortesiasSincronizacion(oCortesias.IdTransaccion, oCortesias.IdEstacionamiento);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {

                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }
        public Sincronizacion_Response getDatosConvenios(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerConveniosSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoConvenios oDtoConvenios = (DtoConvenios)oResultadoOperacion.EntidadDatos;

                Convenios oConvenios = new Convenios();

                oConvenios.Descripcion = oDtoConvenios.Descripcion;
                oConvenios.Estado = oDtoConvenios.Estado;
                oConvenios.FechaFinal = oDtoConvenios.FechaFinal;
                oConvenios.FechaInicial = oDtoConvenios.FechaInicial;
                oConvenios.IdConvenio = oDtoConvenios.IdConvenio;
                oConvenios.IdEstacionamiento = oDtoConvenios.IdEstacionamiento;
                oConvenios.Nombre = oDtoConvenios.Nombre;
                oConvenios.Sincronizacion = true;

                request.oConvenios = oConvenios;

                oResultadoOperacion = _DataService.RegistrarSincronizacionConvenios(request.oConvenios, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    string IdConsignacion = oResultadoOperacion.EntidadDatos.ToString();


                    oResultadoOperacion = _DataService.ActualizaConveniosSincronizacion(oConvenios.IdEstacionamiento,oConvenios.IdConvenio);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {

                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }
        public Sincronizacion_Response getDatosTalanqueras(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerEventosSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoTalanquera oDtoTalanquera = (DtoTalanquera)oResultadoOperacion.EntidadDatos;

                Talanquera oTalanquera = new Talanquera();

                oTalanquera.Estado = oDtoTalanquera.Estado;
                oTalanquera.FechaHora = oDtoTalanquera.FechaHora;
                oTalanquera.IdEstacionamiento = oDtoTalanquera.IdEstacionamiento;
                oTalanquera.IdEventoDispositivo = oDtoTalanquera.IdEventoDispositivo;
                oTalanquera.IdModulo = oDtoTalanquera.IdModulo;
                oTalanquera.Sincronizacion = true;
                oTalanquera.Observacion = oDtoTalanquera.Observacion;
                oTalanquera.Usuario = oDtoTalanquera.Usuario;

                request.oTalanquera = oTalanquera;

                oResultadoOperacion = _DataService.RegistrarSincronizacionEventos(request.oTalanquera, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    string IdConsignacion = oResultadoOperacion.EntidadDatos.ToString();


                    oResultadoOperacion = _DataService.ActualizaEventoDispositivoSincronizacion(oTalanquera.IdEventoDispositivo);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            else
            {

                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = oResultadoOperacion.Mensaje;
            }

            return response;
        }
        public Sincronizacion_Response getDatosUsuarios(Sincronizacion_Request request)
        {
            Sincronizacion_Response response = new Sincronizacion_Response();

            response.CorrelationId = request.RequestId;

            if (!ValidRequest(request, response))
                return response;

            ResultadoOperacion oResultadoOperacion = _DataService.ObtenerUsuariosSincronizacion();
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                DtoUsuario oDtoUsuario = (DtoUsuario)oResultadoOperacion.EntidadDatos;

                Usuarios oUsuarios = new Usuarios();

                oUsuarios.Apellidos = oDtoUsuario.Apellidos;
                oUsuarios.Cargo = oDtoUsuario.Cargo;
                oUsuarios.Contraseña = oDtoUsuario.Contraseña;
                oUsuarios.Documento = oDtoUsuario.Documento;
                oUsuarios.Estado = oDtoUsuario.Estado;
                oUsuarios.Sincronizacion = true;
                oUsuarios.FechaCreacion = oDtoUsuario.FechaCreacion;
                oUsuarios.IdTarjeta = oDtoUsuario.IdTarjeta;
                oUsuarios.Nombres = oDtoUsuario.Nombres;
                oUsuarios.Usuario = oDtoUsuario.Usuario;
                oUsuarios.UsuarioCreador = oDtoUsuario.UsuarioCreador;

                request.oUsuarios = oUsuarios;

                oResultadoOperacion = _DataService.RegistrarSincronizacionUsuarios(request.oUsuarios, request.sConexion);
                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    string IdConsignacion = oResultadoOperacion.EntidadDatos.ToString();


                    oResultadoOperacion = _DataService.ActualizaUsuariosSincronizacion(oUsuarios.Documento);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        response.sResult = oResultadoOperacion.EntidadDatos.ToString();
                    }
                }
                else
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = oResultadoOperacion.Mensaje;
                }
            }
            
            return response;
        }


        //public Sincronizacion_Response getDatosFacturacion(Sincronizacion_Request request)
        //{
        //    Sincronizacion_Response response = new Sincronizacion_Response();

        //    response.CorrelationId = request.RequestId;

        //    if (!ValidRequest(request, response))
        //        return response;

        //    ResultadoOperacion oResultadoOperacion = _DataService.ObtenerConsignacionSincronizacion();
        //    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //    {
        //        DtoConsignacion oDtoConsignacion = (DtoConsignacion)oResultadoOperacion.EntidadDatos;

        //        Consignacion oConsignacion = new Consignacion();

        //        oConsignacion.DocumentoUsuario = oDtoConsignacion.DocumentoUsuario;
        //        oConsignacion.FechaConsignacion = oDtoConsignacion.FechaConsignacion;
        //        oConsignacion.IdConsignacion = oDtoConsignacion.IdConsignacion;
        //        oConsignacion.IdEstacionamiento = oDtoConsignacion.IdEstacionamiento;
        //        oConsignacion.Referencia = oDtoConsignacion.Referencia;
        //        oConsignacion.Sincronizacion = true;
        //        oConsignacion.Valor = oDtoConsignacion.Valor;

        //        request.oConsignacion = oConsignacion;

        //        oResultadoOperacion = _DataService.RegistrarSincronizacionConsignacion(request.oConsignacion, request.sConexion);
        //        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //        {
        //            string IdConsignacion = oResultadoOperacion.EntidadDatos.ToString();


        //            oResultadoOperacion = _DataService.ActualizaConsignacionSincronizacion(oConsignacion.IdConsignacion);
        //            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //            {
        //                response.sResult = oResultadoOperacion.EntidadDatos.ToString();
        //            }
        //        }
        //        else
        //        {
        //            response.Acknowledge = AcknowledgeType.Failure;
        //            response.Message = oResultadoOperacion.Mensaje;
        //        }
        //    }
        //    else
        //    {

        //        DtoConsignacion oDtoConsignacion = (DtoConsignacion)oResultadoOperacion.EntidadDatos;

        //        Consignacion oConsignacion = new Consignacion();
        //        oConsignacion.IdConsignacion = oDtoConsignacion.IdConsignacion;

        //        oResultadoOperacion = _DataService.ActualizaConsignacionSincronizacion(oConsignacion.IdConsignacion);
        //        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //        {
        //            response.sResult = oResultadoOperacion.EntidadDatos.ToString();
        //        }

        //        response.Acknowledge = AcknowledgeType.Failure;
        //        response.Message = oResultadoOperacion.Mensaje;
        //    }

        //    return response;
        //}
        //public Sincronizacion_Response getDatosParametros(Sincronizacion_Request request)
        //{
        //    Sincronizacion_Response response = new Sincronizacion_Response();

        //    response.CorrelationId = request.RequestId;

        //    if (!ValidRequest(request, response))
        //        return response;

        //    ResultadoOperacion oResultadoOperacion = _DataService.ObtenerConsignacionSincronizacion();
        //    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //    {
        //        DtoConsignacion oDtoConsignacion = (DtoConsignacion)oResultadoOperacion.EntidadDatos;

        //        Consignacion oConsignacion = new Consignacion();

        //        oConsignacion.DocumentoUsuario = oDtoConsignacion.DocumentoUsuario;
        //        oConsignacion.FechaConsignacion = oDtoConsignacion.FechaConsignacion;
        //        oConsignacion.IdConsignacion = oDtoConsignacion.IdConsignacion;
        //        oConsignacion.IdEstacionamiento = oDtoConsignacion.IdEstacionamiento;
        //        oConsignacion.Referencia = oDtoConsignacion.Referencia;
        //        oConsignacion.Sincronizacion = true;
        //        oConsignacion.Valor = oDtoConsignacion.Valor;

        //        request.oConsignacion = oConsignacion;

        //        oResultadoOperacion = _DataService.RegistrarSincronizacionConsignacion(request.oConsignacion, request.sConexion);
        //        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //        {
        //            string IdConsignacion = oResultadoOperacion.EntidadDatos.ToString();


        //            oResultadoOperacion = _DataService.ActualizaConsignacionSincronizacion(oConsignacion.IdConsignacion);
        //            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //            {
        //                response.sResult = oResultadoOperacion.EntidadDatos.ToString();
        //            }
        //        }
        //        else
        //        {
        //            response.Acknowledge = AcknowledgeType.Failure;
        //            response.Message = oResultadoOperacion.Mensaje;
        //        }
        //    }
        //    else
        //    {

        //        DtoConsignacion oDtoConsignacion = (DtoConsignacion)oResultadoOperacion.EntidadDatos;

        //        Consignacion oConsignacion = new Consignacion();
        //        oConsignacion.IdConsignacion = oDtoConsignacion.IdConsignacion;

        //        oResultadoOperacion = _DataService.ActualizaConsignacionSincronizacion(oConsignacion.IdConsignacion);
        //        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //        {
        //            response.sResult = oResultadoOperacion.EntidadDatos.ToString();
        //        }

        //        response.Acknowledge = AcknowledgeType.Failure;
        //        response.Message = oResultadoOperacion.Mensaje;
        //    }

        //    return response;
        //}
        //public Sincronizacion_Response getDatosTarifas(Sincronizacion_Request request)
        //{
        //    Sincronizacion_Response response = new Sincronizacion_Response();

        //    response.CorrelationId = request.RequestId;

        //    if (!ValidRequest(request, response))
        //        return response;

        //    ResultadoOperacion oResultadoOperacion = _DataService.ObtenerConsignacionSincronizacion();
        //    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //    {
        //        DtoConsignacion oDtoConsignacion = (DtoConsignacion)oResultadoOperacion.EntidadDatos;

        //        Consignacion oConsignacion = new Consignacion();

        //        oConsignacion.DocumentoUsuario = oDtoConsignacion.DocumentoUsuario;
        //        oConsignacion.FechaConsignacion = oDtoConsignacion.FechaConsignacion;
        //        oConsignacion.IdConsignacion = oDtoConsignacion.IdConsignacion;
        //        oConsignacion.IdEstacionamiento = oDtoConsignacion.IdEstacionamiento;
        //        oConsignacion.Referencia = oDtoConsignacion.Referencia;
        //        oConsignacion.Sincronizacion = true;
        //        oConsignacion.Valor = oDtoConsignacion.Valor;

        //        request.oConsignacion = oConsignacion;

        //        oResultadoOperacion = _DataService.RegistrarSincronizacionConsignacion(request.oConsignacion, request.sConexion);
        //        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //        {
        //            string IdConsignacion = oResultadoOperacion.EntidadDatos.ToString();


        //            oResultadoOperacion = _DataService.ActualizaConsignacionSincronizacion(oConsignacion.IdConsignacion);
        //            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //            {
        //                response.sResult = oResultadoOperacion.EntidadDatos.ToString();
        //            }
        //        }
        //        else
        //        {
        //            response.Acknowledge = AcknowledgeType.Failure;
        //            response.Message = oResultadoOperacion.Mensaje;
        //        }
        //    }
        //    else
        //    {

        //        DtoConsignacion oDtoConsignacion = (DtoConsignacion)oResultadoOperacion.EntidadDatos;

        //        Consignacion oConsignacion = new Consignacion();
        //        oConsignacion.IdConsignacion = oDtoConsignacion.IdConsignacion;

        //        oResultadoOperacion = _DataService.ActualizaConsignacionSincronizacion(oConsignacion.IdConsignacion);
        //        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
        //        {
        //            response.sResult = oResultadoOperacion.EntidadDatos.ToString();
        //        }

        //        response.Acknowledge = AcknowledgeType.Failure;
        //        response.Message = oResultadoOperacion.Mensaje;
        //    }

        //    return response;
        //}

    }
}
