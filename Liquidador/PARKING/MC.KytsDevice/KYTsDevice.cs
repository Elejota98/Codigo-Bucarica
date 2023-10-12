using EGlobalT.Device.SmartCard;
using EGlobalT.Device.SmartCardDispensers;
using EGlobalT.Device.SmartCardDispensers.Entities;
using EGlobalT.Device.SmartCardDispensers.Enums;
using EGlobalT.Device.SmartCardFeeders;
using EGlobalT.Device.SmartCardFeeders.Entities;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.KytsDevice
{
    public class KYTsDeviceClass
    {
        #region Definiciones
        public EventHandler DeviceMessageKytState;

        #region Dispenser
        Dispenser_KYT_CHM1800SERIES Device = new Dispenser_KYT_CHM1800SERIES();
        Rspsta_Conexion_DISPENSER RespDispenser = new Rspsta_Conexion_DISPENSER();
        Rspsta_AlistarTarjeta_DISPENSER RespAlistarDispenser = new Rspsta_AlistarTarjeta_DISPENSER();
        Rspsta_MoverTarjeta_DISPENSER RespMove = new Rspsta_MoverTarjeta_DISPENSER();
        Rspsta_BorrarTarjeta_DISPENSER RespCleanCard = new Rspsta_BorrarTarjeta_DISPENSER();
        Rspsta_TestConexion_DISPENSER RespTestConexion = new Rspsta_TestConexion_DISPENSER();
        Rspsta_PosicionTarjeta_DISPENSER RespPosicion = new Rspsta_PosicionTarjeta_DISPENSER();
        Rspsta_Escribir_Tarjeta_DISPENSER ResEscribir = new Rspsta_Escribir_Tarjeta_DISPENSER();
        Rspsta_EstadoStacker_DISPENSER ResEstStacker = new Rspsta_EstadoStacker_DISPENSER();
        Rspsta_EstablecerClave_DISPENSER ResEstaClave = new Rspsta_EstablecerClave_DISPENSER();
        #endregion

        #region Receptor
        Feeder_KYT1000SERIES DeviceReceptor = new Feeder_KYT1000SERIES();
        Rspsta_MoverTarjeta_FEEDER RespMoveReceptor = new Rspsta_MoverTarjeta_FEEDER();
        Rspsta_Conexion_FEEDER RespReceptor = new Rspsta_Conexion_FEEDER();
        Rspsta_TestConexion_FEEDER RespTestConexionReceptor = new Rspsta_TestConexion_FEEDER();
        Rspsta_PosicionTarjeta_FEEDER RespPosicionReceptor = new Rspsta_PosicionTarjeta_FEEDER();
        Rspsta_Leer_Tarjeta_FEEDER ResLeerReceptor = new Rspsta_Leer_Tarjeta_FEEDER();
        Rspsta_Escribir_Tarjeta_FEEDER ResEscribirReceptor = new Rspsta_Escribir_Tarjeta_FEEDER();
        Rspsta_BorrarTarjeta_FEEDER RespCleanCardReceptor = new Rspsta_BorrarTarjeta_FEEDER();
        Rspsta_EstablecerClave_FEEDER ResEstaClaveFee = new Rspsta_EstablecerClave_FEEDER();
        Rspsta_EstablecerClave_FEEDER ResClave = new Rspsta_EstablecerClave_FEEDER();
        Rspsta_LecturaTarjeta_SectorBloque_FEEDER RspLect = new Rspsta_LecturaTarjeta_SectorBloque_FEEDER();
        ITarjeta oITarjeta;
        SMARTCARD_PARKING_V1 oTarjeta = new SMARTCARD_PARKING_V1();
        #endregion

        StatesKYT _StatesKYT = new StatesKYT();
        #endregion

        #region Funciones

        #region Funciones Entrada
        public ResultadoOperacion ConectarDevice(string sPuerto, string Clave)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                RespDispenser = Device.Conectar(sPuerto, 8, 0, 0, 38400, 0);

                if (RespDispenser.Conectado)
                {

                    ResEstaClave = Device.EstablecerClave(Clave);

                    if (ResEstaClave.ClaveEstablecida)
                    {

                        _StatesKYT = StatesKYT.Conexion_Exitosa_Dispensador;
                        oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                        oResultadoOperacion.Mensaje = "Conexion Exitosa Dispensador" + " " + RespDispenser.Conectado;
                    }
                    else
                    {
                        _StatesKYT = StatesKYT.Error_Conexion_Dispensador;
                        oResultadoOperacion.oEstado = TipoRespuesta.Error;
                        oResultadoOperacion.Mensaje = ResEstaClave.ErrorDISPENSER + " " + ResEstaClave.Des_ErrorDISPENSER;
                    }
                }
                else
                {
                    _StatesKYT = StatesKYT.Error_Conexion_Dispensador;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespDispenser.ErrorDISPENSER + " " + RespDispenser.Des_ErrorDISPENSER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }


            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);
            
            return oResultadoOperacion;

        }        
        public ResultadoOperacion AlistarTarjeta()
        {

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {

                RespAlistarDispenser = Device.AlistarTarjeta(EGlobalT.Device.SmartCard.TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1, 25, true);
                
                if (RespAlistarDispenser.TarjetaAlistada)
                {
                    _StatesKYT = StatesKYT.Tarjeta_Alistada;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Tarjeta alistada correctamente" + " ID: " + RespAlistarDispenser.CodigoTarjeta;
                    oResultadoOperacion.EntidadDatos = RespAlistarDispenser.CodigoTarjeta;
                    //oResultadoOperacion.EntidadDatos = "fgfgh";

                }
                else
                {
                    _StatesKYT = StatesKYT.Error_AlistarTarjeta;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespAlistarDispenser.ErrorDISPENSER + " " + RespAlistarDispenser.Des_ErrorDISPENSER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT,oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;
        }
        public ResultadoOperacion BorrarTarjeta()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {

                RespCleanCard = Device.BorrarTarjeta(EGlobalT.Device.SmartCard.TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1);
                if (RespCleanCard.TarjetaBorrada)
                {
                    _StatesKYT = StatesKYT.Tarjeta_Borrada;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Tarjeta borrada correctamente" + " ID: " + RespCleanCard.CodigoTarjeta;
                    oResultadoOperacion.EntidadDatos = RespCleanCard.CodigoTarjeta;

                }
                else
                {
                    _StatesKYT = StatesKYT.Error_Borrar_Tarjeta;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespCleanCard.ErrorDISPENSER + " " + RespCleanCard.Des_ErrorDISPENSER;
                    oResultadoOperacion.EntidadDatos = RespCleanCard.CodigoTarjeta;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.EntidadDatos = RespCleanCard.CodigoTarjeta;
            }

            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;
        }
        public ResultadoOperacion DispensarTarjeta()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {

                RespMove = Device.MoverTarjeta(MOVEMENT_CARD_DISPENSER.RF_TO_FRONT);
                if (RespMove.TarjetaMovida)
                {
                    _StatesKYT = StatesKYT.Tarjeta_Movida_FRONT_TO_RF;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Tarjeta Movida correctamente" + " ID: " + RespMove.MovimientoTarjeta;

                }
                else
                {
                    _StatesKYT = StatesKYT.Error_MoverTarjeta_FRONT_TO_RF;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespMove.ErrorDISPENSER + " " + RespMove.Des_ErrorDISPENSER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;
        }
        public ResultadoOperacion DevolverTarjeta()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {

                RespMove = Device.MoverTarjeta(MOVEMENT_CARD_DISPENSER.FRONT_TO_RF);
                if (RespMove.TarjetaMovida)
                {
                    _StatesKYT = StatesKYT.Tarjeta_Movida_FRONT_TO_RF;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Tarjeta Movida correctamente" + " ID: " + RespMove.MovimientoTarjeta;

                }
                else
                {
                    _StatesKYT = StatesKYT.Error_MoverTarjeta_FRONT_TO_RF;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespMove.ErrorDISPENSER + " " + RespMove.Des_ErrorDISPENSER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;
        }
        public ResultadoOperacion TestConexionDispenser()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {

                RespTestConexion = Device.TestConexion();
                if (RespTestConexion.DISPENSERConectado)
                {
                    _StatesKYT = StatesKYT.Estado_Dispensador_OK;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Dispensador Conectado";

                }
                else
                {
                    _StatesKYT = StatesKYT.TestDispensador_ERROR;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespTestConexion.ErrorDISPENSER + " " + RespTestConexion.Des_ErrorDISPENSER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;
        }
        public ResultadoOperacion PosicionCard()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {

                RespPosicion = Device.ObtienePosicionTarjeta();


                if (RespPosicion.PosicionTarjeta == POSITION_CARD_DISPENSER.WITHOUT_CARD)
                {
                    _StatesKYT = StatesKYT.Sin_Tarjeta;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    
                }
                else if (RespPosicion.PosicionTarjeta == POSITION_CARD_DISPENSER.ERR_SENSORS)
                {
                    _StatesKYT = StatesKYT.Error_Sensores;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else if (RespPosicion.PosicionTarjeta == POSITION_CARD_DISPENSER.FRONT)
                {
                    _StatesKYT = StatesKYT.Tarjeta_En_Boca;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else if (RespPosicion.PosicionTarjeta == POSITION_CARD_DISPENSER.RF)
                {
                    _StatesKYT = StatesKYT.Tarjeta_En_RF;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else if (RespPosicion.PosicionTarjeta == POSITION_CARD_DISPENSER.STACKER_RF)
                {
                    _StatesKYT = StatesKYT.Tarjeta_Stacker_RF;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else if (RespPosicion.PosicionTarjeta == POSITION_CARD_DISPENSER.UNKNOWN)
                {
                    _StatesKYT = StatesKYT.Posicion_Desconocida;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;
        }
        public ResultadoOperacion EscribirTarjeta(Tarjeta oTarjeta,bool moto)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            SMARTCARD_PARKING_V1 tt = new SMARTCARD_PARKING_V1();

            try
            {

                tt.ActiveCycle = oTarjeta.ActiveCycle;
                tt.DateTimeEntrance = oTarjeta.DateTimeEntrance;
                tt.EntranceModule = oTarjeta.EntranceModule;
                tt.EntrancePlate = oTarjeta.EntrancePlate;

                tt.TypeCard = TYPE_TARJETAPARKING_V1.VISITOR;
                if (moto)
                {
                    tt.TypeVehicle = TYPEVEHICLE_TARJETAPARKING_V1.MOTORCYCLE;
                }
                else
                {
                    tt.TypeVehicle = TYPEVEHICLE_TARJETAPARKING_V1.AUTOMOBILE;
                }

                ResEscribir = Device.EscribirTarjeta(tt, true);
                if (ResEscribir.TarjetaEscrita)
                {
                    _StatesKYT = StatesKYT.Tarjeta_Escrita;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Tarjeta escrita correctamente" + " ID: " + ResEscribir.CodigoTarjeta;

                }
                else
                {
                    _StatesKYT = StatesKYT.Error_Escribir_Tarjeta;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = ResEscribir.ErrorDISPENSER + " " + ResEscribir.Des_ErrorDISPENSER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;
        }
        public ResultadoOperacion DesecharTarjeta()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {

                RespMove = Device.MoverTarjeta(MOVEMENT_CARD_DISPENSER.TO_BINBOX);
                if (RespMove.TarjetaMovida)
                {
                    _StatesKYT = StatesKYT.Tarjeta_Movida_TOBINBOX;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Tarjeta Movida correctamente" + " ID: " + RespMove.Des_MovimientoTarjeta;

                }
                else
                {
                    _StatesKYT = StatesKYT.Error_MoverTarjetaTO_BINBOX;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespMove.ErrorDISPENSER + " " + RespMove.Des_ErrorDISPENSER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;
        }
        public ResultadoOperacion EstadoStacker()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {

                ResEstStacker = Device.ObtieneEstadoStacker();
                if (ResEstStacker.EstadoStacker == STATE_STACKER_DISPENSER.STACKER_GOOD)
                {
                    _StatesKYT = StatesKYT.Estado_StackerGood;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = ResEstStacker.Des_EstadoStacker;

                }
                else if (ResEstStacker.EstadoStacker == STATE_STACKER_DISPENSER.CARD_WARNING)
                {
                    _StatesKYT = StatesKYT.Estado_StackerNivelBajo;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = ResEstStacker.Des_EstadoStacker;
                }
                else if (ResEstStacker.EstadoStacker == STATE_STACKER_DISPENSER.STACKER_EMPTY)
                {
                    _StatesKYT = StatesKYT.Estado_StackerSinTarjetas;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = ResEstStacker.Des_EstadoStacker;
                }
                else if (ResEstStacker.EstadoStacker == STATE_STACKER_DISPENSER.STACKER_ERROR)
                {
                    _StatesKYT = StatesKYT.Error_Estado_Stacker;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = ResEstStacker.Des_EstadoStacker;
                }
                else
                {
                    _StatesKYT = StatesKYT.Error_Estado_Stacker;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = ResEstStacker.Des_EstadoStacker;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;
        }
        #endregion

        #region Funciones Salida
        public ResultadoOperacion ConectarDeviceReceptor(string sPuerto, string Clave)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                RespReceptor = DeviceReceptor.Conectar(sPuerto, true, 8, 0, 0, 38400, 0);

                if (RespReceptor.Conectado)
                {

                    ResEstaClaveFee = DeviceReceptor.EstablecerClave(Clave);

                    if (ResEstaClaveFee.ClaveEstablecida)
                    {
                        _StatesKYT = StatesKYT.Conexion_Exitosa_Receptor;
                        oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                        oResultadoOperacion.Mensaje = "Conexion Exitosa Receptor" + " " + RespReceptor.Conectado;
                    }
                    else 
                    {
                        _StatesKYT = StatesKYT.Error_Conexion_Receptor;
                        oResultadoOperacion.oEstado = TipoRespuesta.Error;
                        oResultadoOperacion.Mensaje = ResEstaClaveFee.ErrorFEEDER + " " + ResEstaClaveFee.Des_ErrorFEEDER;
                    }
                }
                else
                {
                    _StatesKYT = StatesKYT.Error_Conexion_Receptor;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespReceptor.ErrorFEEDER + " " + RespReceptor.Des_ErrorFEEDER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }


            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;

        }
        public ResultadoOperacion DetectarTarjeta()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                RespMoveReceptor = DeviceReceptor.MoverTarjeta(EGlobalT.Device.SmartCardFeeders.Enums.MOVEMENT_CARD_FEEDER.FRONT_TO_RF);

                if (RespMoveReceptor.TarjetaMovida)
                {

                    _StatesKYT = StatesKYT.Tarjeta_MovidaReceptor_FRONT_TO_RF;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Detectar tarjeta Receptor" + " " + RespMoveReceptor.Des_MovimientoTarjeta;
                }
                else
                {
                    _StatesKYT = StatesKYT.Error_MoverTarjetaReceptor_FRONT_TO_RF;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespMoveReceptor.ErrorFEEDER + " " + RespMoveReceptor.Des_ErrorFEEDER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }


            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;

        }
        public ResultadoOperacion DispensarTarjetaReceptor()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                RespMoveReceptor = DeviceReceptor.MoverTarjeta(EGlobalT.Device.SmartCardFeeders.Enums.MOVEMENT_CARD_FEEDER.RF_TO_FRONT);

                if (RespMoveReceptor.TarjetaMovida)
                {

                    _StatesKYT = StatesKYT.Tarjeta_MovidaReceptor_RF_TO_FRONT;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Dispensar Tarjeta Receptor" + " " + RespMoveReceptor.Des_MovimientoTarjeta;
                }
                else
                {
                    _StatesKYT = StatesKYT.Error_MoverTarjetaReceptor_RF_TO_FRONT;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespMoveReceptor.ErrorFEEDER + " " + RespMoveReceptor.Des_ErrorFEEDER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }


            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;

        }
        public ResultadoOperacion CapturarTarjeta()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                RespMoveReceptor = DeviceReceptor.MoverTarjeta(EGlobalT.Device.SmartCardFeeders.Enums.MOVEMENT_CARD_FEEDER.TO_BINBOX);

                if (RespMoveReceptor.TarjetaMovida)
                {

                    _StatesKYT = StatesKYT.Tarjeta_MovidaReceptor_TO_BINBOX;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Capturar tarjeta Receptor" + " " + RespMoveReceptor.Des_MovimientoTarjeta;
                }
                else
                {
                    _StatesKYT = StatesKYT.Error_MoverTarjetaReceptor_TO_BINBOX;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespMoveReceptor.ErrorFEEDER + " " + RespMoveReceptor.Des_ErrorFEEDER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }


            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;

        }
        public ResultadoOperacion DownCard()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                RespMoveReceptor = DeviceReceptor.MoverTarjeta(EGlobalT.Device.SmartCardFeeders.Enums.MOVEMENT_CARD_FEEDER.TO_DOWN);

                if (RespMoveReceptor.TarjetaMovida)
                {

                    _StatesKYT = StatesKYT.Tarjeta_MovidaReceptor_TO_DOWN;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Bajar tarjeta" + " " + RespMoveReceptor.Des_MovimientoTarjeta;
                }
                else
                {
                    _StatesKYT = StatesKYT.Error_MoverTarjetaReceptor_TO_DOWN;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespMoveReceptor.ErrorFEEDER + " " + RespMoveReceptor.Des_ErrorFEEDER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }


            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;

        }
        public ResultadoOperacion TestConexionReceptor()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {

                RespTestConexionReceptor = DeviceReceptor.TestConexion();
                if (RespTestConexionReceptor.FEEDERConectado)
                {
                    _StatesKYT = StatesKYT.TestReceptor_OK;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Receptor Conectado";

                }
                else
                {
                    _StatesKYT = StatesKYT.TestReceptor_ERROR;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespTestConexionReceptor.ErrorFEEDER + " " + RespTestConexionReceptor.Des_ErrorFEEDER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;
        }
        public ResultadoOperacion ReadCardReceptor()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                ResLeerReceptor = DeviceReceptor.LeerTarjeta(TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1);
                ResClave = DeviceReceptor.EstablecerClavexSector(1, "S4NP3D");
                RspLect = DeviceReceptor.LeerTarjetaxSectorBloque(1, 2);

                if (ResLeerReceptor.TarjetaLeida)
                {
                    _StatesKYT = StatesKYT.Tarjeta_Leida;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Leer Tarjeta Receptor" + " " + ResLeerReceptor.Tarjeta;
                    oResultadoOperacion.EntidadDatos = ResLeerReceptor.Tarjeta;
                    oTarjeta = (SMARTCARD_PARKING_V1)oResultadoOperacion.EntidadDatos;

                    Tarjeta iTarjeta = new Tarjeta();

                    iTarjeta.ActiveCycle = oTarjeta.ActiveCycle;
                    //iTarjeta.CodeAgreement1 = RspLect.Datos[3];
                    iTarjeta.CodeAgreement1 = oTarjeta.CodeAgreement1;
                    iTarjeta.CodeAgreement2 = oTarjeta.CodeAgreement2;
                    iTarjeta.CodeAgreement3 = oTarjeta.CodeAgreement3;
                    iTarjeta.CodeAgreement4 = oTarjeta.CodeAgreement4;
                    iTarjeta.CodeCard = oTarjeta.CodeCard;
                    iTarjeta.Courtesy = oTarjeta.Courtesy;
                    iTarjeta.DateTimeEntrance = oTarjeta.DateTimeEntrance;
                    iTarjeta.EntranceModule = oTarjeta.EntranceModule;
                    iTarjeta.EntrancePlate = oTarjeta.EntrancePlate;
                    iTarjeta.PaymentDateTime = oTarjeta.PaymentDateTime;
                    iTarjeta.PaymentModule = oTarjeta.PaymentModule;
                    iTarjeta.Replacement = oTarjeta.Replacement;
                    iTarjeta.SafetyExit = oTarjeta.SafetyExit;
                    iTarjeta.TypeCard = oTarjeta.TypeCard.Value;
                    iTarjeta.TypeVehicle = oTarjeta.TypeVehicle.Value;
                    iTarjeta.ValetParking = oTarjeta.ValetParking;

                    oResultadoOperacion.EntidadDatos = iTarjeta;
                    

                }
                else
                {
                    _StatesKYT = StatesKYT.Error_Leer_Tarjeta;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = ResLeerReceptor.ErrorFEEDER + " " + ResLeerReceptor.Des_ErrorFEEDER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }


            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;

        }
        //public ResultadoOperacion WriteCardReceptor(string sPuerto)
        //{
        //    ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

        //    try
        //    {
        //        RespReceptor = DeviceReceptor.Conectar(sPuerto, true, 8, 0, 0, 38400, 0);

        //        if (RespReceptor.Conectado)
        //        {

        //            _StatesKYT = StatesKYT.Conexion_Exitosa_Receptor;
        //            oResultadoOperacion.oEstado = TipoRespuesta.Exito;
        //            oResultadoOperacion.Mensaje = "Conexion Exitosa Receptor" + " " + RespReceptor.Conectado;
        //        }
        //        else
        //        {
        //            _StatesKYT = StatesKYT.Error_Conexion_Receptor;
        //            oResultadoOperacion.oEstado = TipoRespuesta.Error;
        //            oResultadoOperacion.Mensaje = RespReceptor.ErrorFEEDER + " " + RespReceptor.Des_ErrorFEEDER;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        oResultadoOperacion.oEstado = TipoRespuesta.Error;
        //        oResultadoOperacion.Mensaje = ex.ToString();
        //    }


        //    EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
        //    DeviceMessageKytState(this, e);

        //    return oResultadoOperacion;

        //}
        public ResultadoOperacion CleanCardReceptor()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                RespCleanCardReceptor = DeviceReceptor.BorrarTarjeta(TYPE_STRUCTURE_SMARTCARD.SMARTCARD_PARKING_V1, true);

                if (RespCleanCardReceptor.TarjetaBorrada)
                {

                    _StatesKYT = StatesKYT.Tarjeta_Borrada_Receptor;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Conexion Exitosa Receptor" + " " + RespCleanCardReceptor.CodigoTarjeta;
                }
                else
                {
                    _StatesKYT = StatesKYT.Error_Borrar_TarjetaReceptor;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = RespCleanCardReceptor.ErrorFEEDER + " " + RespCleanCardReceptor.Des_ErrorFEEDER;
                }

            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }


            EventArgsKytDevice e = new EventArgsKytDevice(_StatesKYT, oResultadoOperacion);
            DeviceMessageKytState(this, e);

            return oResultadoOperacion;

        }        
        #endregion

        #endregion
    }

    public class EventArgsKytDevice : EventArgs
    {
        private StatesKYT _result;

        public StatesKYT result
        {
            get { return _result; }
            set { _result = value; }
        }

        private ResultadoOperacion _resultString;

        public ResultadoOperacion resultString
        {
            get { return _resultString; }
            set { _resultString = value; }
        }

        public EventArgsKytDevice(StatesKYT oStatesKYT, ResultadoOperacion oResultadoOperacion)
        {
            _result = oStatesKYT;
            _resultString = oResultadoOperacion;
        }
    }
}
