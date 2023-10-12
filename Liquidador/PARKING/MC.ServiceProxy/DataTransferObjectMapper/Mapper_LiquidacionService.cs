using MC.BusinessObjects.DataTransferObject;
using MC.ServiceProxy.MC_LiquidacionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ServiceProxy.DataTransferObjectMapper
{
    internal static partial class Mapper
    {
        internal static List<DtoDatosLiquidacion> FromDataTransferObjects(IList<ServiceDtoDatosLiquidacion> oServiceDtoLiquidacion)
        {
            if (oServiceDtoLiquidacion == null)
                return null;

            return oServiceDtoLiquidacion.Select(c => FromDataTransferObject(c)).ToList();
        }
        internal static DtoDatosLiquidacion FromDataTransferObject(ServiceDtoDatosLiquidacion oServiceDtoLiquidacion)
        {
            DtoDatosLiquidacion oDtoLiquidacion = new DtoDatosLiquidacion();

            if (oServiceDtoLiquidacion != null)
            {
                oDtoLiquidacion.Iva = oServiceDtoLiquidacion.Iva;
                oDtoLiquidacion.SubTotal = oServiceDtoLiquidacion.SubTotal;
                oDtoLiquidacion.Tipo = oServiceDtoLiquidacion.Tipo;
                oDtoLiquidacion.Total = oServiceDtoLiquidacion.Total;
            }

            return oDtoLiquidacion;
        }
       
    }
}
