using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using Modbus.Device;
using OPCAutomation;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.PLCDevice
{
    public class PLCDeviceClass
    {
        public EventHandler DeviceMessage;

        public OPCAutomation.OPCServer AnOPCServer;
        public OPCServer ConnectedOPCServer;
        public OPCAutomation.OPCGroups ConnectedServerGroup;
        public OPCGroup ConnectedGroup;
        public string Groupname;

        int ItemCount;
        Array OPCItemIDs = Array.CreateInstance(typeof(string), 10);
        Array ItemServerHandles = Array.CreateInstance(typeof(Int32), 10);
        Array ItemServerErrors = Array.CreateInstance(typeof(Int32), 10);
        Array ClientHandles = Array.CreateInstance(typeof(Int32), 10);
        Array RequestedDataTypes = Array.CreateInstance(typeof(Int16), 10);
        Array AccessPaths = Array.CreateInstance(typeof(string), 10);
        Array WriteItems = Array.CreateInstance(typeof(object), 10);

        bool banderaBit1 = true;

        private void ObjOPCGroup_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            try
            {
                ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;

                for (int i = 1; i <= ClientHandles.Length; i++)
                {
                    if ((Convert.ToInt32(ClientHandles.GetValue(i)) == 1))
                    {
                        if (Convert.ToBoolean(ItemValues.GetValue(i)) != banderaBit1)
                        {
                            if (banderaBit1 == true)
                            {
                                banderaBit1 = false;
                            }
                            else
                            {
                                banderaBit1 = true;
                            }

                            oResultadoOperacion.EntidadDatos = ItemValues.GetValue(i);
                            EventArgsPLCDevice e = new EventArgsPLCDevice(oResultadoOperacion);
                            DeviceMessage(this, e);
                        }

                    }
                }
            }
            catch (Exception e)
            {
                ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }
        }

        /// <summary>
        /// New PLC
        /// </summary>

        public static ResultadoOperacion Escribir(string sPuertoPLC, ushort usDireccion, bool bComando)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.WriteTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;


                    byte slaveId = 1;
                    ushort startAddress = usDireccion;

                    //master.WriteSingleCoil(slaveId, startAddress, bComando);
                    master.WriteSingleRegister(slaveId, startAddress, 1);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }


            return oResultadoOperacion;
        }
        public static ResultadoOperacion Leer(string sPuertoPLC, ushort usDireccion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            bool[] bEstado = null;
            ushort[] HRE = null;
            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.ReadTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;

                    byte slaveId = 1;
                    ushort startAddress = usDireccion;


                    //var gg = master.ReadHoldingRegisters(slaveId, startAddress, 3);
                    //bEstado = master.ReadCoils(slaveId, startAddress, 1);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                oResultadoOperacion.ListaEntidadDatos = bEstado;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        
        
        public static ResultadoOperacion Conectar(string sPuertoPLC)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.ReadTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;



                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
                oResultadoOperacion.Mensaje = ex.ToString();
            }

            return oResultadoOperacion;
        }
        public static ResultadoOperacion AbrirTalanquera(string sPuertoPLC)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.WriteTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;


                    byte slaveId = 1;
                    ushort startAddress = 1;

                    //master.WriteSingleCoil(slaveId, startAddress, bComando);
                    master.WriteSingleRegister(slaveId, startAddress, 1);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }


            return oResultadoOperacion;
        }
        public static ResultadoOperacion AbrirTalanqueraPermanente(string sPuertoPLC, ushort usDireccion, bool bComando)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.WriteTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;


                    byte slaveId = 1;
                    ushort startAddress = usDireccion;

                    master.WriteSingleCoil(slaveId, startAddress, bComando);
                    //master.WriteSingleRegister(slaveId, startAddress, 1);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }


            return oResultadoOperacion;
        }
        public static ResultadoOperacion CerrarTalanqueraPermanente(string sPuertoPLC, ushort usDireccion, bool bComando)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.WriteTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;


                    byte slaveId = 1;
                    ushort startAddress = usDireccion;

                    master.WriteSingleCoil(slaveId, startAddress, bComando);
                    //master.WriteSingleRegister(slaveId, startAddress, 1);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }


            return oResultadoOperacion;
        }
        
        
        public static ResultadoOperacion CarroMueble(string sPuertoPLC)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            bool[] bEstado = null;

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.ReadTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;

                    byte slaveId = 1;
                    ushort startAddress = 2;

                    bEstado = master.ReadCoils(slaveId, startAddress, 1);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                oResultadoOperacion.ListaEntidadDatos = bEstado;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public static ResultadoOperacion ValidacionMotoMueble(string sPuertoPLC)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            bool[] bEstado = null;

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.ReadTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;

                    byte slaveId = 1;
                    ushort startAddress = 12;

                    bEstado = master.ReadCoils(slaveId, startAddress, 1);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                oResultadoOperacion.ListaEntidadDatos = bEstado;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public static ResultadoOperacion CarroenBarrera(string sPuertoPLC)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            bool[] bEstado = null;

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.ReadTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;

                    byte slaveId = 1;
                    ushort startAddress = 7;

                    bEstado = master.ReadCoils(slaveId, startAddress, 1);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                oResultadoOperacion.ListaEntidadDatos = bEstado;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }


            return oResultadoOperacion;
        }
        public static ResultadoOperacion CarroSeFueBarrera(string sPuertoPLC)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            bool[] bEstado = null;

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.ReadTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;

                    byte slaveId = 1;
                    ushort startAddress = 6;

                    bEstado = master.ReadCoils(slaveId, startAddress, 1);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                oResultadoOperacion.ListaEntidadDatos = bEstado;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }


            return oResultadoOperacion;
        }


        public static ResultadoOperacion EstadoBarrera(string sPuertoPLC, ushort usDireccion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            bool[] bEstado = null;

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.ReadTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;

                    byte slaveId = 1;
                    ushort startAddress = usDireccion;

                    bEstado = master.ReadCoils(slaveId, startAddress, 1);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                oResultadoOperacion.ListaEntidadDatos = bEstado;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public static ResultadoOperacion EstadoConexion(string sPuertoPLC)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.ReadTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;



                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }

        public static ResultadoOperacion BorraEstadoLlegoCarroBarrera(string sPuertoPLC)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.WriteTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;


                    byte slaveId = 1;
                    ushort startAddress = 2;

                    //master.WriteSingleCoil(slaveId, startAddress, bComando);
                    master.WriteSingleRegister(slaveId, startAddress, 0);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }


            return oResultadoOperacion;
        }
        public static ResultadoOperacion BorraEstadoSefueCarroBarrera(string sPuertoPLC)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            try
            {
                using (SerialPort port = new SerialPort(sPuertoPLC))
                {
                    // configure serial port
                    port.BaudRate = 38400;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.WriteTimeout = 500;
                    port.Open();

                    // create modbus master
                    IModbusSerialMaster master = ModbusSerialMaster.CreateRtu(port);
                    master.Transport.WriteTimeout = 300;
                    master.Transport.ReadTimeout = 300;
                    master.Transport.Retries = 0;


                    byte slaveId = 1;
                    ushort startAddress = 3;

                    //master.WriteSingleCoil(slaveId, startAddress, bComando);
                    master.WriteSingleRegister(slaveId, startAddress, 0);
                    port.Close();
                }
                oResultadoOperacion.oEstado = TipoRespuesta.Exito;
            }
            catch (Exception ex)
            {
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }


            return oResultadoOperacion;
        }

    }

    public class EventArgsPLCDevice : EventArgs
    {
        private ResultadoOperacion _result;

        public ResultadoOperacion result
        {
            get { return _result; }
            set { _result = value; }
        }

        public EventArgsPLCDevice(ResultadoOperacion oResultadoOperacion)
        {
            _result = oResultadoOperacion;
        }
    }
}
