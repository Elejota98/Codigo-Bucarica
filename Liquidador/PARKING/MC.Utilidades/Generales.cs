using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MC.Utilidades
{
    public class Generales
    {
        public static bool VerificaArchivoEnUso(string sRuta, string sNombreArchivo)
        {
            try
            {
                using (var stream = new FileStream(sRuta + "\\" + sNombreArchivo, FileMode.Open, FileAccess.Read)) { }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }
        public static byte[] ImageToByteArray(Image imageIn, ImageFormat oFormato)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, oFormato);
            return ms.ToArray();
        }
        public static byte[] RetornaByteStream(Stream StreamImagen)
        {
            byte[] barrImg = new byte[1];

            MemoryStream ms = new MemoryStream();
            ms = (MemoryStream)StreamImagen;
            barrImg = ms.ToArray();
            ms.Close();
            ms.Dispose();
            ms = null;


            return barrImg;
        }
        public static Stream RetornaStreamByte(byte[] byteImagen)
        {

            Stream StreamFile = null;

            MemoryStream ms = new MemoryStream();
            ms.Write(byteImagen, 0, byteImagen.Length);
            ms.Flush();
            ms.Close();

            StreamFile = (Stream)ms;

            ms.Dispose();
            ms = null;

            return StreamFile;
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = null;
            try
            {
                returnImage = Image.FromStream(ms);
            }
            catch (Exception e)
            {
                //Error al crear imagen
            }
            return returnImage;
        }
        public static bool WebSiteIsAvailable(string Url,string user,string pass)
        {
            bool IsAvailable = false;

            string Message = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);

            // Set the credentials to the current user account
            request.Credentials = new NetworkCredential(user, pass);
            request.Method = "GET";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Do nothing; we're only testing to see if we can get the response
                }
            }
            catch (WebException ex)
            {
                Message += ((Message.Length > 0) ? "\n" : "") + ex.Message;
            }

            IsAvailable = (Message.Length == 0);

            return IsAvailable;
        }
    }
}
