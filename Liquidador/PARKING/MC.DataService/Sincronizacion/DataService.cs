using MC.BusinessService.DataTransferObject;
using MC.BusinessService.Entities;
using MC.BusinessService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.DataService
{
    public partial class DataService : IDataService
    {
        public ResultadoOperacion ObtenerSincronizacionTransaccion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoTransaccion oDtoTransaccion = new DtoTransaccion();

            DataSetSincronizacion.P_DatosTransaccionSincronizacionDataTable _InfoTransaccionTable = new DataSetSincronizacion.P_DatosTransaccionSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosTransaccionSincronizacionTableAdapter _InfoTransaccionAdapter = new DataSetSincronizacionTableAdapters.P_DatosTransaccionSincronizacionTableAdapter();


            try
            {
                _InfoTransaccionTable.Constraints.Clear();

                if (_InfoTransaccionAdapter.Fill(_InfoTransaccionTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info transaccion OK";

                    for (int i = 0; i < _InfoTransaccionTable.Rows.Count; i++)
                    {
                        oDtoTransaccion.IdTransaccion = Convert.ToInt64(_InfoTransaccionTable.Rows[i][0]);
                        oDtoTransaccion.CarrilEntrada = Convert.ToInt32(_InfoTransaccionTable.Rows[i][1]);
                        oDtoTransaccion.ModuloEntrada = _InfoTransaccionTable.Rows[i][2].ToString();
                        oDtoTransaccion.IdEstacionamiento = Convert.ToInt64(_InfoTransaccionTable.Rows[i][3]);
                        oDtoTransaccion.IdTarjeta = _InfoTransaccionTable.Rows[i][4].ToString();
                        oDtoTransaccion.PlacaEntrada = _InfoTransaccionTable.Rows[i][5].ToString();
                        oDtoTransaccion.FechaEntrada = Convert.ToDateTime(_InfoTransaccionTable.Rows[i][6]);

                        string FechaSalida = _InfoTransaccionTable.Rows[i][7].ToString();

                        if (FechaSalida != string.Empty)
                        {
                            oDtoTransaccion.FechaSalida = Convert.ToDateTime(FechaSalida);
                        }
                        else 
                        {
                            oDtoTransaccion.FechaSalida = null;
                        }
                        oDtoTransaccion.ModuloSalida = _InfoTransaccionTable.Rows[i][8].ToString();

                        string CarrilSalida = _InfoTransaccionTable.Rows[i][9].ToString();

                        if (CarrilSalida != string.Empty)
                        {
                            oDtoTransaccion.CarrilSalida = Convert.ToInt32(CarrilSalida);
                        }
                        else
                        {
                            oDtoTransaccion.CarrilSalida = 0;
                        }


                        oDtoTransaccion.PlacaSalida = _InfoTransaccionTable.Rows[i][10].ToString();
                        oDtoTransaccion.IdTipoVehiculo = Convert.ToInt32(_InfoTransaccionTable.Rows[i][11]);
                        string Cortesia = _InfoTransaccionTable.Rows[i][12].ToString();

                        if (Cortesia != string.Empty)
                        {
                            oDtoTransaccion.Cortesia = Convert.ToInt64(Cortesia);
                        }
                        else
                        {
                            oDtoTransaccion.Cortesia = 0;
                        }

                        string IdAutorizado = _InfoTransaccionTable.Rows[i][13].ToString();

                        if (IdAutorizado != string.Empty)
                        {
                            oDtoTransaccion.IdAutorizado = Convert.ToInt64(IdAutorizado);
                        }
                        else
                        {
                            oDtoTransaccion.IdAutorizado = 0;
                        }

                        string Convenio1 = _InfoTransaccionTable.Rows[i][14].ToString();

                        if (Convenio1 != string.Empty)
                        {
                            oDtoTransaccion.Convenio1 = Convert.ToInt64(Convenio1);
                        }
                        else
                        {
                            oDtoTransaccion.Convenio1 = 0;
                        }

                        string Convenio2 = _InfoTransaccionTable.Rows[i][15].ToString();

                        if (Convenio2 != string.Empty)
                        {
                            oDtoTransaccion.Convenio2 = Convert.ToInt64(Convenio2);
                        }
                        else
                        {
                            oDtoTransaccion.Convenio2 = 0;
                        }

                        string Convenio3 = _InfoTransaccionTable.Rows[i][16].ToString();

                        if (Convenio3 != string.Empty)
                        {
                            oDtoTransaccion.Convenio3 = Convert.ToInt64(Convenio3);
                        }
                        else
                        {
                            oDtoTransaccion.Convenio3 = 0;
                        }

                        string ValorRecibido = _InfoTransaccionTable.Rows[i][17].ToString();

                        if (ValorRecibido != string.Empty)
                        {
                            oDtoTransaccion.ValorRecibido = Convert.ToDouble(ValorRecibido);
                        }
                        else
                        {
                            oDtoTransaccion.ValorRecibido = 0;
                        }

                        string Cambio = _InfoTransaccionTable.Rows[i][18].ToString();

                        if (Cambio != string.Empty)
                        {
                            oDtoTransaccion.Cambio = Convert.ToDouble(Cambio);
                        }
                        else
                        {
                            oDtoTransaccion.Cambio = 0;
                        }

                        oDtoTransaccion.Sincronizacion = Convert.ToBoolean(_InfoTransaccionTable.Rows[i][19]);
                        oDtoTransaccion.SincronizacionPago = Convert.ToBoolean(_InfoTransaccionTable.Rows[i][20]);
                        oDtoTransaccion.SincronizacionSalida = Convert.ToBoolean(_InfoTransaccionTable.Rows[i][21]);

                    }

                    oResultadoOperacion.EntidadDatos = oDtoTransaccion;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin registro en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ObtenerSincronizacionPagoTransaccion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoTransaccion oDtoTransaccion = new DtoTransaccion();

            DataSetSincronizacion.P_DatosTransaccionSincronizacionPagoDataTable _InfoTransaccionTable = new DataSetSincronizacion.P_DatosTransaccionSincronizacionPagoDataTable();
            DataSetSincronizacionTableAdapters.P_DatosTransaccionSincronizacionPagoTableAdapter _InfoTransaccionAdapter = new DataSetSincronizacionTableAdapters.P_DatosTransaccionSincronizacionPagoTableAdapter();

            try
            {
                _InfoTransaccionTable.Constraints.Clear();

                if (_InfoTransaccionAdapter.Fill(_InfoTransaccionTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info transaccion OK";

                    for (int i = 0; i < _InfoTransaccionTable.Rows.Count; i++)
                    {
                        oDtoTransaccion.IdTransaccion = Convert.ToInt64(_InfoTransaccionTable.Rows[i][0]);
                        oDtoTransaccion.CarrilEntrada = Convert.ToInt32(_InfoTransaccionTable.Rows[i][1]);
                        oDtoTransaccion.ModuloEntrada = _InfoTransaccionTable.Rows[i][2].ToString();
                        oDtoTransaccion.IdEstacionamiento = Convert.ToInt64(_InfoTransaccionTable.Rows[i][3]);
                        oDtoTransaccion.IdTarjeta = _InfoTransaccionTable.Rows[i][4].ToString();
                        oDtoTransaccion.PlacaEntrada = _InfoTransaccionTable.Rows[i][5].ToString();
                        oDtoTransaccion.FechaEntrada = Convert.ToDateTime(_InfoTransaccionTable.Rows[i][6]);
                        
                        string FECHASALIDA = _InfoTransaccionTable.Rows[i][7].ToString();

                        if (FECHASALIDA != string.Empty)
                        {
                            oDtoTransaccion.FechaSalida = Convert.ToDateTime(FECHASALIDA);
                        }
                        else
                        {
                            oDtoTransaccion.FechaSalida = null;
                        }
                        
                        oDtoTransaccion.ModuloSalida = _InfoTransaccionTable.Rows[i][8].ToString();

                        if (oDtoTransaccion.ModuloSalida == string.Empty)
                        {
                            oDtoTransaccion.ModuloSalida = null;
                        }


                        string CarrilSalida = _InfoTransaccionTable.Rows[i][9].ToString();

                        if (CarrilSalida != string.Empty)
                        {
                            oDtoTransaccion.CarrilSalida = Convert.ToInt32(CarrilSalida);
                        }
                        else
                        {
                            oDtoTransaccion.CarrilSalida = null;
                        }
                        oDtoTransaccion.PlacaSalida = _InfoTransaccionTable.Rows[i][10].ToString();

                        if (oDtoTransaccion.PlacaSalida == string.Empty)
                        {
                            oDtoTransaccion.PlacaSalida = "------";
                        }

                        oDtoTransaccion.IdTipoVehiculo = Convert.ToInt32(_InfoTransaccionTable.Rows[i][11]);
                        string Cortesia = _InfoTransaccionTable.Rows[i][12].ToString();

                        if (Cortesia != string.Empty)
                        {
                            oDtoTransaccion.Cortesia = Convert.ToInt64(Cortesia);
                        }
                        else
                        {
                            oDtoTransaccion.Cortesia = 0;
                        }

                        string IdAutorizado = _InfoTransaccionTable.Rows[i][13].ToString();

                        if (IdAutorizado != string.Empty)
                        {
                            oDtoTransaccion.IdAutorizado = Convert.ToInt64(IdAutorizado);
                        }
                        else
                        {
                            oDtoTransaccion.IdAutorizado = 0;
                        }

                        string Convenio1 = _InfoTransaccionTable.Rows[i][14].ToString();

                        if (Convenio1 != string.Empty)
                        {
                            oDtoTransaccion.Convenio1 = Convert.ToInt64(Convenio1);
                        }
                        else
                        {
                            oDtoTransaccion.Convenio1 = 0;
                        }

                        string Convenio2 = _InfoTransaccionTable.Rows[i][15].ToString();

                        if (Convenio2 != string.Empty)
                        {
                            oDtoTransaccion.Convenio2 = Convert.ToInt64(Convenio2);
                        }
                        else
                        {
                            oDtoTransaccion.Convenio2 = 0;
                        }

                        string Convenio3 = _InfoTransaccionTable.Rows[i][16].ToString();

                        if (Convenio3 != string.Empty)
                        {
                            oDtoTransaccion.Convenio3 = Convert.ToInt64(Convenio3);
                        }
                        else
                        {
                            oDtoTransaccion.Convenio3 = 0;
                        }

                        string ValorRecibido = _InfoTransaccionTable.Rows[i][17].ToString();

                        if (ValorRecibido != string.Empty)
                        {
                            oDtoTransaccion.ValorRecibido = Convert.ToDouble(ValorRecibido);
                        }
                        else
                        {
                            oDtoTransaccion.ValorRecibido = 0;
                        }

                        string Cambio = _InfoTransaccionTable.Rows[i][18].ToString();

                        if (Cambio != string.Empty)
                        {
                            oDtoTransaccion.Cambio = Convert.ToDouble(Cambio);
                        }
                        else
                        {
                            oDtoTransaccion.Cambio = 0;
                        }

                        oDtoTransaccion.Sincronizacion = Convert.ToBoolean(_InfoTransaccionTable.Rows[i][19]);
                        oDtoTransaccion.SincronizacionPago = Convert.ToBoolean(_InfoTransaccionTable.Rows[i][20]);
                        oDtoTransaccion.SincronizacionSalida = Convert.ToBoolean(_InfoTransaccionTable.Rows[i][21]);

                    }

                    oResultadoOperacion.EntidadDatos = oDtoTransaccion;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin registros en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ObtenerSincronizacionSalidaTransaccion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoTransaccion oDtoTransaccion = new DtoTransaccion();

            DataSetSincronizacion.P_DatosTransaccionSincronizacionSalidaDataTable _InfoTransaccionTable = new DataSetSincronizacion.P_DatosTransaccionSincronizacionSalidaDataTable();
            DataSetSincronizacionTableAdapters.P_DatosTransaccionSincronizacionSalidaTableAdapter _InfoTransaccionAdapter = new DataSetSincronizacionTableAdapters.P_DatosTransaccionSincronizacionSalidaTableAdapter();

            try
            {
                _InfoTransaccionTable.Constraints.Clear();

                if (_InfoTransaccionAdapter.Fill(_InfoTransaccionTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info transaccion OK";

                    for (int i = 0; i < _InfoTransaccionTable.Rows.Count; i++)
                    {
                        oDtoTransaccion.IdTransaccion = Convert.ToInt64(_InfoTransaccionTable.Rows[i][0]);
                        oDtoTransaccion.CarrilEntrada = Convert.ToInt32(_InfoTransaccionTable.Rows[i][1]);
                        oDtoTransaccion.ModuloEntrada = _InfoTransaccionTable.Rows[i][2].ToString();
                        oDtoTransaccion.IdEstacionamiento = Convert.ToInt64(_InfoTransaccionTable.Rows[i][3]);
                        oDtoTransaccion.IdTarjeta = _InfoTransaccionTable.Rows[i][4].ToString();
                        oDtoTransaccion.PlacaEntrada = _InfoTransaccionTable.Rows[i][5].ToString();
                        oDtoTransaccion.FechaEntrada = Convert.ToDateTime(_InfoTransaccionTable.Rows[i][6]);
                        
                        string FECHASALIDA = _InfoTransaccionTable.Rows[i][7].ToString();

                        if (FECHASALIDA != string.Empty)
                        {
                            oDtoTransaccion.FechaSalida = Convert.ToDateTime(FECHASALIDA);
                        }
                        else
                        {
                            oDtoTransaccion.FechaSalida = null;
                        }
                        
                        oDtoTransaccion.ModuloSalida = _InfoTransaccionTable.Rows[i][8].ToString();

                        if (oDtoTransaccion.ModuloSalida == string.Empty)
                        {
                            oDtoTransaccion.ModuloSalida = null;
                        }


                        string CarrilSalida = _InfoTransaccionTable.Rows[i][9].ToString();

                        if (CarrilSalida != string.Empty)
                        {
                            oDtoTransaccion.CarrilSalida = Convert.ToInt32(CarrilSalida);
                        }
                        else
                        {
                            oDtoTransaccion.CarrilSalida = null;
                        }
                        
                        
                        oDtoTransaccion.PlacaSalida = _InfoTransaccionTable.Rows[i][10].ToString();

                        if (oDtoTransaccion.PlacaSalida == string.Empty)
                        {
                            oDtoTransaccion.PlacaSalida = "------"; 
                        }


                        oDtoTransaccion.IdTipoVehiculo = Convert.ToInt32(_InfoTransaccionTable.Rows[i][11]);
                        string Cortesia = _InfoTransaccionTable.Rows[i][12].ToString();

                        if (Cortesia != string.Empty)
                        {
                            oDtoTransaccion.Cortesia = Convert.ToInt64(Cortesia);
                        }
                        else
                        {
                            oDtoTransaccion.Cortesia = 0;
                        }

                        string IdAutorizado = _InfoTransaccionTable.Rows[i][13].ToString();

                        if (IdAutorizado != string.Empty)
                        {
                            oDtoTransaccion.IdAutorizado = Convert.ToInt64(IdAutorizado);
                        }
                        else
                        {
                            oDtoTransaccion.IdAutorizado = 0;
                        }

                        string Convenio1 = _InfoTransaccionTable.Rows[i][14].ToString();

                        if (Convenio1 != string.Empty)
                        {
                            oDtoTransaccion.Convenio1 = Convert.ToInt64(Convenio1);
                        }
                        else
                        {
                            oDtoTransaccion.Convenio1 = 0;
                        }

                        string Convenio2 = _InfoTransaccionTable.Rows[i][15].ToString();

                        if (Convenio2 != string.Empty)
                        {
                            oDtoTransaccion.Convenio2 = Convert.ToInt64(Convenio2);
                        }
                        else
                        {
                            oDtoTransaccion.Convenio2 = 0;
                        }

                        string Convenio3 = _InfoTransaccionTable.Rows[i][16].ToString();

                        if (Convenio3 != string.Empty)
                        {
                            oDtoTransaccion.Convenio3 = Convert.ToInt64(Convenio3);
                        }
                        else
                        {
                            oDtoTransaccion.Convenio3 = 0;
                        }

                        string ValorRecibido = _InfoTransaccionTable.Rows[i][17].ToString();

                        if (ValorRecibido != string.Empty)
                        {
                            oDtoTransaccion.ValorRecibido = Convert.ToDouble(ValorRecibido);
                        }
                        else
                        {
                            oDtoTransaccion.ValorRecibido = 0;
                        }

                        string Cambio = _InfoTransaccionTable.Rows[i][18].ToString();

                        if (Cambio != string.Empty)
                        {
                            oDtoTransaccion.Cambio = Convert.ToDouble(Cambio);
                        }
                        else
                        {
                            oDtoTransaccion.Cambio = 0;
                        }

                        oDtoTransaccion.Sincronizacion = Convert.ToBoolean(_InfoTransaccionTable.Rows[i][19]);
                        oDtoTransaccion.SincronizacionPago = Convert.ToBoolean(_InfoTransaccionTable.Rows[i][20]);
                        oDtoTransaccion.SincronizacionSalida = Convert.ToBoolean(_InfoTransaccionTable.Rows[i][21]);

                    }

                    oResultadoOperacion.EntidadDatos = oDtoTransaccion;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin registro en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion RegistrarSincronizacionTransaccion(Transaccion oTransaccion, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_RegistrarTransaccionSincronizacionDataTable _RegistroTransaccionesTable = new DataSetSincronizacion.P_RegistrarTransaccionSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarTransaccionSincronizacionTableAdapter _RegistroTransaccionesAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarTransaccionSincronizacionTableAdapter();

            _RegistroTransaccionesAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistroTransaccionesTable.Constraints.Clear();

                if (_RegistroTransaccionesAdapter.Fill(_RegistroTransaccionesTable, oTransaccion.IdTransaccion, oTransaccion.CarrilEntrada, oTransaccion.ModuloEntrada, oTransaccion.IdEstacionamiento, oTransaccion.IdTarjeta, oTransaccion.PlacaEntrada, oTransaccion.FechaEntrada, oTransaccion.FechaSalida, oTransaccion.ModuloSalida, oTransaccion.CarrilSalida, oTransaccion.PlacaSalida, oTransaccion.IdTipoVehiculo, oTransaccion.Cortesia, oTransaccion.IdAutorizado, oTransaccion.Convenio1, oTransaccion.Convenio2, oTransaccion.Convenio3, oTransaccion.ValorRecibido, oTransaccion.Cambio, oTransaccion.Sincronizacion, oTransaccion.SincronizacionPago, oTransaccion.SincronizacionSalida) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro transaccion OK";

                    for (int i = 0; i < _RegistroTransaccionesTable.Rows.Count; i++)
                    {
                        resultado = _RegistroTransaccionesTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando prestamo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionPagoTransaccion(Transaccion oTransaccion, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_RegistrarTransaccionSincronizacionPagoDataTable _RegistroTransaccionesTable = new DataSetSincronizacion.P_RegistrarTransaccionSincronizacionPagoDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarTransaccionSincronizacionPagoTableAdapter _RegistroTransaccionesAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarTransaccionSincronizacionPagoTableAdapter();

            _RegistroTransaccionesAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistroTransaccionesTable.Constraints.Clear();

                if (_RegistroTransaccionesAdapter.Fill(_RegistroTransaccionesTable, oTransaccion.IdTransaccion, oTransaccion.CarrilEntrada, oTransaccion.ModuloEntrada, oTransaccion.IdEstacionamiento, oTransaccion.IdTarjeta, oTransaccion.PlacaEntrada, oTransaccion.FechaEntrada, oTransaccion.FechaSalida, oTransaccion.ModuloSalida, oTransaccion.CarrilSalida, oTransaccion.PlacaSalida, oTransaccion.IdTipoVehiculo, oTransaccion.Cortesia, oTransaccion.IdAutorizado, oTransaccion.Convenio1, oTransaccion.Convenio2, oTransaccion.Convenio3, oTransaccion.ValorRecibido, oTransaccion.Cambio, oTransaccion.Sincronizacion, oTransaccion.SincronizacionPago, oTransaccion.SincronizacionSalida) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro transaccion OK";

                    for (int i = 0; i < _RegistroTransaccionesTable.Rows.Count; i++)
                    {
                        resultado = _RegistroTransaccionesTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando prestamo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionSalidaTransaccion(Transaccion oTransaccion, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_RegistrarTransaccionSincronizacionSalidaDataTable _RegistroTransaccionesTable = new DataSetSincronizacion.P_RegistrarTransaccionSincronizacionSalidaDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarTransaccionSincronizacionSalidaTableAdapter _RegistroTransaccionesAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarTransaccionSincronizacionSalidaTableAdapter();

            _RegistroTransaccionesAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistroTransaccionesTable.Constraints.Clear();

                if (_RegistroTransaccionesAdapter.Fill(_RegistroTransaccionesTable, oTransaccion.IdTransaccion, oTransaccion.CarrilEntrada, oTransaccion.ModuloEntrada, oTransaccion.IdEstacionamiento, oTransaccion.IdTarjeta, oTransaccion.PlacaEntrada, oTransaccion.FechaEntrada, oTransaccion.FechaSalida, oTransaccion.ModuloSalida, oTransaccion.CarrilSalida, oTransaccion.PlacaSalida, oTransaccion.IdTipoVehiculo, oTransaccion.Cortesia, oTransaccion.IdAutorizado, oTransaccion.Convenio1, oTransaccion.Convenio2, oTransaccion.Convenio3, oTransaccion.ValorRecibido, oTransaccion.Cambio, oTransaccion.Sincronizacion, oTransaccion.SincronizacionPago, oTransaccion.SincronizacionSalida) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro transaccion OK";

                    for (int i = 0; i < _RegistroTransaccionesTable.Rows.Count; i++)
                    {
                        resultado = _RegistroTransaccionesTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando prestamo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }

        public ResultadoOperacion ActualizaSincronizacionTransaccion(long Transaccion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionTransaccionDataTable _UpdateTransaccionesTable = new DataSetSincronizacion.P_ActualizaSincronizacionTransaccionDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionTransaccionTableAdapter _UpdateTransaccionesAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionTransaccionTableAdapter();


            try
            {
                _UpdateTransaccionesTable.Constraints.Clear();

                if (_UpdateTransaccionesAdapter.Fill(_UpdateTransaccionesTable, Transaccion) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro transaccion OK";

                    for (int i = 0; i < _UpdateTransaccionesTable.Rows.Count; i++)
                    {
                        resultado = _UpdateTransaccionesTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando prestamo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaSincronizacionPagoTransaccion(long Transaccion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionPagoTransaccionDataTable _UpdateTransaccionesTable = new DataSetSincronizacion.P_ActualizaSincronizacionPagoTransaccionDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionPagoTransaccionTableAdapter _UpdateTransaccionesAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionPagoTransaccionTableAdapter();


            try
            {
                _UpdateTransaccionesTable.Constraints.Clear();

                if (_UpdateTransaccionesAdapter.Fill(_UpdateTransaccionesTable, Transaccion) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro transaccion OK";

                    for (int i = 0; i < _UpdateTransaccionesTable.Rows.Count; i++)
                    {
                        resultado = _UpdateTransaccionesTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando prestamo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaSincronizacionSalidaTransaccion(long Transaccion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionSalidaTransaccionDataTable _UpdateTransaccionesTable = new DataSetSincronizacion.P_ActualizaSincronizacionSalidaTransaccionDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionSalidaTransaccionTableAdapter _UpdateTransaccionesAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionSalidaTransaccionTableAdapter();


            try
            {
                _UpdateTransaccionesTable.Constraints.Clear();

                if (_UpdateTransaccionesAdapter.Fill(_UpdateTransaccionesTable, Transaccion) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro transaccion OK";

                    for (int i = 0; i < _UpdateTransaccionesTable.Rows.Count; i++)
                    {
                        resultado = _UpdateTransaccionesTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando prestamo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }


        /////////PAGOS

        public ResultadoOperacion ObtenerPagoSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoPago oDtoPago = new DtoPago();

            DataSetSincronizacion.P_DatosPagoSincronizacionDataTable _InfoPagoTable = new DataSetSincronizacion.P_DatosPagoSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosPagoSincronizacionTableAdapter _InfoPagoAdapter = new DataSetSincronizacionTableAdapters.P_DatosPagoSincronizacionTableAdapter();


            try
            {
                _InfoPagoTable.Constraints.Clear();

                if (_InfoPagoAdapter.Fill(_InfoPagoTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info pago OK";

                    for (int i = 0; i < _InfoPagoTable.Rows.Count; i++)
                    {
                        oDtoPago.IdPago = Convert.ToInt64(_InfoPagoTable.Rows[i][0]);
                        oDtoPago.IdTransaccion = _InfoPagoTable.Rows[i][1].ToString();

                        string IdAutorizado = _InfoPagoTable.Rows[i][2].ToString();

                        if (IdAutorizado != string.Empty)
                        {
                            oDtoPago.IdAutorizado = Convert.ToInt64(IdAutorizado);
                        }
                        else
                        {
                            oDtoPago.IdAutorizado = 0;
                        }

                        oDtoPago.IdEstacionamiento = Convert.ToInt64(_InfoPagoTable.Rows[i][3]);
                        oDtoPago.IdModulo = _InfoPagoTable.Rows[i][4].ToString();
                        oDtoPago.IdFacturacion = Convert.ToInt64(_InfoPagoTable.Rows[i][5]);
                        oDtoPago.IdTipoPago = Convert.ToInt64(_InfoPagoTable.Rows[i][6]);
                        oDtoPago.FechaPago = Convert.ToDateTime(_InfoPagoTable.Rows[i][7]);
                        oDtoPago.Subtotal = Convert.ToDouble(_InfoPagoTable.Rows[i][8]);
                        oDtoPago.Iva = Convert.ToDouble(_InfoPagoTable.Rows[i][9]);
                        oDtoPago.Total = Convert.ToDouble(_InfoPagoTable.Rows[i][10]);
                        oDtoPago.NumeroFactura = _InfoPagoTable.Rows[i][11].ToString();
                        oDtoPago.Sincronizacion = Convert.ToBoolean(_InfoPagoTable.Rows[i][12]);
                        oDtoPago.PagoMensual = Convert.ToBoolean(_InfoPagoTable.Rows[i][13]);
                        oDtoPago.Anulada = Convert.ToBoolean(_InfoPagoTable.Rows[i][14]);

                    }

                    oResultadoOperacion.EntidadDatos = oDtoPago;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin registro en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionPago(Pago oPago, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;
            string Tipo = string.Empty;


            DataSetSincronizacion.P_RegistrarPagoSincronizacionDataTable _RegistroPagoTable = new DataSetSincronizacion.P_RegistrarPagoSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarPagoSincronizacionTableAdapter _RegistroPagoAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarPagoSincronizacionTableAdapter();

            _RegistroPagoAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistroPagoTable.Constraints.Clear();

                if (_RegistroPagoAdapter.Fill(_RegistroPagoTable, oPago.IdPago, oPago.IdTransaccion, oPago.IdAutorizado, oPago.IdEstacionamiento, oPago.IdModulo, oPago.IdFacturacion, oPago.IdTipoPago, oPago.FechaPago, oPago.Subtotal, oPago.Iva, oPago.Total, oPago.NumeroFactura, oPago.Sincronizacion, oPago.PagoMensual, oPago.Anulada) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro pago OK";

                    for (int i = 0; i < _RegistroPagoTable.Rows.Count; i++)
                    {
                        resultado = _RegistroPagoTable.Rows[i][0].ToString();
                        Tipo = _RegistroPagoTable.Rows[i][1].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado + ";" + Tipo;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando prestamo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaSincronizacionPago(string IdTransaccion, long Pago, long IdTipoPago)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionPagoDataTable _UpdatePagoTable = new DataSetSincronizacion.P_ActualizaSincronizacionPagoDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionPagoTableAdapter _UpdatePagoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionPagoTableAdapter();


            try
            {
                _UpdatePagoTable.Constraints.Clear();

                if (_UpdatePagoAdapter.Fill(_UpdatePagoTable,IdTransaccion, Pago, IdTipoPago) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro pago OK";

                    for (int i = 0; i < _UpdatePagoTable.Rows.Count; i++)
                    {
                        resultado = _UpdatePagoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando pago";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }

        /////////MOVIMIENTOS

        public ResultadoOperacion ObtenerMovimientoSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoMovimientos oDtoMovimientos = new DtoMovimientos();

            DataSetSincronizacion.P_DatosMovimientoSincronizacionDataTable _InfoMovimientoTable = new DataSetSincronizacion.P_DatosMovimientoSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosMovimientoSincronizacionTableAdapter _InfoMovimientoAdapter = new DataSetSincronizacionTableAdapters.P_DatosMovimientoSincronizacionTableAdapter();


            try
            {
                _InfoMovimientoTable.Constraints.Clear();

                if (_InfoMovimientoAdapter.Fill(_InfoMovimientoTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info movimiento OK";

                    for (int i = 0; i < _InfoMovimientoTable.Rows.Count; i++)
                    {
                        oDtoMovimientos.IdMovimiento = Convert.ToInt64(_InfoMovimientoTable.Rows[i][0]);

                        string IdTransaccion = _InfoMovimientoTable.Rows[i][1].ToString();
                        if (IdTransaccion != string.Empty)
                        {
                            oDtoMovimientos.IdTransaccion = Convert.ToInt64(IdTransaccion);
                        }
                        else
                        {
                            oDtoMovimientos.IdTransaccion = null;
                        }
                        
                        oDtoMovimientos.IdEstacionamiento = Convert.ToInt64(_InfoMovimientoTable.Rows[i][2]);

                        string IdCancelacion = _InfoMovimientoTable.Rows[i][3].ToString();
                        if (IdCancelacion != string.Empty)
                        {
                            oDtoMovimientos.IdCancelacion = Convert.ToInt64(IdCancelacion);
                        }
                        else
                        {
                            oDtoMovimientos.IdCancelacion = null;
                        }


                        string IdCarga = _InfoMovimientoTable.Rows[i][4].ToString();
                        if (IdCarga != string.Empty)
                        {
                            oDtoMovimientos.IdCarga = Convert.ToInt64(IdCarga);
                        }
                        else
                        {
                            oDtoMovimientos.IdCarga = null;
                        }


                        string IdArqueo = _InfoMovimientoTable.Rows[i][5].ToString();
                        if (IdArqueo != string.Empty)
                        {
                            oDtoMovimientos.IdArqueo = Convert.ToInt64(IdArqueo);
                        }
                        else
                        {
                            oDtoMovimientos.IdArqueo = null;
                        }
                        
                        
                        oDtoMovimientos.IdModulo = _InfoMovimientoTable.Rows[i][6].ToString();
                        oDtoMovimientos.Parte = _InfoMovimientoTable.Rows[i][7].ToString();
                        oDtoMovimientos.Accion = _InfoMovimientoTable.Rows[i][8].ToString();
                        oDtoMovimientos.Denominacion = Convert.ToDouble(_InfoMovimientoTable.Rows[i][9]);
                        oDtoMovimientos.Cantidad = Convert.ToInt32(_InfoMovimientoTable.Rows[i][10]);
                        oDtoMovimientos.Valor = Convert.ToDouble(_InfoMovimientoTable.Rows[i][11]);
                        oDtoMovimientos.FechaMovimiento = Convert.ToDateTime(_InfoMovimientoTable.Rows[i][12]);
                        oDtoMovimientos.Sincronizacion = Convert.ToBoolean(_InfoMovimientoTable.Rows[i][13]);

                    }

                    oResultadoOperacion.EntidadDatos = oDtoMovimientos;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin registro en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionMovimiento(Movimientos oMovimiento, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_RegistrarMovimientosSincronizacionDataTable _RegistroMovimientoTable = new DataSetSincronizacion.P_RegistrarMovimientosSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarMovimientosSincronizacionTableAdapter _RegistroMovimientoAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarMovimientosSincronizacionTableAdapter();

            _RegistroMovimientoAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistroMovimientoTable.Constraints.Clear();

                if (_RegistroMovimientoAdapter.Fill(_RegistroMovimientoTable, oMovimiento.IdMovimiento, oMovimiento.IdTransaccion, oMovimiento.IdEstacionamiento, oMovimiento.IdCancelacion, oMovimiento.IdCarga, oMovimiento.IdArqueo, oMovimiento.IdModulo, oMovimiento.Parte, oMovimiento.Accion, oMovimiento.Denominacion, oMovimiento.Cantidad, oMovimiento.Valor, oMovimiento.FechaMovimiento, oMovimiento.Sincronizacion) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro Movimiento OK";

                    for (int i = 0; i < _RegistroMovimientoTable.Rows.Count; i++)
                    {
                        resultado = _RegistroMovimientoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando movimiento";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaSincronizacionMovimiento(long Movimiento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionMovimientoDataTable _UpdateMovimientoTable = new DataSetSincronizacion.P_ActualizaSincronizacionMovimientoDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionMovimientoTableAdapter _UpdateMovimientoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionMovimientoTableAdapter();


            try
            {
                _UpdateMovimientoTable.Constraints.Clear();

                if (_UpdateMovimientoAdapter.Fill(_UpdateMovimientoTable, Movimiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro movimiento OK";

                    for (int i = 0; i < _UpdateMovimientoTable.Rows.Count; i++)
                    {
                        resultado = _UpdateMovimientoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando movimiento";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }

        /////////ARQUEOS

        public ResultadoOperacion ObtenerArqueoSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoArqueos oDtoArqueos = new DtoArqueos();

            DataSetSincronizacion.P_DatosArqueoSincronizacionDataTable _InfoArqueoTable = new DataSetSincronizacion.P_DatosArqueoSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosArqueoSincronizacionTableAdapter _InfoArqueoAdapter = new DataSetSincronizacionTableAdapters.P_DatosArqueoSincronizacionTableAdapter();


            try
            {
                _InfoArqueoTable.Constraints.Clear();

                if (_InfoArqueoAdapter.Fill(_InfoArqueoTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Arqueo OK";

                    for (int i = 0; i < _InfoArqueoTable.Rows.Count; i++)
                    {
                        oDtoArqueos.IdArqueo = Convert.ToInt64(_InfoArqueoTable.Rows[i][0]);
                        oDtoArqueos.FechaInicio = Convert.ToDateTime(_InfoArqueoTable.Rows[i][1]);

                        string FECHAFIN = _InfoArqueoTable.Rows[i][2].ToString();

                        if (FECHAFIN != string.Empty)
                        {
                            oDtoArqueos.FechaFin = Convert.ToDateTime(FECHAFIN);
                        }
                        else 
                        {
                            oDtoArqueos.FechaFin = null;
                        }

                        string VALOR = _InfoArqueoTable.Rows[i][3].ToString();
                        if (VALOR != string.Empty)
                        {
                            oDtoArqueos.Valor = Convert.ToDouble(VALOR);
                        }
                        else 
                        {
                            oDtoArqueos.Valor = 0;
                        }
                        oDtoArqueos.IdUsuario = Convert.ToInt64(_InfoArqueoTable.Rows[i][4]);
                        oDtoArqueos.IdModulo = _InfoArqueoTable.Rows[i][5].ToString();
                        oDtoArqueos.IdEstacionamiento = Convert.ToInt64(_InfoArqueoTable.Rows[i][6]);

                        string CNTTrans = _InfoArqueoTable.Rows[i][7].ToString();

                        if (CNTTrans != string.Empty)
                        {
                            oDtoArqueos.CantTransacciones = Convert.ToInt32(CNTTrans);
                        }
                        else
                        {
                            oDtoArqueos.CantTransacciones = 0;
                        }

                        string Produ = _InfoArqueoTable.Rows[i][8].ToString();

                        if(Produ != string.Empty)
                        {
                            oDtoArqueos.Producido = Convert.ToDouble(Produ);                        
                        }
                        else
                        {
                            oDtoArqueos.Producido = 0;
                        }
                        oDtoArqueos.Tipo = _InfoArqueoTable.Rows[i][9].ToString();

                        string CONTEO = _InfoArqueoTable.Rows[i][10].ToString();
                        if (CONTEO != string.Empty)
                        {
                            oDtoArqueos.Conteo = Convert.ToDouble(CONTEO);
                        }
                        else
                        {
                            oDtoArqueos.Conteo = 0;
                        }
                        
                        oDtoArqueos.Sincronizacion = Convert.ToBoolean(_InfoArqueoTable.Rows[i][11]);

                    }

                    oResultadoOperacion.EntidadDatos = oDtoArqueos;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin registro en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionArqueo(Arqueos oArqueos, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_RegistrarArqueoSincronizacionDataTable _RegistroArqueoTable = new DataSetSincronizacion.P_RegistrarArqueoSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarArqueoSincronizacionTableAdapter _RegistroArqueoAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarArqueoSincronizacionTableAdapter();

            _RegistroArqueoAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistroArqueoTable.Constraints.Clear();

                if (_RegistroArqueoAdapter.Fill(_RegistroArqueoTable, oArqueos.IdArqueo, oArqueos.FechaInicio, oArqueos.FechaFin, oArqueos.Valor, oArqueos.IdUsuario, oArqueos.IdModulo, oArqueos.IdEstacionamiento, oArqueos.CantTransacciones, oArqueos.Producido, oArqueos.Tipo, oArqueos.Conteo, oArqueos.Sincronizacion) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro Arqueo OK";

                    for (int i = 0; i < _RegistroArqueoTable.Rows.Count; i++)
                    {
                        resultado = _RegistroArqueoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando Arqueo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaSincronizacionArqueo(long Arqueo)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionArqueoDataTable _UpdateArqueoTable = new DataSetSincronizacion.P_ActualizaSincronizacionArqueoDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionArqueoTableAdapter _UpdateArqueoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionArqueoTableAdapter();


            try
            {
                _UpdateArqueoTable.Constraints.Clear();

                if (_UpdateArqueoAdapter.Fill(_UpdateArqueoTable, Arqueo) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro Arqueo OK";

                    for (int i = 0; i < _UpdateArqueoTable.Rows.Count; i++)
                    {
                        resultado = _UpdateArqueoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando Arqueo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }


        /////////AUTORIZACIONES

        public ResultadoOperacion ObtenerAutorizacionesSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoAutorizado oDtoAutorizado = new DtoAutorizado();

            DataSetSincronizacion.P_DatosAutorizacionesSincronizacionDataTable _InfoAutorizacionTable = new DataSetSincronizacion.P_DatosAutorizacionesSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosAutorizacionesSincronizacionTableAdapter _InfoAutorizacionAdapter = new DataSetSincronizacionTableAdapters.P_DatosAutorizacionesSincronizacionTableAdapter();


            try
            {
                _InfoAutorizacionTable.Constraints.Clear();

                if (_InfoAutorizacionAdapter.Fill(_InfoAutorizacionTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Autorizacion OK";

                    for (int i = 0; i < _InfoAutorizacionTable.Rows.Count; i++)
                    {
                        oDtoAutorizado.IdAutorizacion = Convert.ToInt64(_InfoAutorizacionTable.Rows[i][0]);
                        oDtoAutorizado.IdEstacionamiento = Convert.ToInt64(_InfoAutorizacionTable.Rows[i][1]);
                        oDtoAutorizado.NombreAutorizacion = _InfoAutorizacionTable.Rows[i][3].ToString();
                        oDtoAutorizado.FechaInicial = Convert.ToDateTime(_InfoAutorizacionTable.Rows[i][4]);
                        oDtoAutorizado.FechaFinal = Convert.ToDateTime(_InfoAutorizacionTable.Rows[i][5]);
                        oDtoAutorizado.Estado = Convert.ToBoolean(_InfoAutorizacionTable.Rows[i][6]);
                        oDtoAutorizado.IdTipo = Convert.ToInt32(_InfoAutorizacionTable.Rows[i][8]);
                    }

                    oResultadoOperacion.EntidadDatos = oDtoAutorizado;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin Autorizacion en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionAutorizacion(Autorizado oAutorizado, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;
            string resultado2 = string.Empty;


            DataSetSincronizacion.P_RegistrarAutorizacionSincronizacionDataTable _RegistroAutorizacionTable = new DataSetSincronizacion.P_RegistrarAutorizacionSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarAutorizacionSincronizacionTableAdapter _RegistroAutorizacionAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarAutorizacionSincronizacionTableAdapter();

            _RegistroAutorizacionAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistroAutorizacionTable.Constraints.Clear();

                if (_RegistroAutorizacionAdapter.Fill(_RegistroAutorizacionTable,oAutorizado.IdAutorizacion,oAutorizado.IdEstacionamiento,oAutorizado.Regla,oAutorizado.NombreAutorizacion,oAutorizado.FechaInicial,oAutorizado.FechaFinal,oAutorizado.Estado,oAutorizado.Sincronizacion,oAutorizado.IdTipo) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro Autorizacion OK";

                    for (int i = 0; i < _RegistroAutorizacionTable.Rows.Count; i++)
                    {
                        resultado = _RegistroAutorizacionTable.Rows[i][0].ToString();
                        resultado2 = _RegistroAutorizacionTable.Rows[i][1].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado + ";" + resultado2;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando Autorizacion";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaSincronizacionAutorizacion(long IdAutorizacion, long IdEstacionamiento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionAutorizacionDataTable _UpdateArqueoTable = new DataSetSincronizacion.P_ActualizaSincronizacionAutorizacionDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionAutorizacionTableAdapter _UpdateArqueoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionAutorizacionTableAdapter();


            try
            {
                _UpdateArqueoTable.Constraints.Clear();

                if (_UpdateArqueoAdapter.Fill(_UpdateArqueoTable, IdAutorizacion, IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro Autorizacion OK";

                    for (int i = 0; i < _UpdateArqueoTable.Rows.Count; i++)
                    {
                        resultado = _UpdateArqueoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando Autorizacion";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }


        /////////PERSONASAUTORIZADAS

        public ResultadoOperacion ObtenerPersonasAutorizadasSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoAutorizado oDtoAutorizado = new DtoAutorizado();

            DataSetSincronizacion.P_DatosPersonasAutorizadasSincronizacionDataTable _InfoPersonasAutorizadasTable = new DataSetSincronizacion.P_DatosPersonasAutorizadasSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosPersonasAutorizadasSincronizacionTableAdapter _InfoPersonasAutorizadasAdapter = new DataSetSincronizacionTableAdapters.P_DatosPersonasAutorizadasSincronizacionTableAdapter();


            try
            {
                _InfoPersonasAutorizadasTable.Constraints.Clear();

                if (_InfoPersonasAutorizadasAdapter.Fill(_InfoPersonasAutorizadasTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Autorizacion OK";

                    for (int i = 0; i < _InfoPersonasAutorizadasTable.Rows.Count; i++)
                    {
                        oDtoAutorizado.Documento = _InfoPersonasAutorizadasTable.Rows[i][0].ToString();
                        oDtoAutorizado.IdAutorizacion = Convert.ToInt64(_InfoPersonasAutorizadasTable.Rows[i][1]);
                        oDtoAutorizado.IdEstacionamiento = Convert.ToInt64(_InfoPersonasAutorizadasTable.Rows[i][2]);
                        oDtoAutorizado.NombresAutorizado = _InfoPersonasAutorizadasTable.Rows[i][3].ToString();
                        oDtoAutorizado.IdTarjeta = _InfoPersonasAutorizadasTable.Rows[i][4].ToString();
                        oDtoAutorizado.FechaCreacion = Convert.ToDateTime(_InfoPersonasAutorizadasTable.Rows[i][5]);
                        oDtoAutorizado.DocumentoCreador = Convert.ToInt32(_InfoPersonasAutorizadasTable.Rows[i][6]);
                        oDtoAutorizado.Estado = Convert.ToBoolean(_InfoPersonasAutorizadasTable.Rows[i][7]);

                        string FechaIni = _InfoPersonasAutorizadasTable.Rows[i][9].ToString();
                        string FechaFin = _InfoPersonasAutorizadasTable.Rows[i][10].ToString();

                        if (FechaIni != string.Empty)
                        {
                            oDtoAutorizado.FechaInicial = Convert.ToDateTime(FechaIni);
                        }
                        else 
                        {
                            oDtoAutorizado.FechaInicial = null;
                        }

                        if (FechaFin != string.Empty)
                        {
                            oDtoAutorizado.FechaFinal = Convert.ToDateTime(FechaFin);
                        }
                        else 
                        {
                            oDtoAutorizado.FechaFinal = null;
                        }

                        oDtoAutorizado.Telefono = _InfoPersonasAutorizadasTable.Rows[i][11].ToString();
                        oDtoAutorizado.Email = _InfoPersonasAutorizadasTable.Rows[i][12].ToString();
                        oDtoAutorizado.Placa1 = _InfoPersonasAutorizadasTable.Rows[i][13].ToString();
                        oDtoAutorizado.Placa2 = _InfoPersonasAutorizadasTable.Rows[i][14].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = oDtoAutorizado;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin Autorizacion en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionPersonasAutorizadas(Autorizado oAutorizado, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;
            string resultado2 = string.Empty;


            DataSetSincronizacion.P_RegistrarPersonasAutorizadasSincronizacionDataTable _RegistroPersonasAutorizadosTable = new DataSetSincronizacion.P_RegistrarPersonasAutorizadasSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarPersonasAutorizadasSincronizacionTableAdapter _RegistroPersonasAutorizadosAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarPersonasAutorizadasSincronizacionTableAdapter();

            _RegistroPersonasAutorizadosAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistroPersonasAutorizadosTable.Constraints.Clear();

                if (_RegistroPersonasAutorizadosAdapter.Fill(_RegistroPersonasAutorizadosTable,oAutorizado.Documento,oAutorizado.IdAutorizacion,oAutorizado.IdEstacionamiento,oAutorizado.NombresAutorizado,oAutorizado.IdTarjeta,oAutorizado.FechaCreacion,oAutorizado.DocumentoCreador,oAutorizado.Estado,oAutorizado.Sincronizacion,oAutorizado.FechaInicial,oAutorizado.FechaFinal,oAutorizado.Telefono,oAutorizado.Email,oAutorizado.Placa1,oAutorizado.Placa2) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro Personas Autorizadas OK";

                    for (int i = 0; i < _RegistroPersonasAutorizadosTable.Rows.Count; i++)
                    {
                        resultado = _RegistroPersonasAutorizadosTable.Rows[i][0].ToString();
                        resultado2 = _RegistroPersonasAutorizadosTable.Rows[i][1].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado + ";" + resultado2;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando personas autorizadas";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaPersonasSincronizacionAutorizacion(string Documento, long IdEstacionamiento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionPersonasAutorizadasDataTable _UpdateArqueoTable = new DataSetSincronizacion.P_ActualizaSincronizacionPersonasAutorizadasDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionPersonasAutorizadasTableAdapter _UpdateArqueoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionPersonasAutorizadasTableAdapter();


            try
            {
                _UpdateArqueoTable.Constraints.Clear();

                if (_UpdateArqueoAdapter.Fill(_UpdateArqueoTable, Documento, IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro Persona Autorizada OK";

                    for (int i = 0; i < _UpdateArqueoTable.Rows.Count; i++)
                    {
                        resultado = _UpdateArqueoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando Personas Autorizadas";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ValidarExistenciaPersonasAutorizadasSincronizacionCloud(string Documento, long IdEstacionamiento, string sConexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoAutorizado oDtoAutorizado = new DtoAutorizado();

            DataSetSincronizacion.P_ValidarDatosPersonasAutorizadasDataTable _InfoInfoPersonasTable = new DataSetSincronizacion.P_ValidarDatosPersonasAutorizadasDataTable();
            DataSetSincronizacionTableAdapters.P_ValidarDatosPersonasAutorizadasTableAdapter _InfoInfoPersonasAdapter = new DataSetSincronizacionTableAdapters.P_ValidarDatosPersonasAutorizadasTableAdapter();

            _InfoInfoPersonasAdapter.Connection = new System.Data.SqlClient.SqlConnection(sConexion);

            try
            {
                _InfoInfoPersonasTable.Constraints.Clear();

                if (_InfoInfoPersonasAdapter.Fill(_InfoInfoPersonasTable, Documento, IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Consignacion OK";

                    for (int i = 0; i < _InfoInfoPersonasTable.Rows.Count; i++)
                    {
                        oDtoAutorizado.Documento = _InfoInfoPersonasTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = oDtoAutorizado;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin Consignacion en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaPersonasAutorizadasCloud(Autorizado oAutorizado,string sConexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizarPersonasAutorizadasRedDataTable _UpdateArqueoTable = new DataSetSincronizacion.P_ActualizarPersonasAutorizadasRedDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizarPersonasAutorizadasRedTableAdapter _UpdateArqueoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizarPersonasAutorizadasRedTableAdapter();

            _UpdateArqueoAdapter.Connection = new System.Data.SqlClient.SqlConnection(sConexion);

            try
            {
                _UpdateArqueoTable.Constraints.Clear();

                if (_UpdateArqueoAdapter.Fill(_UpdateArqueoTable, oAutorizado.Documento, oAutorizado.IdAutorizacion, oAutorizado.IdEstacionamiento, oAutorizado.NombresAutorizado, oAutorizado.IdTarjeta, oAutorizado.FechaCreacion, oAutorizado.DocumentoCreador, oAutorizado.Estado, oAutorizado.Sincronizacion, oAutorizado.FechaInicial, oAutorizado.FechaFinal, oAutorizado.Telefono, oAutorizado.Email, oAutorizado.Placa1, oAutorizado.Placa2) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro FacturasManuales  OK";

                    for (int i = 0; i < _UpdateArqueoTable.Rows.Count; i++)
                    {
                        resultado = _UpdateArqueoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando FacturasManuales";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }

        /////////CONSIGNACION

        public ResultadoOperacion ObtenerConsignacionSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoConsignacion oDtoConsignacion = new DtoConsignacion();

            DataSetSincronizacion.P_DatosConsignacionSincronizacionDataTable _InfoConsignacionTable = new DataSetSincronizacion.P_DatosConsignacionSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosConsignacionSincronizacionTableAdapter _InfoConsignacionAdapter = new DataSetSincronizacionTableAdapters.P_DatosConsignacionSincronizacionTableAdapter();


            try
            {
                _InfoConsignacionTable.Constraints.Clear();

                if (_InfoConsignacionAdapter.Fill(_InfoConsignacionTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Consignacion OK";

                    for (int i = 0; i < _InfoConsignacionTable.Rows.Count; i++)
                    {
                        oDtoConsignacion.IdConsignacion = Convert.ToInt64(_InfoConsignacionTable.Rows[i][0]);
                        oDtoConsignacion.IdEstacionamiento = Convert.ToInt64(_InfoConsignacionTable.Rows[i][1]);
                        oDtoConsignacion.FechaConsignacion = Convert.ToDateTime(_InfoConsignacionTable.Rows[i][2]);
                        oDtoConsignacion.Valor = Convert.ToDouble(_InfoConsignacionTable.Rows[i][3]);
                        oDtoConsignacion.Referencia = _InfoConsignacionTable.Rows[i][4].ToString();
                        oDtoConsignacion.DocumentoUsuario = Convert.ToInt64(_InfoConsignacionTable.Rows[i][5]);
                    }

                    oResultadoOperacion.EntidadDatos = oDtoConsignacion;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin Consignacion en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.EntidadDatos = oDtoConsignacion;
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionConsignacion(Consignacion oConsignacion, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;
            string resultado2 = string.Empty;


            DataSetSincronizacion.P_RegistrarConsignacionSincronizacionDataTable _RegistrarConsignacionTable = new DataSetSincronizacion.P_RegistrarConsignacionSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarConsignacionSincronizacionTableAdapter _RegistrarConsignacionAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarConsignacionSincronizacionTableAdapter();

            _RegistrarConsignacionAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistrarConsignacionTable.Constraints.Clear();

                if (_RegistrarConsignacionAdapter.Fill(_RegistrarConsignacionTable, oConsignacion.IdEstacionamiento, oConsignacion.FechaConsignacion, oConsignacion.Valor, oConsignacion.Referencia, oConsignacion.DocumentoUsuario) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro consignacion OK";

                    for (int i = 0; i < _RegistrarConsignacionTable.Rows.Count; i++)
                    {
                        resultado = _RegistrarConsignacionTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando consignacion";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaConsignacionSincronizacion(long IdConsignacion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionConsignacionDataTable _UpdateArqueoTable = new DataSetSincronizacion.P_ActualizaSincronizacionConsignacionDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionConsignacionTableAdapter _UpdateArqueoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionConsignacionTableAdapter();


            try
            {
                _UpdateArqueoTable.Constraints.Clear();

                if (_UpdateArqueoAdapter.Fill(_UpdateArqueoTable, IdConsignacion) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro Consignacion  OK";

                    for (int i = 0; i < _UpdateArqueoTable.Rows.Count; i++)
                    {
                        resultado = _UpdateArqueoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando Consignacion";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }


        /////////FACTURAS MANUALES

        public ResultadoOperacion ObtenerFacturasManualesSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoFacturasManuales oDtoFacturasManuales = new DtoFacturasManuales();

            DataSetSincronizacion.P_DatosFacturasManualesSincronizacionDataTable _InfoFacturasManualesTable = new DataSetSincronizacion.P_DatosFacturasManualesSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosFacturasManualesSincronizacionTableAdapter _InfoFacturasManualesAdapter = new DataSetSincronizacionTableAdapters.P_DatosFacturasManualesSincronizacionTableAdapter();


            try
            {
                _InfoFacturasManualesTable.Constraints.Clear();

                if (_InfoFacturasManualesAdapter.Fill(_InfoFacturasManualesTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Consignacion OK";

                    for (int i = 0; i < _InfoFacturasManualesTable.Rows.Count; i++)
                    {
                        oDtoFacturasManuales.IdModulo = _InfoFacturasManualesTable.Rows[i][0].ToString();
                        oDtoFacturasManuales.IdEstacionamiento = Convert.ToInt64(_InfoFacturasManualesTable.Rows[i][1]);
                        oDtoFacturasManuales.FechaPago = Convert.ToDateTime(_InfoFacturasManualesTable.Rows[i][2]);
                        oDtoFacturasManuales.Subtotal = Convert.ToDouble(_InfoFacturasManualesTable.Rows[i][3]);
                        oDtoFacturasManuales.Iva = Convert.ToDouble(_InfoFacturasManualesTable.Rows[i][4]);
                        oDtoFacturasManuales.Total = Convert.ToDouble(_InfoFacturasManualesTable.Rows[i][5]);
                        oDtoFacturasManuales.Prefijo = _InfoFacturasManualesTable.Rows[i][6].ToString();
                        oDtoFacturasManuales.NumeroFactura = _InfoFacturasManualesTable.Rows[i][7].ToString();
                        oDtoFacturasManuales.IdTipoVehiculo = Convert.ToInt32(_InfoFacturasManualesTable.Rows[i][8]);
                        oDtoFacturasManuales.DocumentoUsuario = Convert.ToInt64(_InfoFacturasManualesTable.Rows[i][9]);
                    }

                    oResultadoOperacion.EntidadDatos = oDtoFacturasManuales;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin Consignacion en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionFacturasManuales(FacturasManuales oFacturasManuales, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;
            string resultado2 = string.Empty;


            DataSetSincronizacion.P_RegistrarFacturasManualesSincronizacionDataTable _RegistrarFacturasManualesTable = new DataSetSincronizacion.P_RegistrarFacturasManualesSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarFacturasManualesSincronizacionTableAdapter _RegistrarFacturasManualesAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarFacturasManualesSincronizacionTableAdapter();

            _RegistrarFacturasManualesAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistrarFacturasManualesTable.Constraints.Clear();

                if (_RegistrarFacturasManualesAdapter.Fill(_RegistrarFacturasManualesTable, oFacturasManuales.IdModulo, oFacturasManuales.IdEstacionamiento, oFacturasManuales.FechaPago, oFacturasManuales.Subtotal, oFacturasManuales.Iva,oFacturasManuales.Total,oFacturasManuales.Prefijo,oFacturasManuales.NumeroFactura, oFacturasManuales.IdTipoVehiculo, oFacturasManuales.DocumentoUsuario) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro FacturasManuales OK";

                    for (int i = 0; i < _RegistrarFacturasManualesTable.Rows.Count; i++)
                    {
                        resultado = _RegistrarFacturasManualesTable.Rows[i][0].ToString();
                        resultado2 = _RegistrarFacturasManualesTable.Rows[i][1].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado + ";" + resultado2;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando FacturasManuales";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaFacturasManualesSincronizacion(long IdEstacionamiento, string NumeroFactura)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionFacturasManualesDataTable _UpdateArqueoTable = new DataSetSincronizacion.P_ActualizaSincronizacionFacturasManualesDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionFacturasManualesTableAdapter _UpdateArqueoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionFacturasManualesTableAdapter();


            try
            {
                _UpdateArqueoTable.Constraints.Clear();

                if (_UpdateArqueoAdapter.Fill(_UpdateArqueoTable,IdEstacionamiento,NumeroFactura) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro FacturasManuales  OK";

                    for (int i = 0; i < _UpdateArqueoTable.Rows.Count; i++)
                    {
                        resultado = _UpdateArqueoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando FacturasManuales";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }


        /////////CORTESIAS

        public ResultadoOperacion ObtenerCortesiasSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoCortesias oDtoCortesias = new DtoCortesias();

            DataSetSincronizacion.P_DatosCortesiasSincronizacionDataTable _InfoCortesiasTable = new DataSetSincronizacion.P_DatosCortesiasSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosCortesiasSincronizacionTableAdapter _InfoCortesiasAdapter = new DataSetSincronizacionTableAdapters.P_DatosCortesiasSincronizacionTableAdapter();


            try
            {
                _InfoCortesiasTable.Constraints.Clear();

                if (_InfoCortesiasAdapter.Fill(_InfoCortesiasTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info cortesias OK";

                    for (int i = 0; i < _InfoCortesiasTable.Rows.Count; i++)
                    {
                        oDtoCortesias.IdTransaccion = Convert.ToInt64(_InfoCortesiasTable.Rows[i][0]);
                        oDtoCortesias.IdEstacionamiento = Convert.ToInt64(_InfoCortesiasTable.Rows[i][1]);
                        oDtoCortesias.FechaCortesia = Convert.ToDateTime(_InfoCortesiasTable.Rows[i][2]);
                        oDtoCortesias.DocumentoUsuario = Convert.ToInt64(_InfoCortesiasTable.Rows[i][3]);
                        oDtoCortesias.IdMotivo = Convert.ToInt64(_InfoCortesiasTable.Rows[i][4]);
                        oDtoCortesias.Observacion = _InfoCortesiasTable.Rows[i][5].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = oDtoCortesias;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin cortesias en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionCortesias(Cortesias oCortesias, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;
            string resultado2 = string.Empty;


            DataSetSincronizacion.P_RegistrarCortesiasSincronizacionDataTable _RegistrarCortesiasTable = new DataSetSincronizacion.P_RegistrarCortesiasSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarCortesiasSincronizacionTableAdapter _RegistrarCortesiasAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarCortesiasSincronizacionTableAdapter();

            _RegistrarCortesiasAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistrarCortesiasTable.Constraints.Clear();

                if (_RegistrarCortesiasAdapter.Fill(_RegistrarCortesiasTable, oCortesias.IdTransaccion, oCortesias.IdEstacionamiento, oCortesias.FechaCortesia,oCortesias.DocumentoUsuario, oCortesias.IdMotivo, oCortesias.Observacion) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro cortesias OK";

                    for (int i = 0; i < _RegistrarCortesiasTable.Rows.Count; i++)
                    {
                        resultado = _RegistrarCortesiasTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado + ";" + resultado2;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando cortesias";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaCortesiasSincronizacion(long IdTransaccion, long IdEstacionamiento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionCortesiaDataTable _UpdateCortesiasTable = new DataSetSincronizacion.P_ActualizaSincronizacionCortesiaDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionCortesiaTableAdapter _UpdateCortesiasAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionCortesiaTableAdapter();


            try
            {
                _UpdateCortesiasTable.Constraints.Clear();

                if (_UpdateCortesiasAdapter.Fill(_UpdateCortesiasTable, IdTransaccion,IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro actualizado  OK";

                    for (int i = 0; i < _UpdateCortesiasTable.Rows.Count; i++)
                    {
                        resultado = _UpdateCortesiasTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error actualizado cortesias";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }


        /////////CONVENIOS

        public ResultadoOperacion ObtenerConveniosSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoConvenios oDtoConvenios = new DtoConvenios();

            DataSetSincronizacion.P_DatosConveniosSincronizacionDataTable _InfoConveniosTable = new DataSetSincronizacion.P_DatosConveniosSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosConveniosSincronizacionTableAdapter _InfoConveniosAdapter = new DataSetSincronizacionTableAdapters.P_DatosConveniosSincronizacionTableAdapter();


            try
            {
                _InfoConveniosTable.Constraints.Clear();

                if (_InfoConveniosAdapter.Fill(_InfoConveniosTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Consignacion OK";

                    for (int i = 0; i < _InfoConveniosTable.Rows.Count; i++)
                    {
                        oDtoConvenios.IdConvenio = Convert.ToInt64(_InfoConveniosTable.Rows[i][0]);
                        oDtoConvenios.Nombre = _InfoConveniosTable.Rows[i][1].ToString();
                        oDtoConvenios.Descripcion = _InfoConveniosTable.Rows[i][2].ToString();
                        oDtoConvenios.IdEstacionamiento = Convert.ToInt64(_InfoConveniosTable.Rows[i][3]);
                        oDtoConvenios.FechaInicial = Convert.ToDateTime(_InfoConveniosTable.Rows[i][4]);
                        oDtoConvenios.FechaFinal = Convert.ToDateTime(_InfoConveniosTable.Rows[i][5]);
                        oDtoConvenios.Estado =  Convert.ToBoolean(_InfoConveniosTable.Rows[i][6]);
                    }

                    oResultadoOperacion.EntidadDatos = oDtoConvenios;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin Consignacion en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionConvenios(Convenios oConvenios, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;
            string resultado2 = string.Empty;


            DataSetSincronizacion.P_RegistrarConveniosSincronizacionDataTable _RegistrarConveniosTable = new DataSetSincronizacion.P_RegistrarConveniosSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarConveniosSincronizacionTableAdapter _RegistrarConveniosAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarConveniosSincronizacionTableAdapter();

            _RegistrarConveniosAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistrarConveniosTable.Constraints.Clear();

                if (_RegistrarConveniosAdapter.Fill(_RegistrarConveniosTable, oConvenios.IdConvenio, oConvenios.Nombre, oConvenios.Descripcion,oConvenios.IdEstacionamiento, oConvenios.FechaInicial, oConvenios.FechaFinal, oConvenios.Estado) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro convenios OK";

                    for (int i = 0; i < _RegistrarConveniosTable.Rows.Count; i++)
                    {
                        resultado = _RegistrarConveniosTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado + ";" + resultado2;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando convenios";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaConveniosSincronizacion(long IdEstacionamiento, long IdConvenio)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionConvenioDataTable _UpdateConvenioTable = new DataSetSincronizacion.P_ActualizaSincronizacionConvenioDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionConvenioTableAdapter _UpdateConvenioAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionConvenioTableAdapter();


            try
            {
                _UpdateConvenioTable.Constraints.Clear();

                if (_UpdateConvenioAdapter.Fill(_UpdateConvenioTable, IdConvenio, IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro convenio  OK";

                    for (int i = 0; i < _UpdateConvenioTable.Rows.Count; i++)
                    {
                        resultado = _UpdateConvenioTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando convenio";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }


        ///////TALANQUERA

        public ResultadoOperacion ObtenerEventosSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoTalanquera oDtoTalanquera = new DtoTalanquera();

            DataSetSincronizacion.P_DatosEventoDispositivoSincronizacionDataTable _InfoEventoTable = new DataSetSincronizacion.P_DatosEventoDispositivoSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosEventoDispositivoSincronizacionTableAdapter _InfoEventoAdapter = new DataSetSincronizacionTableAdapters.P_DatosEventoDispositivoSincronizacionTableAdapter();


            try
            {
                _InfoEventoTable.Constraints.Clear();

                if (_InfoEventoAdapter.Fill(_InfoEventoTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info evento dispositivo OK";

                    for (int i = 0; i < _InfoEventoTable.Rows.Count; i++)
                    {
                        oDtoTalanquera.IdEventoDispositivo = Convert.ToInt64(_InfoEventoTable.Rows[i][0]);
                        oDtoTalanquera.IdEstacionamiento = Convert.ToInt64(_InfoEventoTable.Rows[i][1]);
                        oDtoTalanquera.IdModulo = _InfoEventoTable.Rows[i][2].ToString();
                        oDtoTalanquera.Usuario = _InfoEventoTable.Rows[i][3].ToString();
                        oDtoTalanquera.Observacion = _InfoEventoTable.Rows[i][4].ToString();
                        oDtoTalanquera.FechaHora = Convert.ToDateTime(_InfoEventoTable.Rows[i][5]);
                        oDtoTalanquera.Estado = Convert.ToBoolean(_InfoEventoTable.Rows[i][6]);
                    }

                    oResultadoOperacion.EntidadDatos = oDtoTalanquera;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin evento dispositivo en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionEventos(Talanquera oTalanquera, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;
            string resultado2 = string.Empty;


            DataSetSincronizacion.P_RegistrarEventoDispositivoSincronizacionDataTable _RegistrarEventoDispositivoTable = new DataSetSincronizacion.P_RegistrarEventoDispositivoSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarEventoDispositivoSincronizacionTableAdapter _RegistrarEventoDispositivoAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarEventoDispositivoSincronizacionTableAdapter();

            _RegistrarEventoDispositivoAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistrarEventoDispositivoTable.Constraints.Clear();

                if (_RegistrarEventoDispositivoAdapter.Fill(_RegistrarEventoDispositivoTable, oTalanquera.IdEstacionamiento, oTalanquera.IdModulo, oTalanquera.Usuario, oTalanquera.Observacion, oTalanquera.FechaHora, oTalanquera.Estado) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro EventoDispositivo OK";

                    for (int i = 0; i < _RegistrarEventoDispositivoTable.Rows.Count; i++)
                    {
                        resultado = _RegistrarEventoDispositivoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado + ";" + resultado2;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando EventoDispositivo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaEventoDispositivoSincronizacion(long IdEvento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaSincronizacionEventoDispositivoDataTable _UpdateEventoTable = new DataSetSincronizacion.P_ActualizaSincronizacionEventoDispositivoDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionEventoDispositivoTableAdapter _UpdateEventoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaSincronizacionEventoDispositivoTableAdapter();


            try
            {
                _UpdateEventoTable.Constraints.Clear();

                if (_UpdateEventoAdapter.Fill(_UpdateEventoTable, IdEvento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro EventoDispositivo  OK";

                    for (int i = 0; i < _UpdateEventoTable.Rows.Count; i++)
                    {
                        resultado = _UpdateEventoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando EventoDispositivo";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }


        /////////VALIDACION RED

        public ResultadoOperacion ObtenerDocumentoPermisosEstacionamientoSincronizacion(long IdEstacionamiento,string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoAutorizado oDtoAutorizado = new DtoAutorizado();

            DataSetSincronizacion.P_ObtenerInfoDocumentoPermisosPersonasEstacionamientosDataTable _InfoPermisosPersonasTable = new DataSetSincronizacion.P_ObtenerInfoDocumentoPermisosPersonasEstacionamientosDataTable();
            DataSetSincronizacionTableAdapters.P_ObtenerInfoDocumentoPermisosPersonasEstacionamientosTableAdapter _InfoPermisosPersonasAdapter = new DataSetSincronizacionTableAdapters.P_ObtenerInfoDocumentoPermisosPersonasEstacionamientosTableAdapter();

            _InfoPermisosPersonasAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);

            try
            {
                _InfoPermisosPersonasTable.Constraints.Clear();

                if (_InfoPermisosPersonasAdapter.Fill(_InfoPermisosPersonasTable,IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Consignacion OK";

                    for (int i = 0; i < _InfoPermisosPersonasTable.Rows.Count; i++)
                    {
                        oDtoAutorizado.Documento = _InfoPermisosPersonasTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = oDtoAutorizado;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin Consignacion en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ObtenerInfoPersonasAutorizadasSincronizacion(string Documento,long IdEstacionamiento,string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoAutorizado oDtoAutorizado = new DtoAutorizado();

            DataSetSincronizacion.P_ObtenerDatosPersonasAutorizadasDataTable _InfoInfoPersonasTable = new DataSetSincronizacion.P_ObtenerDatosPersonasAutorizadasDataTable();
            DataSetSincronizacionTableAdapters.P_ObtenerDatosPersonasAutorizadasTableAdapter _InfoInfoPersonasAdapter = new DataSetSincronizacionTableAdapters.P_ObtenerDatosPersonasAutorizadasTableAdapter();

            _InfoInfoPersonasAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);

            try
            {
                _InfoInfoPersonasTable.Constraints.Clear();

                if (_InfoInfoPersonasAdapter.Fill(_InfoInfoPersonasTable, Documento,IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Consignacion OK";

                    for (int i = 0; i < _InfoInfoPersonasTable.Rows.Count; i++)
                    {
                        oDtoAutorizado.Documento = _InfoInfoPersonasTable.Rows[i][0].ToString();
                        oDtoAutorizado.IdAutorizacion = Convert.ToInt64(_InfoInfoPersonasTable.Rows[i][1]);
                        oDtoAutorizado.IdEstacionamiento = Convert.ToInt64(_InfoInfoPersonasTable.Rows[i][2]);
                        oDtoAutorizado.NombresAutorizado = _InfoInfoPersonasTable.Rows[i][3].ToString();
                        oDtoAutorizado.IdTarjeta = _InfoInfoPersonasTable.Rows[i][4].ToString();
                        oDtoAutorizado.FechaCreacion = Convert.ToDateTime(_InfoInfoPersonasTable.Rows[i][5]);
                        oDtoAutorizado.DocumentoCreador = Convert.ToInt64(_InfoInfoPersonasTable.Rows[i][6]);
                        oDtoAutorizado.Estado = Convert.ToBoolean(_InfoInfoPersonasTable.Rows[i][7]);
                        //oDtoAutorizado.SINCR = _InfoInfoPersonasTable.Rows[i][8].ToString();
                        string fECHSIni = _InfoInfoPersonasTable.Rows[i][9].ToString();

                        if (fECHSIni != string.Empty)
                        {
                            oDtoAutorizado.FechaInicial = Convert.ToDateTime(fECHSIni);
                        }
                        else
                        {
                            oDtoAutorizado.FechaInicial = null;
                        }

                        string fECHSFin = _InfoInfoPersonasTable.Rows[i][10].ToString();

                        if (fECHSFin != string.Empty)
                        {
                            oDtoAutorizado.FechaFinal = Convert.ToDateTime(fECHSFin);
                        }
                        else
                        {
                            oDtoAutorizado.FechaFinal = null;
                        }
                        
                        oDtoAutorizado.Telefono = _InfoInfoPersonasTable.Rows[i][11].ToString();
                        oDtoAutorizado.Email = _InfoInfoPersonasTable.Rows[i][12].ToString();
                        oDtoAutorizado.Placa1 = _InfoInfoPersonasTable.Rows[i][13].ToString();
                        oDtoAutorizado.Placa2 = _InfoInfoPersonasTable.Rows[i][14].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = oDtoAutorizado;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin Consignacion en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ValidarExistenciaPersonasAutorizadasSincronizacion(string Documento, long IdEstacionamiento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoAutorizado oDtoAutorizado = new DtoAutorizado();

            DataSetSincronizacion.P_ValidarDatosPersonasAutorizadasDataTable _InfoInfoPersonasTable = new DataSetSincronizacion.P_ValidarDatosPersonasAutorizadasDataTable();
            DataSetSincronizacionTableAdapters.P_ValidarDatosPersonasAutorizadasTableAdapter _InfoInfoPersonasAdapter = new DataSetSincronizacionTableAdapters.P_ValidarDatosPersonasAutorizadasTableAdapter();


            try
            {
                _InfoInfoPersonasTable.Constraints.Clear();

                if (_InfoInfoPersonasAdapter.Fill(_InfoInfoPersonasTable, Documento, IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Consignacion OK";

                    for (int i = 0; i < _InfoInfoPersonasTable.Rows.Count; i++)
                    {
                        oDtoAutorizado.Documento = _InfoInfoPersonasTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = oDtoAutorizado;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin Consignacion en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarPersonasAutoRed(Autorizado oAutorizado)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;
            string resultado2 = string.Empty;


            DataSetSincronizacion.P_RegistrarPersonasAutorizadasRedDataTable _RegistroAutorizacionTable = new DataSetSincronizacion.P_RegistrarPersonasAutorizadasRedDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarPersonasAutorizadasRedTableAdapter _RegistroAutorizacionAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarPersonasAutorizadasRedTableAdapter();


            try
            {
                _RegistroAutorizacionTable.Constraints.Clear();

                if (_RegistroAutorizacionAdapter.Fill(_RegistroAutorizacionTable,oAutorizado.Documento, oAutorizado.IdAutorizacion, oAutorizado.IdEstacionamiento,oAutorizado.NombresAutorizado,oAutorizado.IdTarjeta,oAutorizado.FechaCreacion,oAutorizado.DocumentoCreador,oAutorizado.Estado,oAutorizado.Sincronizacion,oAutorizado.FechaInicial,oAutorizado.FechaFinal,oAutorizado.Telefono,oAutorizado.Email,oAutorizado.Placa1,oAutorizado.Placa2) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro Autorizacion OK";

                    for (int i = 0; i < _RegistroAutorizacionTable.Rows.Count; i++)
                    {
                        resultado = _RegistroAutorizacionTable.Rows[i][0].ToString();
                        resultado2 = _RegistroAutorizacionTable.Rows[i][1].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado + ";" + resultado2;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando Autorizacion";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaPersonasAutorizadasRed(Autorizado oAutorizado)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizarPersonasAutorizadasRedDataTable _UpdateArqueoTable = new DataSetSincronizacion.P_ActualizarPersonasAutorizadasRedDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizarPersonasAutorizadasRedTableAdapter _UpdateArqueoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizarPersonasAutorizadasRedTableAdapter();


            try
            {
                _UpdateArqueoTable.Constraints.Clear();

                if (_UpdateArqueoAdapter.Fill(_UpdateArqueoTable,oAutorizado.Documento, oAutorizado.IdAutorizacion, oAutorizado.IdEstacionamiento,oAutorizado.NombresAutorizado,oAutorizado.IdTarjeta,oAutorizado.FechaCreacion,oAutorizado.DocumentoCreador,oAutorizado.Estado,oAutorizado.Sincronizacion,oAutorizado.FechaInicial,oAutorizado.FechaFinal,oAutorizado.Telefono,oAutorizado.Email,oAutorizado.Placa1,oAutorizado.Placa2) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro FacturasManuales  OK";

                    for (int i = 0; i < _UpdateArqueoTable.Rows.Count; i++)
                    {
                        resultado = _UpdateArqueoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando FacturasManuales";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaPersonasAutorizadasRedCloud(string Documento, long IdEstacionamiento, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizarPermisoEstacionamientoPersonasDataTable _UpdateAutoTable = new DataSetSincronizacion.P_ActualizarPermisoEstacionamientoPersonasDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizarPermisoEstacionamientoPersonasTableAdapter _UpdateAutoAdapter = new DataSetSincronizacionTableAdapters.P_ActualizarPermisoEstacionamientoPersonasTableAdapter();

            _UpdateAutoAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);

            try
            {
                _UpdateAutoTable.Constraints.Clear();

                if (_UpdateAutoAdapter.Fill(_UpdateAutoTable, Documento, IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro FacturasManuales  OK";

                    for (int i = 0; i < _UpdateAutoTable.Rows.Count; i++)
                    {
                        resultado = _UpdateAutoTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando FacturasManuales";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }

        /////////USUARIOS

        public ResultadoOperacion ObtenerUsuariosSincronizacion()
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoUsuario oDtoUsuario = new DtoUsuario();

            DataSetSincronizacion.P_DatosUsuariosSincronizacionDataTable _InfoConveniosTable = new DataSetSincronizacion.P_DatosUsuariosSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_DatosUsuariosSincronizacionTableAdapter _InfoConveniosAdapter = new DataSetSincronizacionTableAdapters.P_DatosUsuariosSincronizacionTableAdapter();


            try
            {
                _InfoConveniosTable.Constraints.Clear();

                if (_InfoConveniosAdapter.Fill(_InfoConveniosTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info Consignacion OK";

                    for (int i = 0; i < _InfoConveniosTable.Rows.Count; i++)
                    {
                        oDtoUsuario.Documento = Convert.ToInt64(_InfoConveniosTable.Rows[i][0]);
                        oDtoUsuario.Nombres = _InfoConveniosTable.Rows[i][1].ToString();
                        oDtoUsuario.Apellidos = _InfoConveniosTable.Rows[i][2].ToString();
                        oDtoUsuario.Usuario = _InfoConveniosTable.Rows[i][3].ToString();
                        oDtoUsuario.Contraseña = _InfoConveniosTable.Rows[i][4].ToString();
                        oDtoUsuario.Cargo = _InfoConveniosTable.Rows[i][5].ToString();
                        oDtoUsuario.UsuarioCreador = _InfoConveniosTable.Rows[i][6].ToString();
                        oDtoUsuario.FechaCreacion = Convert.ToDateTime(_InfoConveniosTable.Rows[i][7]);
                        oDtoUsuario.IdTarjeta = _InfoConveniosTable.Rows[i][8].ToString();
                        oDtoUsuario.Estado = Convert.ToBoolean(_InfoConveniosTable.Rows[i][9]);
                    }

                    oResultadoOperacion.EntidadDatos = oDtoUsuario;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Módulo sin Consignacion en base de datos.";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                oResultadoOperacion.Mensaje = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion RegistrarSincronizacionUsuarios(Usuarios oUsuarios, string Conexion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;
            string resultado2 = string.Empty;


            DataSetSincronizacion.P_RegistrarUsuariosSincronizacionDataTable _RegistrarConveniosTable = new DataSetSincronizacion.P_RegistrarUsuariosSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_RegistrarUsuariosSincronizacionTableAdapter _RegistrarConveniosAdapter = new DataSetSincronizacionTableAdapters.P_RegistrarUsuariosSincronizacionTableAdapter();

            _RegistrarConveniosAdapter.Connection = new System.Data.SqlClient.SqlConnection(Conexion);


            try
            {
                _RegistrarConveniosTable.Constraints.Clear();

                if (_RegistrarConveniosAdapter.Fill(_RegistrarConveniosTable, oUsuarios.Documento, oUsuarios.Nombres, oUsuarios.Apellidos, oUsuarios.Usuario, oUsuarios.Contraseña, oUsuarios.Cargo, oUsuarios.UsuarioCreador,oUsuarios.FechaCreacion,oUsuarios.IdTarjeta,oUsuarios.Estado) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro usuarios OK";

                    for (int i = 0; i < _RegistrarConveniosTable.Rows.Count; i++)
                    {
                        resultado = _RegistrarConveniosTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado + ";" + resultado2;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando convenios";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }
        public ResultadoOperacion ActualizaUsuariosSincronizacion(long Documento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            string resultado = string.Empty;



            DataSetSincronizacion.P_ActualizaUsuariosSincronizacionDataTable _UpdateConvenioTable = new DataSetSincronizacion.P_ActualizaUsuariosSincronizacionDataTable();
            DataSetSincronizacionTableAdapters.P_ActualizaUsuariosSincronizacionTableAdapter _UpdateConvenioAdapter = new DataSetSincronizacionTableAdapters.P_ActualizaUsuariosSincronizacionTableAdapter();


            try
            {
                _UpdateConvenioTable.Constraints.Clear();

                if (_UpdateConvenioAdapter.Fill(_UpdateConvenioTable, Documento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Registro usuario  OK";

                    for (int i = 0; i < _UpdateConvenioTable.Rows.Count; i++)
                    {
                        resultado = _UpdateConvenioTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = resultado;
                }
                else
                {

                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error registrando convenio";
                }
            }
            catch (Exception ex)
            {
                // Generar LOG DataBase Exception
                string exMessage = ex.ToString();
                oResultadoOperacion.oEstado = TipoRespuesta.Error;
            }

            return oResultadoOperacion;
        }

    }

}
