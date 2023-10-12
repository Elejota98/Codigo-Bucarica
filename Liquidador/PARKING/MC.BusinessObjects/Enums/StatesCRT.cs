using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.BusinessObjects.Enums
{
    public enum StatesCRT
    {
        Conexion_Exitosa_CRT,
        Error_Conexion_CRT,
        Sin_Tarjeta,
        Tarjeta_Escrita,
        Error_Escribir_Tarjeta,
        IdCardCRT_OK,
        Error_GetId,
        LoadKeyCRT_ok,
        Error_LoadKeyCRT,
        CheckKeyCRT_ok,
        Error_CheckKeyCRT,
        WriteCard_ok,
        Error_WriteCard,
        ReadCard_ok,
        Error_ReadCard,
    }
}
