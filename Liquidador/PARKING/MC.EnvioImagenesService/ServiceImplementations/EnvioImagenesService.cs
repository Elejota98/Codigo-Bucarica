using MC.BaseService;
using MC.BaseService.MessageBase.Type;
using MC.BusinessService.Entities;
using MC.BusinessService.Enums;
using MC.DataService;
using MC.EnvioImagenesService.Messages;
using MC.EnvioImagenesService.ServiceContracts;
using MC.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MC.EnvioImagenesService.ServiceImplementations
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class EnvioImagenesService : ServiceBase, IEnvioImagenesService
    {
        public static IDataService _DataService = new DataService.DataService();
        
        public setAlmacenaImagenesServidor_Response setAlmacenaImagenesServidor(setAlmacenaImagenesServidor_Request request)
        {
            setAlmacenaImagenesServidor_Response response = new setAlmacenaImagenesServidor_Response();

            string NombreImgae = string.Empty;
            string sRutaBaseAlmacenamientoMedios = @"C:\\Medios\\";
            int contador = 0;
            string NombreEstacionamiento = string.Empty;
            ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
            try
            {

                if (!ValidRequest(request, response))
                    return response;

                response.CorrelationId = request.RequestId;

                foreach (Imagen item in request.oImagenes)
                {
                    string[] datosTransaccion = item.NombreImagen.Split('_');
                    NombreImgae = item.NombreImagen;

                    Modulo oModulo = new Modulo();
                    oModulo.IdModulo = datosTransaccion[1];
                    oModulo.IdEstacionamiento = Convert.ToInt64(datosTransaccion[0].Substring(15, 2));

                    oResultadoOperacion = new ResultadoOperacion();
                    oResultadoOperacion = _DataService.ListarRutaFoto(oModulo);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        sRutaBaseAlmacenamientoMedios = Convert.ToString(oResultadoOperacion.EntidadDatos);

                        oResultadoOperacion = _DataService.ObtenerDatosEstacionamiento(oModulo.IdEstacionamiento);
                        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                        {
                            NombreEstacionamiento = oResultadoOperacion.EntidadDatos.ToString();

                            string sRutaCarpeta = sRutaBaseAlmacenamientoMedios + "\\" + NombreEstacionamiento + "\\" + datosTransaccion[3] + "-" + datosTransaccion[4] + "-" + datosTransaccion[5] + "\\" + oModulo.IdModulo + "\\";
                            string sFile = request.oImagenes[contador].NombreImagen;

                            if (!Directory.Exists(sRutaCarpeta))
                            {
                                Directory.CreateDirectory(sRutaCarpeta);
                            }

                            //ALAMCENA ARCHIVO DE IMAGEN
                            string sFileName = sFile;
                            string sFilePathName = Path.Combine(sRutaCarpeta, sFileName);
                            byte[] bImagen = Generales.RetornaByteStream(item.ContenidoImagen);
                            Image oImagen = Generales.byteArrayToImage(bImagen);
                            oImagen.Save(sFilePathName, ImageFormat.Jpeg);


                            //ALAMCENA ARCHIVO DE IMAGEN CLOUD
                            string sRutaCarpeta2 = @"C:\CLOUD\";

                            string sFileName2 = sFile;
                            string sFilePathName2 = Path.Combine(sRutaCarpeta2, sFileName2);
                            byte[] bImagen2 = Generales.RetornaByteStream(item.ContenidoImagen);
                            Image oImagen2 = Generales.byteArrayToImage(bImagen2);
                            oImagen.Save(sFilePathName2, ImageFormat.Jpeg);



                            contador++;
                        }
                        else
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            break;
                        }
                    }
                    else 
                    {
                        response.Message = NombreImgae;
                        response.Acknowledge = AcknowledgeType.Failure;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = NombreImgae;
                TraceHandler.WriteLine(@"C:\Logs\LogRegistroArchivos.log", "MENSAJE Exception setAlmacenaImagenesServidor: " + ex.InnerException + " " + ex.Message + " " + ex.Source, TipoLog.TRAZA);
            }

            return response;
        }

        public setAlmacenaImagenesServidorCloud_Response setAlmacenaImagenesServidorCloud(setAlmacenaImagenesServidorCloud_Request request)
        {
            setAlmacenaImagenesServidorCloud_Response response = new setAlmacenaImagenesServidorCloud_Response();

            string sRutaBaseAlmacenamientoMedios = @"C:\\Medios\\";
            int contador = 0;
            string NombreEstacionamiento = string.Empty;

            try
            {

                if (!ValidRequest(request, response))
                    return response;

                response.CorrelationId = request.RequestId;

                foreach (Imagen item in request.oImagenes)
                {
                    string[] datosTransaccion = item.NombreImagen.Split('_');

                    Modulo oModulo = new Modulo();
                    oModulo.IdModulo = datosTransaccion[1];
                    oModulo.IdEstacionamiento = Convert.ToInt64(datosTransaccion[0].Substring(15, 2));

                    ResultadoOperacion oResultadoOperacion = new ResultadoOperacion();
                    oResultadoOperacion = _DataService.ListarRutaFotoCloud(oModulo);
                    if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                    {
                        sRutaBaseAlmacenamientoMedios = Convert.ToString(oResultadoOperacion.EntidadDatos);

                        oResultadoOperacion = _DataService.ObtenerDatosEstacionamiento(oModulo.IdEstacionamiento);
                        if (oResultadoOperacion.oEstado == TipoRespuesta.Exito)
                        {
                            NombreEstacionamiento = oResultadoOperacion.EntidadDatos.ToString();

                            string sRutaCarpeta = sRutaBaseAlmacenamientoMedios + "\\" + NombreEstacionamiento + "\\" + datosTransaccion[3] + "-" + datosTransaccion[4] + "-" + datosTransaccion[5] + "\\" + oModulo.IdModulo + "\\";
                            string sFile = request.oImagenes[contador].NombreImagen;

                            if (!Directory.Exists(sRutaCarpeta))
                            {
                                Directory.CreateDirectory(sRutaCarpeta);
                            }

                            //ALAMCENA ARCHIVO DE IMAGEN
                            string sFileName = sFile;
                            string sFilePathName = Path.Combine(sRutaCarpeta, sFileName);
                            byte[] bImagen = Generales.RetornaByteStream(item.ContenidoImagen);
                            Image oImagen = Generales.byteArrayToImage(bImagen);
                            oImagen.Save(sFilePathName, ImageFormat.Jpeg);

                            contador++;
                        }
                        else
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            break;
                        }
                    }
                    else
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = "Exception";
                TraceHandler.WriteLine(@"C:\Logs\LogRegistroArchivos.log", "MENSAJE Exception setAlmacenaImagenesServidor: " + ex.InnerException + " " + ex.Message + " " + ex.Source, TipoLog.TRAZA);
            }

            return response;
        }

    }
}
