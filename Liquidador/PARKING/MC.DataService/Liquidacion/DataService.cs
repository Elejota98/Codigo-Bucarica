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
        public ResultadoOperacion ObtenerDatosLiquidacion(long IdEstacionamiento, long IdTipoPago, long IdTipoVehiculo, long IdConvenio, long Evento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoLiquidacion oDtoLiquidacion = new DtoLiquidacion();

            DataSetLiquidacion.P_ObtenerDatosLiquidacionDataTable _InfoLiquidacionTable = new DataSetLiquidacion.P_ObtenerDatosLiquidacionDataTable();
            DataSetLiquidacionTableAdapters.P_ObtenerDatosLiquidacionTableAdapter _InfoLiquidacionAdapter = new DataSetLiquidacionTableAdapters.P_ObtenerDatosLiquidacionTableAdapter();

            try
            {
                _InfoLiquidacionTable.Constraints.Clear();

                if (_InfoLiquidacionAdapter.Fill(_InfoLiquidacionTable, IdEstacionamiento, IdTipoPago, IdTipoVehiculo) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info datos liquidacion OK";

                    for (int i = 0; i < _InfoLiquidacionTable.Rows.Count; i++)
                    {

                        string IdConve = _InfoLiquidacionTable.Rows[i][7].ToString();

                        if (IdConve != string.Empty)
                        {
                            oDtoLiquidacion.IdConvenio = Convert.ToInt64(IdConve);

                        }
                        else
                        {
                            oDtoLiquidacion.IdConvenio = 0;
                        }

                         string IdEvento = _InfoLiquidacionTable.Rows[i][8].ToString();

                         if (IdEvento != string.Empty)
                         {
                             oDtoLiquidacion.IdEvento = Convert.ToInt64(IdEvento);

                         }
                         else
                         {
                             oDtoLiquidacion.IdEvento = 0;
                         }


                        if (IdTipoPago == 4)
                        {
                            if (IdConve == IdConvenio.ToString())
                            {
                                oDtoLiquidacion.Valor = Convert.ToDouble(_InfoLiquidacionTable.Rows[i][10]);
                            }
                        }
                        else if (IdTipoPago == 5)
                        {
                            if (IdEvento == Evento.ToString())
                            {
                                oDtoLiquidacion.Valor = Convert.ToDouble(_InfoLiquidacionTable.Rows[i][10]);
                            }
                        }
                        else
                        {

                            oDtoLiquidacion.IdTarifa = Convert.ToInt64(_InfoLiquidacionTable.Rows[i][0]);
                            oDtoLiquidacion.IdEstacionamiento = Convert.ToInt64(_InfoLiquidacionTable.Rows[i][1]);
                            oDtoLiquidacion.Estacionamiento = _InfoLiquidacionTable.Rows[i][2].ToString();
                            oDtoLiquidacion.IdTipoPago = Convert.ToInt64(_InfoLiquidacionTable.Rows[i][3]);
                            oDtoLiquidacion.TipoPago = _InfoLiquidacionTable.Rows[i][4].ToString();
                            oDtoLiquidacion.IdTipoVehiculo = Convert.ToInt64(_InfoLiquidacionTable.Rows[i][5]);

                            string IdAuto = _InfoLiquidacionTable.Rows[i][6].ToString();

                            if (IdAuto != string.Empty)
                            {
                                oDtoLiquidacion.IdAutorizacion = Convert.ToInt64(IdAuto);

                            }
                            else
                            {
                                oDtoLiquidacion.IdAutorizacion = 0;
                            }

                            if (IdConve != string.Empty)
                            {
                                oDtoLiquidacion.IdConvenio = Convert.ToInt64(IdConve);

                            }
                            else
                            {
                                oDtoLiquidacion.IdConvenio = 0;
                            }

                            IdEvento = _InfoLiquidacionTable.Rows[i][8].ToString();

                            if (IdEvento != string.Empty)
                            {
                                oDtoLiquidacion.IdEvento = Convert.ToInt64(IdEvento);

                            }
                            else
                            {
                                oDtoLiquidacion.IdEvento = 0;
                            }


                            oDtoLiquidacion.TipoVehiculo = _InfoLiquidacionTable.Rows[i][9].ToString();
                            oDtoLiquidacion.Valor = Convert.ToDouble(_InfoLiquidacionTable.Rows[i][10]);
                            oDtoLiquidacion.TipoCobro = _InfoLiquidacionTable.Rows[i][11].ToString();
                            oDtoLiquidacion.Estado = Convert.ToBoolean(_InfoLiquidacionTable.Rows[i][12]);
                        }
                    }

                    oResultadoOperacion.EntidadDatos = oDtoLiquidacion;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {

                    oDtoLiquidacion.Valor = 0;

                    oResultadoOperacion.EntidadDatos = oDtoLiquidacion;
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error al consultar registros en base de datos.";
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

        public ResultadoOperacion ObtenerDatosLiquidacionAutorizacion(long IdEstacionamiento, long IdTipoPago, long IdTipoVehiculo,long CodAutorizacion)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DtoLiquidacion oDtoLiquidacion = new DtoLiquidacion();

            DataSetLiquidacion.P_ObtenerDatosLiquidacionDataTable _InfoLiquidacionTable = new DataSetLiquidacion.P_ObtenerDatosLiquidacionDataTable();
            DataSetLiquidacionTableAdapters.P_ObtenerDatosLiquidacionTableAdapter _InfoLiquidacionAdapter = new DataSetLiquidacionTableAdapters.P_ObtenerDatosLiquidacionTableAdapter();

            try
            {
                _InfoLiquidacionTable.Constraints.Clear();

                if (_InfoLiquidacionAdapter.Fill(_InfoLiquidacionTable, IdEstacionamiento, IdTipoPago, IdTipoVehiculo) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info datos liquidacion OK";

                    for (int i = 0; i < _InfoLiquidacionTable.Rows.Count; i++)
                    {
                        string IdAuto = _InfoLiquidacionTable.Rows[i][6].ToString();
                        
                        if (IdAuto != string.Empty)
                        {
                            oDtoLiquidacion.IdAutorizacion = Convert.ToInt64(IdAuto);

                        }
                        else
                        {
                            oDtoLiquidacion.IdAutorizacion = 0;
                        }

                        if (oDtoLiquidacion.IdAutorizacion == CodAutorizacion)
                        {

                            oDtoLiquidacion.IdTarifa = Convert.ToInt64(_InfoLiquidacionTable.Rows[i][0]);
                            oDtoLiquidacion.IdEstacionamiento = Convert.ToInt64(_InfoLiquidacionTable.Rows[i][1]);
                            oDtoLiquidacion.Estacionamiento = _InfoLiquidacionTable.Rows[i][2].ToString();
                            oDtoLiquidacion.IdTipoPago = Convert.ToInt64(_InfoLiquidacionTable.Rows[i][3]);
                            oDtoLiquidacion.TipoPago = _InfoLiquidacionTable.Rows[i][4].ToString();
                            oDtoLiquidacion.IdTipoVehiculo = Convert.ToInt64(_InfoLiquidacionTable.Rows[i][5]);
                            oDtoLiquidacion.TipoVehiculo = _InfoLiquidacionTable.Rows[i][9].ToString();
                            oDtoLiquidacion.Valor = Convert.ToDouble(_InfoLiquidacionTable.Rows[i][10]);
                            oDtoLiquidacion.TipoCobro = _InfoLiquidacionTable.Rows[i][11].ToString();
                            oDtoLiquidacion.Estado = Convert.ToBoolean(_InfoLiquidacionTable.Rows[i][12]);

                            break;
                        }
                    }

                    oResultadoOperacion.EntidadDatos = oDtoLiquidacion;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error al consultar registros en base de datos.";
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

        public ResultadoOperacion ObtenerTipoVehiculoMensula(string IdTarjeta)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            long TipoVehiculo = 0;
            long Autorizado = 0;
            string Documento = string.Empty;
            string Fecha = string.Empty;
            string Cobro = string.Empty;

            DataSetLiquidacion.P_ObtenerTipoVehiculoAutorizadoDataTable _InfoLiquidacionTable = new DataSetLiquidacion.P_ObtenerTipoVehiculoAutorizadoDataTable();
            DataSetLiquidacionTableAdapters.P_ObtenerTipoVehiculoAutorizadoTableAdapter _InfoLiquidacionAdapter = new DataSetLiquidacionTableAdapters.P_ObtenerTipoVehiculoAutorizadoTableAdapter();

            try
            {
                _InfoLiquidacionTable.Constraints.Clear();

                if (_InfoLiquidacionAdapter.Fill(_InfoLiquidacionTable, IdTarjeta) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info datos OK";

                    for (int i = 0; i < _InfoLiquidacionTable.Rows.Count; i++)
                    {
                        TipoVehiculo = Convert.ToInt64(_InfoLiquidacionTable.Rows[i][1]);
                        Autorizado = Convert.ToInt64(_InfoLiquidacionTable.Rows[i][2]);
                        Documento = _InfoLiquidacionTable.Rows[i][3].ToString();
                        Fecha = _InfoLiquidacionTable.Rows[i][4].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = TipoVehiculo + ";" + Autorizado + ";" + Documento + ";" + Fecha;
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Error al consultar registros en base de datos.";
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

        public ResultadoOperacion ObtenerDatosTransaccion(string Secuencia)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            long lSecuencia = Convert.ToInt64(Secuencia);

            DtoTransaccion oDtoTransaccion = new DtoTransaccion();

            DataSetLiquidacion.P_ObtenerDatosTransaccionDataTable _InfoTransaccionTable = new DataSetLiquidacion.P_ObtenerDatosTransaccionDataTable();
            DataSetLiquidacionTableAdapters.P_ObtenerDatosTransaccionTableAdapter _InfoTransaccionAdapter = new DataSetLiquidacionTableAdapters.P_ObtenerDatosTransaccionTableAdapter();

            try
            {
                _InfoTransaccionTable.Constraints.Clear();

                if (_InfoTransaccionAdapter.Fill(_InfoTransaccionTable, lSecuencia) > 0)
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

        public ResultadoOperacion ObtenerDatosPago(string Secuencia)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            long lSecuencia = Convert.ToInt64(Secuencia);
            string sFechaPago = string.Empty;

            DataSetLiquidacion.P_ObtenerDatosPagoDataTable _InfoTransaccionTable = new DataSetLiquidacion.P_ObtenerDatosPagoDataTable();
            DataSetLiquidacionTableAdapters.P_ObtenerDatosPagoTableAdapter _InfoTransaccionAdapter = new DataSetLiquidacionTableAdapters.P_ObtenerDatosPagoTableAdapter();

            try
            {
                _InfoTransaccionTable.Constraints.Clear();

                if (_InfoTransaccionAdapter.Fill(_InfoTransaccionTable, lSecuencia) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info pago OK";

                    for (int i = 0; i < _InfoTransaccionTable.Rows.Count; i++)
                    {
                        sFechaPago = _InfoTransaccionTable.Rows[i][0].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = sFechaPago;
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

        public ResultadoOperacion ObtenerDatosEvento(string Secuencia)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            long lSecuencia = Convert.ToInt64(Secuencia);
            long IdEvento = 0;
            int Horas = 0;

            DtoTransaccion oDtoTransaccion = new DtoTransaccion();

            DataSetLiquidacion.P_ObtenerDatosEventoDataTable _InfoEventoTable = new DataSetLiquidacion.P_ObtenerDatosEventoDataTable();
            DataSetLiquidacionTableAdapters.P_ObtenerDatosEventoTableAdapter _InfoEventoAdapter = new DataSetLiquidacionTableAdapters.P_ObtenerDatosEventoTableAdapter();

            try
            {
                _InfoEventoTable.Constraints.Clear();

                if (_InfoEventoAdapter.Fill(_InfoEventoTable, lSecuencia) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info transaccion OK";

                    for (int i = 0; i < _InfoEventoTable.Rows.Count; i++)
                    {
                        IdEvento = Convert.ToInt64(_InfoEventoTable.Rows[i][3]);
                        Horas = Convert.ToInt32(_InfoEventoTable.Rows[i][6]);
                    }

                    oResultadoOperacion.EntidadDatos = IdEvento + ";" + Horas;
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

        public ResultadoOperacion ObtenerDatosCasco(string Secuencia)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            long lSecuencia = Convert.ToInt64(Secuencia);
            
            DtoTransaccion oDtoTransaccion = new DtoTransaccion();

            DataSetLiquidacion.P_ObtenerDatosCascoDataTable _InfoEventoTable = new DataSetLiquidacion.P_ObtenerDatosCascoDataTable();
            DataSetLiquidacionTableAdapters.P_ObtenerDatosCascoTableAdapter _InfoEventoAdapter = new DataSetLiquidacionTableAdapters.P_ObtenerDatosCascoTableAdapter();

            try
            {
                _InfoEventoTable.Constraints.Clear();

                if (_InfoEventoAdapter.Fill(_InfoEventoTable, lSecuencia) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info transaccion OK";

                    for (int i = 0; i < _InfoEventoTable.Rows.Count; i++)
                    {
                        lSecuencia = Convert.ToInt64(_InfoEventoTable.Rows[i][0]);
                    }

                    oResultadoOperacion.EntidadDatos = lSecuencia;
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
    }
}
