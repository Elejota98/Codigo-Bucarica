using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Utilidades
{
    public class TraceHandler
    {
        private static object syncLock = new object();

        private static void WriteLogFile(string sFileName, string message, TipoLog oTipoLog)
        {
            if (oTipoLog == TipoLog.ERROR)
            {
                message = "****** ERROR ******" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss").ToString() + " **********" + "\r\n"
                          + message + "\r\n"
                          + "*************************************************";
            }
            else if (oTipoLog != TipoLog.PLANO)
            {
                message = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff").ToString() + " - " + message;
            }

            string directoryFullPath = Path.GetDirectoryName(sFileName);
            if (!Directory.Exists(directoryFullPath))
            {
                Directory.CreateDirectory(directoryFullPath);
            }
            if (oTipoLog == TipoLog.PLANO)
            {
                if (File.Exists(sFileName) == true)
                {
                    if (Generales.VerificaArchivoEnUso(directoryFullPath, Path.GetFileName(sFileName)) == true)
                    {
                        throw new Exception("Archivo en uso");
                    }
                }
            }
            lock (syncLock)
            {
                if (oTipoLog != TipoLog.PLANO)
                {

                    if (Globales.bEnabledTracking == true)
                    {
                        string sNameFile = sFileName;

                        sNameFile = sNameFile + "_" + oTipoLog.ToString() + "_" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".log";

                        // create a writer and open the file
                        System.IO.TextWriter tw = new System.IO.StreamWriter(sNameFile, true);

                        // write a line of text to the file
                        tw.WriteLine(message);

                        // close the stream
                        tw.Close();
                    }
                }
                else
                {
                    string sNameFile = sFileName + ".log";

                    // create a writer and open the file
                    System.IO.TextWriter tw = new System.IO.StreamWriter(sNameFile, true);

                    // write a line of text to the file
                    tw.WriteLine(message);

                    // close the stream
                    tw.Close();
                }
            }


        }

        /// <summary>
        /// Escribe una linea en el archivo del log
        /// </summary>
        /// <param name="sFileName">Nombre del Archivo de Log...</param>
        /// <param name="message">Mensaje a escribir en el Log...</param>
        /// <param name="oTipoLog">Tipo de Log</param>
        public static void WriteLine(string sFileName, string message, TipoLog oTipoLog)
        {
            WriteLogFile(sFileName, message, oTipoLog);
        }

    }

    /// <summary>
    /// Tipo de Log que define la estructura del mensaje en el archivo de log.
    /// </summary>
    public enum TipoLog
    {
        ERROR,
        TRAZA,
        PLANO,
    }
}
