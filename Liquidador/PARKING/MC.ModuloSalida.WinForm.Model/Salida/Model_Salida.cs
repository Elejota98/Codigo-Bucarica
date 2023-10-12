using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ModuloSalida.WinForm.Model
{
    public partial class Model : IModel
    {

        public ResultadoOperacion ObtenerPartesModulo(Modulo oModulo)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.ObtenerPartesModuloSalida(oModulo);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion RegistrarMovimiento(Transaccion oTransaccion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.RegistrarMovimientoSalida(oTransaccion);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion ObtenerParametrosModulo(long IdEstacionamiento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.ObtenerParametrosSalida(IdEstacionamiento);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion ObtenerInfoModulo(Modulo oModulo)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.ObtenerInformacionModuloSalida(oModulo);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion RegistrarAlarma(Alarma oAlarma)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.RegistrarAlarmaSalida(oAlarma);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion ObtenerAutorizado(Autorizado oAutorizado)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.ObtenerAutorizadoSalida(oAutorizado);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion SolucionarTodasAlarmas(Modulo oModulo)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.SolucionarTodasAlarmasSalida(oModulo);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion ObtenerTarjetas(Modulo oModulo)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.ObtenerTarjetasSalida(oModulo);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion ObtenerEvento(long Secuencia)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.ObtenerEvento(Secuencia);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion ObtenerEventoDispo()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.ObtenerEventoDispositivoSalida();

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion ActualizarEventoDispositivo(long IdEvento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.ActualizarEventoDispositivoSalida(IdEvento);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion ValidarSalidaAuto(string IDCARD)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = _ProxyServicios.ValidarSalidaAuto(IDCARD);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                // Generar Alarma para Base de Datos
            }

            return oResultadoOperacion;
        }


    }
}
