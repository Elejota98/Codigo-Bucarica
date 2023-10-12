using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Mensajes
{
    public class Utils
    {
        #region Serialize and Deserialize

        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        private static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(characters);
            constructedString = constructedString.Remove(0, constructedString.IndexOf('<')); //eliminar caracteres no legibles binarios
            return (constructedString);
        }

        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns></returns>
        private static Byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        /// <summary>
        /// Serialize an object into an XML string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(T obj)
        {
            try
            {
                string xmlString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                StreamWriter xmlTextWriter = new StreamWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                xmlString = UTF8ByteArrayToString(memoryStream.ToArray()); return xmlString;
            }
            catch (System.Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Reconstruct an object from an XML string
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string xml)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return (T)xs.Deserialize(memoryStream);
        }



        /// <summary>
        /// Serlializa el DataTable especificado en una cadena de texto separando 
        /// los valores de cada columna por un caracter de tabulación
        /// y las filas por un salto de línea.
        /// </summary>
        /// <param name="dt">DataTable a Serializar</param>
        /// <returns>Cadena con el DataTable serializado</returns>
        private static string SerializeDT(DataTable dt, string Encabezado)
        {
            const string FIELDSEPARATOR = "\t";
            const string ROWSEPARATOR = "\n";
            StringBuilder output = new StringBuilder();
            output.AppendLine(Encabezado);

            // Escribir encabezados
            foreach (DataColumn dc in dt.Columns)
            {
                output.Append(dc.ColumnName);
                output.Append(FIELDSEPARATOR);
            }
            output.Append(ROWSEPARATOR);

            // Escribir datos
            foreach (DataRow item in dt.Rows)
            {
                foreach (object value in item.ItemArray)
                {
                    DateTime valorDt;
                    if (DateTime.TryParse(value.ToString(), out valorDt))
                        output.Append(valorDt.ToString(ConfigurationManager.AppSettings["FormatoFecha"]));
                    else
                        output.Append(value.ToString());
                    output.Append(FIELDSEPARATOR);
                }
                // Escribir una línea de registro
                output.Append(ROWSEPARATOR);
            }
            // Valor de retorno
            return output.ToString();
        }

        ///<summary>
        /// Serlializa el DataTable especificado en una cadena de texto separando 
        /// los valores de cada columna por un caracter de tabulación
        /// y las filas por un salto de línea.
        /// </summary>
        /// <param name="dt">DataTable a Serializar</param>
        /// <param name="fileName">Archivo en el que se desean escribir los resultados</param>
        public static void SerializeDT(DataTable dt, string fileName, string Encabezado)
        {
            // Serializar los datos, usando nuestra función
            string data = SerializeDT(dt, Encabezado);
            // Devolverlo al cliente, indicando que es un archivo xls
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Datos.xls");
            // HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = Encoding.Default;

            HttpContext.Current.Response.Write(data);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();


        }

        #endregion

    }
}
