using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.Enums
{
    public enum TimeOut
    {
        TimeOut_FlujoPantallas = 30,
        TimeOut_CancelaOperacion = 2,
        TimeOut_RetireTarjeta = 10,
        TimeOut_PagoExitoso = 3,
        TimeOut_Short = 3,
        TimeOut_RegistroPago = 120,
        TimeOut_IngresoPIN = 240,
        TimeOut_ValidacionOTP = 60,
        TimeOut_Alertas = 6,
        TimeOut_InserteTarjeta = 10,
        TimeOut_TarjetaMocha = 10,
    }
}
