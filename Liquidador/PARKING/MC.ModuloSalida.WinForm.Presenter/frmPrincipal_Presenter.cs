using EGlobalT.Device.SmartCard;
using MC.BusinessObjects.DataTransferObject;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using MC.CRT603Device;
using MC.KytsDevice;
using MC.ModuloSalida.WinForm.View;
using MC.PLCDevice;
using MC.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MC.ModuloSalida.WinForm.Presenter
{
    public class frmPrincipal_Presenter : Presenter<IView_Principal>
    {
        public frmPrincipal_Presenter(IView_Principal view)
            : base(view)
        {
            oPLCDevice.DeviceMessage += new EventHandler(oPLCDevice_DeviceMessage);
            oKYTsDevice.DeviceMessageKytState += new EventHandler(oKYTsDevice_DeviceMessage);
            oCRTDevice.DeviceMessageCrtState += new EventHandler(oCRTDevice_DeviceMessage);
        }


        
        PLCDeviceClass oPLCDevice = new PLCDeviceClass();
        KYTsDeviceClass oKYTsDevice = new KYTsDeviceClass();
        CRTDeviceClass oCRTDevice = new CRTDeviceClass();

        string Descripcion = string.Empty;
        int NivelError = 0;
        string Parte = string.Empty;
        string TipoError = string.Empty;
        bool LoadKey = false;
        bool CheckKey = false;

        #region Modulo
        public bool ObtenerInfoModulo()
        {
            Modulo oModulo = new Modulo();
            oModulo.IdModulo = Globales.sSerial;
            oModulo.IdEstacionamiento = Convert.ToInt64(Globales.iCodigoEstacionamiento);

            bool ok = false;
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = Model.ObtenerInfoModulo(oModulo);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.DtoModulo = (DtoModulo)oResultadoOperacion.EntidadDatos;
                View.General_Events = "(Presenter ObtenerInfoModulo) OK";
                ok = true;
            }
            else if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                View.General_Events = "(Presenter ObtenerInfoModulo) Sistema Suspendido - Info Modulo Error";
            }

            return ok;
        }
        public bool ObtenerPartes()
        {
            Modulo oModulo = new Modulo();
            oModulo.IdModulo = Globales.sSerial;
            oModulo.IdEstacionamiento = View.DtoModulo.IdEstacionamiento;

            bool ok = false;
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            View.DtoModulo.Partes.Clear();
            oResultadoOperacion = Model.ObtenerPartesModulo(oModulo);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.DtoModulo.Partes = (List<DtoParteModulo>)oResultadoOperacion.ListaEntidadDatos;

                View.General_Events = "(Presenter ObtenerInfoPartes) OK";
                ok = true;
            }
            else if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                View.General_Events = "(Presenter ObtenerInfoPartes) Sistema Suspendido - Info Partes Error";
                ok = false;
            }

            return ok;
        }
        public bool ObtenerParametros()
        {
            long IdEstacionamiento = View.DtoModulo.IdEstacionamiento;

            bool ok = false;
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            View.DtoModulo.Parametros.Clear();
            oResultadoOperacion = Model.ObtenerParametrosModulo(IdEstacionamiento);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.DtoModulo.Parametros = (List<DtoParametros>)oResultadoOperacion.ListaEntidadDatos;

                View.General_Events = "(Presenter ObtenerInfoParametros) OK";
                ok = true;
            }
            else if (oResultadoOperacion.oEstado == TipoRespuesta.Error)
            {
                View.General_Events = "(Presenter ObtenerInfoParametros) Sistema Suspendido - Info Parametros Error";
            }

            return ok;
        }
        public bool RegistrarSalida(Transaccion oTransaccion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            bool ok = false;
            oResultadoOperacion = Model.RegistrarMovimiento(oTransaccion);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                ok = true;
            }

            return true;
        }
        public bool RegistrarAlarma(string Descripcion, int NivelError, string Parte, string TipoError)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            Alarma oAlarma = new Alarma();

            oAlarma.Descripcion = Descripcion;
            oAlarma.IdEstacionamiento = Convert.ToInt64(Globales.iCodigoEstacionamiento);
            oAlarma.IdModulo = Globales.sSerial;
            oAlarma.NivelError = NivelError;
            oAlarma.Parte = Parte;
            oAlarma.TipoError = TipoError;

            bool ok = false;
            oResultadoOperacion = Model.RegistrarAlarma(oAlarma);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                ok = true;
            }

            return true;
        }
        public void SolucionarTodasAlarmas()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            Modulo oModulo = new Modulo();
            oModulo.IdModulo = Globales.sSerial;
            oModulo.IdEstacionamiento = Convert.ToInt64(Globales.iCodigoEstacionamiento);

            oResultadoOperacion = Model.SolucionarTodasAlarmas(oModulo);
        }
        public bool ObtenerAutorizado(Autorizado oAutorizado)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            bool ok = false;
            oResultadoOperacion = Model.ObtenerAutorizado(oAutorizado);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.lstDtoAutorizado = (List<DtoAutorizado>)oResultadoOperacion.ListaEntidadDatos;
                ok = true;
            }

            return ok;
        }
        public string ObtenerValorParametro(Parametros idParametro)
        {
            string ValorParametro = string.Empty;
            foreach (DtoParametros item in View.DtoModulo.Parametros)
            {
                if (item.Codigo == idParametro.ToString())
                {
                    ValorParametro = item.Valor;
                    break;
                }
            }
            return ValorParametro;
        }
        public bool ObtenerTarjetas()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            Modulo oModulo = new Modulo();
            oModulo.IdEstacionamiento = Convert.ToInt64(Globales.iCodigoEstacionamiento);

            bool ok = false;
            oResultadoOperacion = Model.ObtenerTarjetas(oModulo);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.lstDtoTarjetas = (List<DtoTarjetas>)oResultadoOperacion.ListaEntidadDatos;
                ok = true;
            }

            return ok;
        }
        public bool ObtenerEvento(long Secuencia)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            bool ok = false;
            oResultadoOperacion = Model.ObtenerEvento(Secuencia);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.Horas = oResultadoOperacion.EntidadDatos.ToString();
                ok = true;
            }
            else 
            {
                View.General_Events = "ERROR Presenter ObtenerEvento";
            }

            return ok;
        }

        #endregion

        #region Device

        public bool TestConexionDispositivos()
        {
            bool ok = false;
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oKYTsDevice.TestConexionReceptor();

            if (View.KytReady)
            {

                oResultadoOperacion = PLCDeviceClass.EstadoConexion(Globales.sPuertoPLC);

                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    if (View.Presentacion == Pantalla.SistemaSuspendido)
                    {
                        View.Presentacion = Pantalla.SalvaPantallas;
                    }
                    ok = true;
                }
                else
                {
                    View.Presentacion = Pantalla.SistemaSuspendido;
                    Descripcion = "PLC no conectado";
                    NivelError = 1;
                    Parte = "PLC";
                    TipoError = "Error_Conexion_PLC";

                    RegistrarAlarma(Descripcion, NivelError, Parte, TipoError);
                    View.General_Events = "Error Conexion PLC";
                }
            }
            else
            {
                View.Presentacion = Pantalla.SistemaSuspendido;
            }

            return ok;
        }
        public bool TestConexionSuspendidoDispositivos()
        {
            bool ok = false;
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oKYTsDevice.ConectarDeviceReceptor(Globales.sPuerto, ObtenerValorParametro(Parametros.claveTarjeta).ToString());

            if (View.KytReady)
            {

                oResultadoOperacion = PLCDeviceClass.EstadoConexion(Globales.sPuertoPLC);

                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    if (View.Presentacion == Pantalla.SistemaSuspendido)
                    {
                        View.Presentacion = Pantalla.SalvaPantallas;
                    }
                    ok = true;
                }
                else
                {
                    View.Presentacion = Pantalla.SistemaSuspendido;
                    Descripcion = "PLC no conectado";
                    NivelError = 1;
                    Parte = "PLC";
                    TipoError = "Error_Conexion_PLC";

                    RegistrarAlarma(Descripcion, NivelError, Parte, TipoError);
                    View.General_Events = "Error Conexion PLC";
                }
            }
            else
            {
                View.Presentacion = Pantalla.SistemaSuspendido;
            }

            return ok;
        }

        #region PLC
        void oPLCDevice_DeviceMessage(object sender, EventArgs e)
        {
            var i = (EventArgsPLCDevice)e;

            if (i.result.oEstado == TipoRespuesta.Exito)
            {
                if (Convert.ToBoolean(i.result.EntidadDatos) == false)
                {
                    //RegistrarAlarma(TipoAlarma.ErrorPLC, TipoParte.PLC.ToString(), "Error conexion PLC");
                }
                else
                {
                    //SolucionarAlarma(TipoAlarma.ErrorPLC, TipoParte.PLC, "Error conexion PLC");
                }
            }
        }
        public bool ConexionPLC()
        {
            bool ok = false;
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = PLCDeviceClass.Conectar(Globales.sPuertoPLC);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                ok = true;
                View.General_Events = "(PRESENTER) Conexion Exitosa PLC";
            }
            else
            {
                View.General_Events = oResultadoOperacion.Mensaje;
            }

            return ok;
        }
        public bool LimpiarValoresPLC()
        {
            bool ok = false;

            try
            {
                ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

                oResultadoOperacion = PLCDeviceClass.BorraEstadoLlegoCarroBarrera(Globales.sPuertoPLC);

                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    oResultadoOperacion = PLCDeviceClass.BorraEstadoSefueCarroBarrera(Globales.sPuertoPLC);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        ok = true;
                        View.General_Events = "(PRESENTER) Borrado Exitoso Variables PLC";
                    }
                    else
                    {
                        View.General_Events = "(PRESENTER) Error Borrado Varibales PLC";
                    }
                }
                else
                {
                    View.General_Events = "(PRESENTER) Error Borrado Varibales PLC";
                }
            }
            catch (Exception)
            {
                View.General_Events = "Error Conexion PLC";
                View.Presentacion = Pantalla.SistemaSuspendido;
            }
            return ok;
        }
        public bool EstadoConexionPLC()
        {
            bool ok = false;
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = PLCDeviceClass.EstadoConexion(Globales.sPuertoPLC);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                if (View.Presentacion == Pantalla.SistemaSuspendido)
                {
                    View.Presentacion = Pantalla.SalvaPantallas;
                }
                ok = true;
            }
            else
            {
                View.Presentacion = Pantalla.SistemaSuspendido;
                Descripcion = "PLC no conectado";
                NivelError = 1;
                Parte = "PLC";
                TipoError = "Error_Conexion_PLC";

                RegistrarAlarma(Descripcion, NivelError, Parte, TipoError);
                View.General_Events = "Error Conexion PLC";
            }

            return ok;
        }
        public bool VehiculoMueble()
        {
            bool ok = false;
            try
            {

                ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

                oResultadoOperacion = PLCDeviceClass.CarroMueble(Globales.sPuertoPLC);

                if (Convert.ToBoolean(oResultadoOperacion.ListaEntidadDatos[0]) == true)
                {

                    ok = true;
                    View.General_Events = "Vehiculo En Mueble";
                }
            }
            catch (Exception)
            {
                View.General_Events = "Error Conexion PLC";
                View.Presentacion = Pantalla.SistemaSuspendido;
            }

            return ok;
        }
        public bool VehiculoTalanquera()
        {
            bool ok = false;
            try
            {
                ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

                oResultadoOperacion = PLCDeviceClass.CarroenBarrera(Globales.sPuertoPLC);

                if (Convert.ToBoolean(oResultadoOperacion.ListaEntidadDatos[0]) == true)
                {
                    ok = true;
                    View.General_Events = "Vehiculo En Talanquera";
                }
            }
            catch (Exception)
            {
                View.General_Events = "Error Conexion PLC";
                View.Presentacion = Pantalla.SistemaSuspendido;
            }

            return ok;
        }
        public bool VehiculoSalioTalanquera()
        {
            bool ok = false;

            try
            {
                ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

                oResultadoOperacion = PLCDeviceClass.CarroSeFueBarrera(Globales.sPuertoPLC);

                if (Convert.ToBoolean(oResultadoOperacion.ListaEntidadDatos[0]) == true)
                {
                    ok = true;
                    View.General_Events = "Vehiculo Salio Talanquera";
                }
            }
            catch (Exception)
            {
                View.General_Events = "Error Conexion PLC";
                View.Presentacion = Pantalla.SistemaSuspendido;
            }
            return ok;
        }
        public bool AbrirTalanquera()
        {
            bool ok = false;
            try
            {
                ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

                oResultadoOperacion = PLCDeviceClass.AbrirTalanquera(Globales.sPuertoPLC);

                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    ok = true;
                    View.General_Events = "Talanquera Abierta";
                }
            }
            catch (Exception)
            {
                View.General_Events = "Error Conexion PLC";
                View.Presentacion = Pantalla.SistemaSuspendido;
            }
            return ok;
        }
        #endregion

        #region KytReceptor

        #region Funciones
        public void ConectarReceptor()
        {
            oKYTsDevice.ConectarDeviceReceptor(Globales.sPuerto, ObtenerValorParametro(Parametros.claveTarjeta).ToString());
        }
        public void DetectarTarjeta()
        {
            oKYTsDevice.DetectarTarjeta();
        }
        public void DispensarTarjeta()
        {
            oKYTsDevice.DispensarTarjetaReceptor();
        }
        public void CapturarTarjeta()
        {
            oKYTsDevice.CleanCardReceptor();
            oKYTsDevice.CapturarTarjeta();
        }
        public void LeerTarjeta()
        {
            oKYTsDevice.ReadCardReceptor();
        }
        #endregion

        #region Eventos
        void oKYTsDevice_DeviceMessage(object sender, EventArgs e)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            var i = (EventArgsKytDevice)e;

            switch (i.result)
            {

                #region Default
                default:
                    break;
                #endregion

                #region Error_Conexion_Receptor
                case StatesKYT.Error_Conexion_Receptor:
                    View.KytReady = false;
                    View.General_Events = i.result.ToString();
                    oResultadoOperacion = i.resultString;
                    View.General_Events = oResultadoOperacion.Mensaje;

                    Descripcion = "Receptor no conectado";
                    NivelError = 1;
                    Parte = "kyt_Receptor";
                    TipoError = "Error_Conexion_Receptor";

                    RegistrarAlarma(Descripcion, NivelError, Parte, TipoError);

                    break;
                #endregion

                #region Conexion_Exitosa_Receptor
                case StatesKYT.Conexion_Exitosa_Receptor:
                    View.KytReady = true;
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region TestReceptor_OK
                case StatesKYT.TestReceptor_OK:
                    //View.General_Events = i.result.ToString();
                    View.KytReady = true;
                    if (View.Presentacion == Pantalla.SistemaSuspendido)
                    {
                        View.Presentacion = Pantalla.SalvaPantallas;
                    }

                    break;
                #endregion

                #region TestReceptor_ERROR
                case StatesKYT.TestReceptor_ERROR:
                    View.KytReady = false;
                    //View.Presentacion = Pantalla.SistemaSuspendido;
                    View.General_Events = i.result.ToString();

                    Descripcion = "Error en el Test del Receptor";
                    NivelError = 1;
                    Parte = "kyt_Receptor";
                    TipoError = "Error_Conexion_Receptor";

                    RegistrarAlarma(Descripcion, NivelError, Parte, TipoError);

                    break;
                #endregion

                #region DetectarTarjeta
                case StatesKYT.Tarjeta_MovidaReceptor_FRONT_TO_RF:
                    oResultadoOperacion = i.resultString;
                    View.General_Events = oResultadoOperacion.Mensaje;
                    View.CardKytReceptorReady = true;
                    break;
                #endregion

                #region Error_DetectarTarjeta
                case StatesKYT.Error_MoverTarjetaReceptor_FRONT_TO_RF:
                    View.CardKytReceptorReady = false;
                    oResultadoOperacion = i.resultString;
                    View.General_Events = oResultadoOperacion.Mensaje;                    
                    break;
                #endregion

                #region Tarjeta_Leida
                case StatesKYT.Tarjeta_Leida:
                    View.General_Events = i.result.ToString();
                    oResultadoOperacion = i.resultString;
                    View.Tarjeta = (Tarjeta)oResultadoOperacion.EntidadDatos;
                    View.General_Events = "DATOS TARJETA";
                    View.CardReadKytReceptorReady = true;
                    break;
                #endregion

                #region Error_Leer_Tarjeta,
                case StatesKYT.Error_Leer_Tarjeta:
                    oResultadoOperacion = i.resultString;
                    View.General_Events = oResultadoOperacion.Mensaje;
                    break;
                #endregion

                #region CapturarTarjeta
                case StatesKYT.Tarjeta_MovidaReceptor_TO_BINBOX:
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region Error_CapturarTarjeta
                case StatesKYT.Error_MoverTarjetaReceptor_TO_BINBOX:
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region TarjetaBorrada
                case StatesKYT.Tarjeta_Borrada_Receptor:
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region ErrorTarjetaBorrada
                case StatesKYT.Error_Borrar_TarjetaReceptor:
                    View.General_Events = i.result.ToString();
                    break;
                #endregion
            }

        }
        #endregion

        #endregion

        #region CRT

        #region Funciones
        public void ConectarCRT()
        {
            oCRTDevice.ConectarCRT();
        }
        public void GetIdCard()
        {
            oCRTDevice.GetIdCardCRT();
        }
        public void LoadKeyCard()
        {
            oCRTDevice.LoadKeyCRT("");
        }
        public void CheckKeyCard()
        {
            oCRTDevice.CheckKeyCRT();
        }
        public void WriteCard(Tarjeta oTarjeta)
        {
            oCRTDevice.LoadKeyCRT(ObtenerValorParametro(Parametros.ClaveTarjetasCRT).ToString());
            if (LoadKey)
            {
                oCRTDevice.CheckKeyCRT();

                if (CheckKey)
                {
                    oCRTDevice.WriteCardCRTExit(oTarjeta);
                }
            }

        }
        public void ReadCard()
        {
            oCRTDevice.LoadKeyCRT(ObtenerValorParametro(Parametros.ClaveTarjetasCRT).ToString());
            if (LoadKey)
            {
                oCRTDevice.CheckKeyCRT();

                if (CheckKey)
                {
                    oCRTDevice.ReadCardCRT();
                }
            }

        }
        #endregion

        #region Eventos
        void oCRTDevice_DeviceMessage(object sender, EventArgs e)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            var i = (EventArgsCrtDevice)e;

            switch (i.result)
            {
                #region Error_Conexion
                case StatesCRT.Error_Conexion_CRT:
                    View.CRTReady = false;
                    oResultadoOperacion = i.resultString;
                    View.General_Events = oResultadoOperacion.Mensaje;

                    Descripcion = "Lector Autorizados no conectado";
                    NivelError = 1;
                    Parte = "CRT_603";
                    TipoError = "Error_Conexion_CRT";

                    RegistrarAlarma(Descripcion, NivelError, Parte, TipoError);

                    break;
                #endregion

                #region Conexion_Exitosa
                case StatesCRT.Conexion_Exitosa_CRT:
                    View.CRTReady = true;
                    oResultadoOperacion = i.resultString;
                    View.General_Events = oResultadoOperacion.Mensaje;
                    break;
                #endregion

                #region Sin_Tarjeta
                case StatesCRT.Sin_Tarjeta:
                    //View.RemoveCard = true;
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region IdCardCRT_OK
                case StatesCRT.IdCardCRT_OK:
                    oResultadoOperacion = i.resultString;
                    View.General_Events = oResultadoOperacion.Mensaje;
                    View.IdCardAutorizado = oResultadoOperacion.EntidadDatos.ToString();
                    break;
                #endregion

                #region Error_GetId
                case StatesCRT.Error_GetId:
                    oResultadoOperacion = i.resultString;
                    View.General_Events = oResultadoOperacion.Mensaje;
                    break;
                #endregion

                #region LoadKeyCRT_ok
                case StatesCRT.LoadKeyCRT_ok:
                    LoadKey = true;
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region Error_LoadKeyCRT
                case StatesCRT.Error_LoadKeyCRT:
                    LoadKey = false;
                    View.General_Events = i.result.ToString();

                    //ACERQUE LÑA TARJETA DE AUTO OTRAVEZ 
                    //View.Presentacion = Pantalla

                    break;
                #endregion

                #region CheckKeyCRT_ok
                case StatesCRT.CheckKeyCRT_ok:
                    CheckKey = true;
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region Error_CheckKeyCRT
                case StatesCRT.Error_CheckKeyCRT:
                    CheckKey = false;
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region WriteCard_ok
                case StatesCRT.WriteCard_ok:
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region Error_WriteCard
                case StatesCRT.Error_WriteCard:
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region ReadCard_ok
                case StatesCRT.ReadCard_ok:
                    oResultadoOperacion = i.resultString;
                    View.General_Events = oResultadoOperacion.Mensaje;
                    View.Tarjeta = (Tarjeta)oResultadoOperacion.EntidadDatos;
                    break;
                #endregion

                #region Error_ReadCard
                case StatesCRT.Error_ReadCard:
                    View.General_Events = i.result.ToString();
                    break;
                #endregion

                #region Default
                default:
                    break;
                #endregion
            }

        }
        #endregion


        #endregion

        #region Camara
        public void CapturaFoto(string Orden, string SecuenciaTransaccion)
        {
            for (int i = 0; i < View.DtoModulo.Partes.Count; i++)
            {

                string sFileName = string.Empty;

                sFileName = @"C:\FOTOS\";

                if (!Directory.Exists(sFileName))
                {
                    Directory.CreateDirectory(sFileName);
                }


                if (View.DtoModulo.Partes[i].TipoParte == "CAMARA" && View.DtoModulo.Partes[i].Estado)
                {
                    sFileName = sFileName + SecuenciaTransaccion + "_" + Globales.sSerial + "_" + View.DtoModulo.Partes[i].NombreParte + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + Orden + ".jpg";

                    //string sUrl = "http://" + ObtenerValorParametro(Parametros.IPCamara) + "/cgi-bin/media.cgi?action=getSnapshot";
                    string User = ObtenerValorParametro(Parametros.UsuarioCamaras).ToString();
                    string Pass = ObtenerValorParametro(Parametros.PasswordCamaras).ToString();


                    string sUrl = "http://" + View.DtoModulo.Partes[i].IPDispositivo + "/Streaming/channels/101/picture";
                    if (Generales.WebSiteIsAvailable(sUrl, User,Pass))
                    {
                        WebClient webClient = new WebClient();

                        webClient.Credentials = new NetworkCredential(User, Pass);
                        try
                        {
                            webClient.DownloadFile(sUrl, sFileName);
                        }
                        catch (Exception e)
                        {
                            View.General_Events = "(Presenter CapturaFoto) Exception: "+ View.DtoModulo.Partes[i].NombreParte + " " + e.InnerException + " " + e.Message + " " + e.Source;
                        }
                    }
                    else
                    {
                        View.General_Events = "(Presenter CapturaFoto) Error: ALARMA CAMARA IP" + View.DtoModulo.Partes[i].NombreParte;
                    } 
                }
            }            
        }
        #endregion

        #endregion

        #region Service
        public bool EnvioImagenes(List<Imagen> olstImagenes, Transaccion oTransaccion)
        {
            bool ok = false;

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = Model.EnviarImagenesServidor(olstImagenes, oTransaccion);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.General_Events = "(Presenter EnviarImagenesServidor) " + oResultadoOperacion.Mensaje;
                ok = true;
            }
            else
            {
                View.General_Events = "Error (Presenter EnviarImagenesServidor): " + oResultadoOperacion.Mensaje;

                ok = false;
            }

            return ok;
        }
        public bool Liquidar(string sSecuencia, int iTipoVehiculo, bool bMensualidad, bool bReposicion,string Convenios)
        {
            bool ok = false;

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = Model.Liquidacion(sSecuencia, iTipoVehiculo, bMensualidad, bReposicion,Convenios);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.General_Events = "(Presenter Liquidacion) " + oResultadoOperacion.Mensaje;
                View.ValorAPagar = oResultadoOperacion.EntidadDatos.ToString();
                //View.lstDtoLiquidacion = (List<DtoDatosLiquidacion>)oResultadoOperacion.ListaEntidadDatos;
                ok = true;
            }
            else
            {
                View.General_Events = "Error (Presenter Liquidacion): " + oResultadoOperacion.Mensaje;

                ok = false;
            }

            return ok;
        }
        public bool ValidarSalidaAuto(string IDCARD)
        {
            bool ok = false;

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = Model.ValidarSalidaAuto(IDCARD);
            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                if (Convert.ToBoolean(oResultadoOperacion.EntidadDatos) == true)
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                }
            }
            else
            {
                View.General_Events = "Error (Presenter EnviarImagenesServidor): " + oResultadoOperacion.Mensaje;

                ok = true;
            }

            return ok;
        }
        #endregion

        #region Barrera
        public bool ObtenerEventoDispo()
        {
            bool ok = false;
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = Model.ObtenerEventoDispo();

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.Barrera = (string)oResultadoOperacion.EntidadDatos;
                View.General_Events = "(Presenter ObtenerEventoDispo) OK";
                ok = true;
            }

            return ok;
        }
        public bool ActualizarEventoDispo(long IdEvento)
        {
            bool ok = false;
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            oResultadoOperacion = Model.ActualizarEventoDispositivo(IdEvento);

            if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
            {
                View.General_Events = "(Presenter ActualizarEventoDispositivo) OK";
                ok = true;
            }

            return ok;
        }
        #endregion

    }
}
