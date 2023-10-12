using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Mensajes.CodigoMensaje_Servicios
{
    public partial class CodigoMensaje
    {
        public const string InvalidPassword = "Invalid password.";
        public const string InvalidMSISDN = "Invalid MSISDN.";
        public const string RUCInvalido = "Error no es un ruc valido.";
        public const string ErrorEpin = "Error en la transferencia de Epin.";
        public const string FaltanParametros = "Faltan parámetros.";

        public const string NewClient = "\"new_clients\"";

        public const string ConexionExitosa = "\"22,Conexion sastifactoria\"";

        public const string ClienteNuevo = "\"21, Nuevo cliente.\"";
        public const string PasswordInvalido = "\"10, password invalido.\"";

        public const string GirosFueraServicio = "\"23, Giros esta fuera de servicio\"";
    }
}
