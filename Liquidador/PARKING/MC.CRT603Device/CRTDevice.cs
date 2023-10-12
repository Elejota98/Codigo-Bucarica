using EGlobalT.Device.SmartCard;
using GS.Apdu;
using GS.Util.Hex;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.CRT603Device
{
    public class CRTDeviceClass
    {
        #region Definiciones
        public EventHandler DeviceMessageCrtState;
        PCSCReader oReaderDevice = new PCSCReader();
        StatesCRT _StatesCRT = new StatesCRT();
        #endregion

        #region Funciones
        public ResultadoOperacion ConectarCRT()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                oResultadoOperacion = oReaderDevice.Connect();

                if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                {
                    _StatesCRT = StatesCRT.Conexion_Exitosa_CRT;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "CRT --> Conexion Exitosa " + oReaderDevice.SCard.ReaderNames[0];
                }
                else
                {
                    _StatesCRT = StatesCRT.Error_Conexion_CRT;
                    oResultadoOperacion.Mensaje = "CRT Error -->" + oResultadoOperacion.Mensaje;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;

                }
            }
            catch (Exception ex)
            {
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                _StatesCRT = StatesCRT.Error_Conexion_CRT;
            }


            EventArgsCrtDevice e = new EventArgsCrtDevice(_StatesCRT,oResultadoOperacion);
            DeviceMessageCrtState(this, e);


            return oResultadoOperacion;
        }
        public ResultadoOperacion GetIdCardCRT()
        {

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                oResultadoOperacion = oReaderDevice.ActivateCard();

                if (oResultadoOperacion.Mensaje == "Esperando Tarjeta...")
                {
                    _StatesCRT = StatesCRT.Sin_Tarjeta;
                    oResultadoOperacion.Mensaje = "No hay tarjeta";
                }
                else
                {
                    RespApdu respApdu = oReaderDevice.Exchange("FF CA 00 00 00"); // Get Card UID ...
                    if (respApdu.SW1SW2 == 0x9000)
                    {
                        _StatesCRT = StatesCRT.IdCardCRT_OK;
                        oResultadoOperacion.EntidadDatos = HexFormatting.ToHexString(respApdu.Data, false);
                        oResultadoOperacion.Mensaje = "ID Tarjeta OK";
                    }
                }

                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                _StatesCRT = StatesCRT.Error_GetId;
            }

            EventArgsCrtDevice e = new EventArgsCrtDevice(_StatesCRT,oResultadoOperacion);
            DeviceMessageCrtState(this, e);
            return oResultadoOperacion;
        }

        public ResultadoOperacion LoadKeyCRT(string PassKey)
        {

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                if (PassKey != string.Empty)
                {
                    RespApdu respApdu = oReaderDevice.Exchange("FF 82 10 00 06 " + PassKey); // LOAD KEY
                    if (respApdu.SW1SW2 == 0x9000)
                    {
                        _StatesCRT = StatesCRT.LoadKeyCRT_ok;
                        oResultadoOperacion.Mensaje = "Key cargada OK";
                        oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    }
                }
                else
                {
                    _StatesCRT = StatesCRT.Error_LoadKeyCRT;
                    oResultadoOperacion.Mensaje = "DEBE PONER UN KEY EN HEXA PARA INICIAR";
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                }
            }
            catch (Exception ex)
            {
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                _StatesCRT = StatesCRT.Error_LoadKeyCRT;
            }


            EventArgsCrtDevice e = new EventArgsCrtDevice(_StatesCRT,oResultadoOperacion);
            DeviceMessageCrtState(this, e);
            return oResultadoOperacion;
        }
        public ResultadoOperacion CheckKeyCRT()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                RespApdu respApdu = oReaderDevice.Exchange("FF 86 00 00 05 01 00 04 60 00"); // CHECK PASS SECTOR 1 BLOQUE 0,1,2,3
                if (respApdu.SW1SW2 == 0x9000)
                {
                    _StatesCRT = StatesCRT.CheckKeyCRT_ok;
                    oResultadoOperacion.Mensaje = "CRT --> KEY PASS SECTOR 1 OK";
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
            }
            catch (Exception ex)
            {
                _StatesCRT = StatesCRT.Error_CheckKeyCRT;
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            EventArgsCrtDevice e = new EventArgsCrtDevice(_StatesCRT,oResultadoOperacion);
            DeviceMessageCrtState(this, e);
            return oResultadoOperacion;
        }

        public ResultadoOperacion ReadCardCRT()
        {

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                RespApdu respApdu = oReaderDevice.Exchange("FF B0 00 04 10"); // READ SECTOR 1 BLOQUE 0
                if (respApdu.SW1SW2 == 0x9000)
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;

                    string CODE = HexFormatting.ToHexString(respApdu.Data, true);
                    string[] Sector1Bloque0 = CODE.Split(' ');

                    byte Byte0 = Convert.ToByte(Sector1Bloque0[0], 16);
                    byte Byte1 = Convert.ToByte(Sector1Bloque0[1], 16);
                    byte Byte2 = Convert.ToByte(Sector1Bloque0[2], 16);
                    byte Byte3 = Convert.ToByte(Sector1Bloque0[3], 16);
                    byte Byte4 = Convert.ToByte(Sector1Bloque0[4], 16);
                    byte Byte5 = Convert.ToByte(Sector1Bloque0[5], 16);
                    byte Byte6 = Convert.ToByte(Sector1Bloque0[6], 16);
                    byte Byte7 = Convert.ToByte(Sector1Bloque0[7], 16);
                    byte Byte8 = Convert.ToByte(Sector1Bloque0[8], 16);
                    byte Byte9 = Convert.ToByte(Sector1Bloque0[9], 16);
                    byte Byte10 = Convert.ToByte(Sector1Bloque0[10], 16);
                    byte Byte11 = Convert.ToByte(Sector1Bloque0[11], 16);
                    byte Byte12 = Convert.ToByte(Sector1Bloque0[12], 16);
                    byte Byte13 = Convert.ToByte(Sector1Bloque0[13], 16);
                    byte Byte14 = Convert.ToByte(Sector1Bloque0[14], 16);
                    byte Byte15 = Convert.ToByte(Sector1Bloque0[15], 16);

                    Tarjeta oTarjeta = new Tarjeta();


                    oTarjeta.ActiveCycle = Convert.ToBoolean(Byte1);

                    string Fecha = Byte4 + "/" + Byte3 + "/" + Byte2 + " " + Byte5 + ":" + Byte6 + ":" + Byte7;

                    if (Fecha != "0/0/0 0:0:0")
                    {
                        oTarjeta.DateTimeEntrance = Convert.ToDateTime(Fecha);
                    }

                    _StatesCRT = StatesCRT.ReadCard_ok;
                    oResultadoOperacion.Mensaje = "Tarjeta leida Correctamente";
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.EntidadDatos = oTarjeta;

                }
            }
            catch (Exception ex)
            {
                _StatesCRT = StatesCRT.Error_ReadCard;
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            EventArgsCrtDevice e = new EventArgsCrtDevice(_StatesCRT, oResultadoOperacion);
            DeviceMessageCrtState(this, e);
            return oResultadoOperacion;
        }
        public ResultadoOperacion WriteCardCRT(Tarjeta oTarjeta)
        {

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string TipoTarjeta = string.Empty;

            try
            {

                if (oTarjeta.TypeCard == TYPE_TARJETAPARKING_V1.VISITOR)
                {
                    TipoTarjeta = "03";
                }
                else if (oTarjeta.TypeCard == TYPE_TARJETAPARKING_V1.AUTHORIZED_PARKING)
                {
                    TipoTarjeta = "02";
                }
                else 
                {
                    TipoTarjeta = "03";
                }


                #region SECTOR 1 BLOQUE 0 
                //sector 1 bloque 0 "TARJETA - BANCERAS - FECHAENTRADA - MODULOENTRADA"

                
                string CicloActivo = "01";
                string año = Convert.ToDateTime(oTarjeta.DateTimeEntrance).ToString("yy");
                string mes = Convert.ToDateTime(oTarjeta.DateTimeEntrance).ToString("MM");
                string dia = Convert.ToDateTime(oTarjeta.DateTimeEntrance).ToString("dd");
                string hora = Convert.ToDateTime(oTarjeta.DateTimeEntrance).ToString("HH");
                string minuto = Convert.ToDateTime(oTarjeta.DateTimeEntrance).ToString("mm");
                string segundo = Convert.ToDateTime(oTarjeta.DateTimeEntrance).ToString("ss");
                
                long decValue1 = Convert.ToInt64(año);
                string hexValue1 = decValue1.ToString("X");
                if (hexValue1.Length < 2)
                {
                    hexValue1 = hexValue1.PadLeft(2, '0');
                }                
                long decValue2 = Convert.ToInt64(mes);
                string hexValue2 = decValue2.ToString("X");
                if (hexValue2.Length < 2)
                {
                    hexValue2 = hexValue2.PadLeft(2, '0');
                }
                long decValue3 = Convert.ToInt64(dia);
                string hexValue3 = decValue3.ToString("X");
                if (hexValue3.Length < 2)
                {
                    hexValue3 = hexValue3.PadLeft(2, '0');
                }
                long decValue4 = Convert.ToInt64(hora);
                string hexValue4 = decValue4.ToString("X");
                if (hexValue4.Length < 2)
                {
                    hexValue4 = hexValue4.PadLeft(2, '0');
                }
                long decValue5 = Convert.ToInt64(minuto);
                string hexValue5 = decValue5.ToString("X");
                if (hexValue5.Length < 2)
                {
                    hexValue5 = hexValue5.PadLeft(2, '0');
                }
                long decValue6 = Convert.ToInt64(segundo);
                string hexValue6 = decValue6.ToString("X");
                if (hexValue6.Length < 2)
                {
                    hexValue6 = hexValue6.PadLeft(2, '0');
                }
               

                byte[] a = Encoding.ASCII.GetBytes(oTarjeta.EntranceModule);
                string ModuloEntrada = HexFormatting.ToHexString(a, true);


                string fechaEntrada = hexValue1 + " " + hexValue2 + " " + hexValue3 + " " + hexValue4 + " " + hexValue5 + " " + hexValue6;
                string Comando = "FF D6 00 04 10 " + TipoTarjeta + " " + CicloActivo + " " + fechaEntrada + " " + ModuloEntrada + "20 20";

                #endregion

                RespApdu respApdu = oReaderDevice.Exchange(Comando); // WRITE SECTOR 1 BLOQUE 0
                if (respApdu.SW1SW2 == 0x9000)
                {
                    _StatesCRT = StatesCRT.WriteCard_ok;
                    oResultadoOperacion.Mensaje = "Tarjeta Escrita Correctamente";
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }

                
            }
            catch (Exception ex)
            {
                _StatesCRT = StatesCRT.Error_WriteCard;
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            EventArgsCrtDevice e = new EventArgsCrtDevice(_StatesCRT, oResultadoOperacion);
            DeviceMessageCrtState(this, e);
            return oResultadoOperacion;
        }

        public ResultadoOperacion WriteCardCRTExit(Tarjeta oTarjeta)
        {

            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string TipoTarjeta = string.Empty;

            try
            {

                if (oTarjeta.TypeCard == TYPE_TARJETAPARKING_V1.VISITOR)
                {
                    TipoTarjeta = "03";
                }
                else if (oTarjeta.TypeCard == TYPE_TARJETAPARKING_V1.AUTHORIZED_PARKING)
                {
                    TipoTarjeta = "02";
                }
                else
                {
                    TipoTarjeta = "03";
                }


                #region SECTOR 1 BLOQUE 0
                //sector 1 bloque 0 "TARJETA - BANCERAS - FECHAENTRADA - MODULOENTRADA"


                string CicloActivo = "00";
                string año = "00";
                string mes = "00";
                string dia = "00";
                string hora = "00";
                string minuto = "00";
                string segundo = "00";

                long decValue1 = Convert.ToInt64(año);
                string hexValue1 = decValue1.ToString("X");
                if (hexValue1.Length < 2)
                {
                    hexValue1 = hexValue1.PadLeft(2, '0');
                }
                long decValue2 = Convert.ToInt64(mes);
                string hexValue2 = decValue2.ToString("X");
                if (hexValue2.Length < 2)
                {
                    hexValue2 = hexValue2.PadLeft(2, '0');
                }
                long decValue3 = Convert.ToInt64(dia);
                string hexValue3 = decValue3.ToString("X");
                if (hexValue3.Length < 2)
                {
                    hexValue3 = hexValue3.PadLeft(2, '0');
                }
                long decValue4 = Convert.ToInt64(hora);
                string hexValue4 = decValue4.ToString("X");
                if (hexValue4.Length < 2)
                {
                    hexValue4 = hexValue4.PadLeft(2, '0');
                }
                long decValue5 = Convert.ToInt64(minuto);
                string hexValue5 = decValue5.ToString("X");
                if (hexValue5.Length < 2)
                {
                    hexValue5 = hexValue5.PadLeft(2, '0');
                }
                long decValue6 = Convert.ToInt64(segundo);
                string hexValue6 = decValue6.ToString("X");
                if (hexValue6.Length < 2)
                {
                    hexValue6 = hexValue6.PadLeft(2, '0');
                }


                byte[] a = Encoding.ASCII.GetBytes(oTarjeta.EntranceModule);
                string ModuloEntrada = HexFormatting.ToHexString(a, true);


                string fechaEntrada = hexValue1 + " " + hexValue2 + " " + hexValue3 + " " + hexValue4 + " " + hexValue5 + " " + hexValue6;
                string Comando = "FF D6 00 04 10 " + TipoTarjeta + " " + CicloActivo + " " + fechaEntrada + " " + "00 " + "00 00" + " 00 00 00 00 00";

                #endregion

                RespApdu respApdu = oReaderDevice.Exchange(Comando); // WRITE SECTOR 1 BLOQUE 0
                if (respApdu.SW1SW2 == 0x9000)
                {
                    _StatesCRT = StatesCRT.WriteCard_ok;
                    oResultadoOperacion.Mensaje = "Tarjeta Escrita Correctamente";
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }


            }
            catch (Exception ex)
            {
                _StatesCRT = StatesCRT.Error_WriteCard;
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            EventArgsCrtDevice e = new EventArgsCrtDevice(_StatesCRT, oResultadoOperacion);
            DeviceMessageCrtState(this, e);
            return oResultadoOperacion;
        }
       
        
        #endregion
    }

    public class EventArgsCrtDevice : EventArgs
    {
        private StatesCRT _result;

        public StatesCRT result
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

        //public EventArgsCrtDevice(StatesCRT oStatesCRT)
        //{
        //    _result = oStatesCRT;
            
        //}

        public EventArgsCrtDevice(StatesCRT oStatesCRT, ResultadoOperacion oResultadoOperacion)
        {
            _result = oStatesCRT;
            _resultString = oResultadoOperacion;
        }
    }
}
