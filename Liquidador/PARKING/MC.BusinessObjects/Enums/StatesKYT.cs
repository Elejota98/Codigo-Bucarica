using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.Enums
{
    public enum StatesKYT
    {
        Conexion_Exitosa_Dispensador,
        Error_Conexion_Dispensador,
        SistemaSuspendido,
        Tarjeta_Alistada,
        Error_AlistarTarjeta,
        Tarjeta_Borrada,
        Error_Borrar_Tarjeta,
        Tarjeta_Movida_RF_TO_FRONT,
        Tarjeta_Movida_TOBINBOX,
        Error_MoverTarjetaRF_TO_FRONT,
        Error_MoverTarjetaTO_BINBOX,
        Tarjeta_Movida_FRONT_TO_RF,
        Error_MoverTarjeta_FRONT_TO_RF,
        Estado_Dispensador_OK,
        TestDispensador_ERROR,
        Sin_Tarjeta,
        Error_Sensores,
        Tarjeta_En_Boca,
        Tarjeta_En_RF,
        Tarjeta_Stacker_RF,
        Posicion_Desconocida,
        Tarjeta_Escrita,
        Error_Escribir_Tarjeta,
        Estado_StackerGood,
        Estado_StackerNivelBajo,
        Estado_StackerSinTarjetas,
        Error_Estado_Stacker,

        /////////////////////////////////////

        Conexion_Exitosa_Receptor,
        Error_Conexion_Receptor,
        Tarjeta_MovidaReceptor_FRONT_TO_RF,
        Error_MoverTarjetaReceptor_FRONT_TO_RF,
        Tarjeta_MovidaReceptor_RF_TO_FRONT,
        Error_MoverTarjetaReceptor_RF_TO_FRONT,
        Tarjeta_MovidaReceptor_TO_BINBOX,
        Error_MoverTarjetaReceptor_TO_BINBOX,
        Tarjeta_MovidaReceptor_TO_DOWN,
        Error_MoverTarjetaReceptor_TO_DOWN,
        Tarjeta_Leida,
        Error_Leer_Tarjeta,
        Tarjeta_Borrada_Receptor,
        Error_Borrar_TarjetaReceptor,
        TestReceptor_OK,
        TestReceptor_ERROR,

    }
}
