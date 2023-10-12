using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using MC.ServiceProxy.MC_SincronizacionService;
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
        public ResultadoOperacion GenerarSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string IdTransaccion = string.Empty; 

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosSincronizacion(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    IdTransaccion = response.sResult;
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

            oResultadoOperacion.EntidadDatos = IdTransaccion;
            return oResultadoOperacion;
        }
        public ResultadoOperacion GenerarSincronizacionPago(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string IdTransaccion = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosSincronizacionPago(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    IdTransaccion = response.sResult;
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

            oResultadoOperacion.EntidadDatos = IdTransaccion;
            return oResultadoOperacion;
        }
        public ResultadoOperacion GenerarSincronizacionSalida(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string IdTransaccion = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosSincronizacionSalida(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    IdTransaccion = response.sResult;
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

            oResultadoOperacion.EntidadDatos = IdTransaccion;
            return oResultadoOperacion;
        }

        public ResultadoOperacion GenerarPagoSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string IdPago = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosPago(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    IdPago = response.sResult;
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

            oResultadoOperacion.EntidadDatos = IdPago;
            return oResultadoOperacion;
        }
        public ResultadoOperacion GenerarMovimientosSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string IdMovimiento = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosMovimientos(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    IdMovimiento = response.sResult;
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

            oResultadoOperacion.EntidadDatos = IdMovimiento;
            return oResultadoOperacion;
        }
        public ResultadoOperacion GenerarArqueosSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string IdArqueo = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosArqueos(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    IdArqueo = response.sResult;
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

            oResultadoOperacion.EntidadDatos = IdArqueo;
            return oResultadoOperacion;
        }

        public ResultadoOperacion GenerarAutorizacionesSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string IdAutorizacion = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosAutorizaciones(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    IdAutorizacion = response.sResult;
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

            oResultadoOperacion.EntidadDatos = IdAutorizacion;
            return oResultadoOperacion;
        }
        public ResultadoOperacion GenerarPersonasAutorizadasSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string Documento = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosPersonasAutorizadas(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    Documento = response.sResult;
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

            oResultadoOperacion.EntidadDatos = Documento;
            return oResultadoOperacion;
        }

        public ResultadoOperacion GenerarConsignacionSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string IdConsignacion = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosConsignacion(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    IdConsignacion = response.sResult;
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

            oResultadoOperacion.EntidadDatos = IdConsignacion;
            return oResultadoOperacion;
        }
        public ResultadoOperacion GenerarFacturasManualesSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string Facturas = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosFacturasManuales(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    Facturas = response.sResult;
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

            oResultadoOperacion.EntidadDatos = Facturas;
            return oResultadoOperacion;
        }

        public ResultadoOperacion GenerarCortesiasSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string Facturas = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosCortesias(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    Facturas = response.sResult;
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

            oResultadoOperacion.EntidadDatos = Facturas;
            return oResultadoOperacion;
        }
        public ResultadoOperacion GenerarConveniosSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string Facturas = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosConvenios(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    Facturas = response.sResult;
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

            oResultadoOperacion.EntidadDatos = Facturas;
            return oResultadoOperacion;
        }
        public ResultadoOperacion GenerarEventosDispositivosSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string Facturas = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosTalanqueras(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    Facturas = response.sResult;
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

            oResultadoOperacion.EntidadDatos = Facturas;
            return oResultadoOperacion;
        }


        public ResultadoOperacion ValidacionAutorizadosSincronizacion(string Conexion,long sIdEstacionamiento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string Facturas = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;
            request.lIdEstacionamiento = sIdEstacionamiento;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getValidacionRed(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    Facturas = response.sResult;
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

            oResultadoOperacion.EntidadDatos = Facturas;
            return oResultadoOperacion;
        }

        public ResultadoOperacion GenerarUsuariosSincronizacion(string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string Usuarios = string.Empty;

            Sincronizacion_Request request = new Sincronizacion_Request();
            request.RequestId = NuevoRequestId;

            request.sConexion = Conexion;

            Sincronizacion_Response response = null;


            try
            {
                SafeProxy.DoAction<SincronizacionServiceClient>(_MC_SincronizacionService, client =>
                { response = client.getDatosUsuarios(request); });
            }
            catch (System.Exception)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                return oResultadoOperacion;
            }

            if (response != null)
            {

                if (response.Acknowledge == ServiceProxy.MC_SincronizacionService.AcknowledgeType.Success)
                {
                    Usuarios = response.sResult;
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

            oResultadoOperacion.EntidadDatos = Usuarios;
            return oResultadoOperacion;
        }
    }
}
