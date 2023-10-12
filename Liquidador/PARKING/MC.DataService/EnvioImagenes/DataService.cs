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
        public ResultadoOperacion ListarRutaFoto(Modulo oModulo)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DataSetEnvioImagenes.P_ListarRutaFotoDataTable _SincronizarTable = new DataSetEnvioImagenes.P_ListarRutaFotoDataTable();
            DataSetEnvioImagenesTableAdapters.P_ListarRutaFotoTableAdapter _SincronizarAdapter = new DataSetEnvioImagenesTableAdapters.P_ListarRutaFotoTableAdapter();

            try
            {
                _SincronizarTable.Constraints.Clear();

                if (_SincronizarAdapter.Fill(_SincronizarTable, oModulo.IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Listar Configuracion OK";
                    oResultadoOperacion.EntidadDatos = _SincronizarTable.Rows[0][0];
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Configuracion no encontrada";
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
        public ResultadoOperacion ListarRutaFotoCloud(Modulo oModulo)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();

            DataSetEnvioImagenes.P_ListarRutaCloudDataTable _SincronizarTable = new DataSetEnvioImagenes.P_ListarRutaCloudDataTable();
            DataSetEnvioImagenesTableAdapters.P_ListarRutaCloudTableAdapter _SincronizarAdapter = new DataSetEnvioImagenesTableAdapters.P_ListarRutaCloudTableAdapter();

            try
            {
                _SincronizarTable.Constraints.Clear();

                if (_SincronizarAdapter.Fill(_SincronizarTable) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Listar Configuracion OK";
                    oResultadoOperacion.EntidadDatos = _SincronizarTable.Rows[0][0];
                }
                else
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Error;
                    oResultadoOperacion.Mensaje = "Configuracion no encontrada";
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
        public ResultadoOperacion ObtenerDatosEstacionamiento(long IdEstacionamiento)
        {
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();


            string sEstacionamiento = string.Empty;

            DataSetEnvioImagenes.P_ObtenerDatosEstacionamientoDataTable _InfoTransaccionTable = new DataSetEnvioImagenes.P_ObtenerDatosEstacionamientoDataTable();
            DataSetEnvioImagenesTableAdapters.P_ObtenerDatosEstacionamientoTableAdapter _InfoTransaccionAdapter = new DataSetEnvioImagenesTableAdapters.P_ObtenerDatosEstacionamientoTableAdapter();

            try
            {
                _InfoTransaccionTable.Constraints.Clear();

                if (_InfoTransaccionAdapter.Fill(_InfoTransaccionTable, IdEstacionamiento) > 0)
                {
                    oResultadoOperacion.oEstado = TipoRespuesta.Exito;
                    oResultadoOperacion.Mensaje = "Info OK";

                    for (int i = 0; i < _InfoTransaccionTable.Rows.Count; i++)
                    {
                        sEstacionamiento = _InfoTransaccionTable.Rows[i][1].ToString();
                    }

                    oResultadoOperacion.EntidadDatos = sEstacionamiento;
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
