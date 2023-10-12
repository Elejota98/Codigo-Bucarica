using MC.BusinessObjects.DataTransferObject;
using MC.BusinessObjects.Entities;
using MC.BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ModuloSalida.WinForm.View
{
    public interface IView_Principal : IView
    {
        Pantalla Presentacion { set; get; }
        bool KytReady { get; set; }
        bool CRTReady { get; set; }
        bool CardKytReady { get; set; }
        bool CleanCardKyt { get; set; }
        bool RemoveCard { get; set; }
        bool WriteCard { get; set; }
        string General_Events { set; }
        string IdCard { get; set; }
        string IdCardAutorizado { get; set; }
        bool CicloActivo { get; set; }
        List<DtoAutorizado> lstDtoAutorizado { get; set; }
        List<DtoTarjetas> lstDtoTarjetas { get; set; }
        List<DtoDatosLiquidacion> lstDtoLiquidacion { get; set; }
        string ValorAPagar { get; set; } 
        DtoModulo DtoModulo { set; get; }
        Tarjeta Tarjeta { set; get; }
        bool CardKytReceptorReady { get; set; }
        bool CardReadKytReceptorReady { get; set; }
        string Horas { get; set; }
        string Barrera { get; set; }

        
    }
}
