using MC.BusinessObjects.DataTransferObject;
using MC.ServiceProxy.MC_EntradaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ServiceProxy.DataTransferObjectMapper
{
    internal static partial class Mapper
    {
        internal static List<DtoAutorizado> FromDataTransferObjects(IList<ServiceDtoAutorizado> oServiceAutorizado)
        {
            if (oServiceAutorizado == null)
                return null;

            return oServiceAutorizado.Select(c => FromDataTransferObject(c)).ToList();
        }
        internal static DtoAutorizado FromDataTransferObject(ServiceDtoAutorizado oServiceAutorizado)
        {
            DtoAutorizado oDtoAutorizado = new DtoAutorizado();

            if (oServiceAutorizado != null)
            {
                oDtoAutorizado.Documento = oServiceAutorizado.Documento;
                oDtoAutorizado.Estado = oServiceAutorizado.Estado;
                oDtoAutorizado.EstadoAutorizacion = oServiceAutorizado.EstadoAutorizacion;
                oDtoAutorizado.IdAutorizacion = oServiceAutorizado.IdAutorizacion;
                oDtoAutorizado.IdTarjeta = oServiceAutorizado.IdTarjeta;
                oDtoAutorizado.NombresAutorizado = oServiceAutorizado.NombresAutorizado;
                oDtoAutorizado.FechaInicial = oServiceAutorizado.FechaInicial;
                oDtoAutorizado.FechaFinal = oServiceAutorizado.FechaFinal;
                oDtoAutorizado.IdEstacionamiento = oServiceAutorizado.IdEstacionamiento;
            }

            return oDtoAutorizado;
        }

        internal static List<DtoParteModulo> FromDataTransferObjects(IList<ServiceDtoParteModulo> oServiceDtoParteModulo)
        {
            if (oServiceDtoParteModulo == null)
                return null;

            return oServiceDtoParteModulo.Select(c => FromDataTransferObject(c)).ToList();
        }
        internal static DtoParteModulo FromDataTransferObject(ServiceDtoParteModulo oServiceDtoParteModulo)
        {
            DtoParteModulo oDtoParteModulo = new DtoParteModulo();

            if (oServiceDtoParteModulo != null)
            {
                oDtoParteModulo.CantidadActual = oServiceDtoParteModulo.CantidadActual;
                oDtoParteModulo.CantidadAlarma = oServiceDtoParteModulo.CantidadAlarma;
                oDtoParteModulo.CantidadMax = oServiceDtoParteModulo.CantidadMax;
                oDtoParteModulo.CantidadMin = oServiceDtoParteModulo.CantidadMin;
                oDtoParteModulo.Denominacion = oServiceDtoParteModulo.Denominacion;
                oDtoParteModulo.DineroActual = oServiceDtoParteModulo.DineroActual;
                oDtoParteModulo.Estado = oServiceDtoParteModulo.Estado;
                oDtoParteModulo.IdEstacionamiento = oServiceDtoParteModulo.IdEstacionamiento;
                oDtoParteModulo.IdModulo = oServiceDtoParteModulo.IdModulo;
                oDtoParteModulo.IdParte = oServiceDtoParteModulo.IdParte;
                oDtoParteModulo.IPDispositivo = oServiceDtoParteModulo.IPDispositivo;
                oDtoParteModulo.NombreParte = oServiceDtoParteModulo.NombreParte;
                oDtoParteModulo.Prioritario = oServiceDtoParteModulo.Prioritario;
                oDtoParteModulo.TipoParte = oServiceDtoParteModulo.TipoParte;
            }

            return oDtoParteModulo;
        }


        internal static List<DtoModulo> FromDataTransferObjects(IList<ServiceDtoModulo> oServiceModulo)
        {
            if (oServiceModulo == null)
                return null;

            return oServiceModulo.Select(c => FromDataTransferObject(c)).ToList();
        }
        internal static DtoModulo FromDataTransferObject(ServiceDtoModulo oServiceModulo)
        {
            DtoModulo oDtoModulo = new DtoModulo();

            if (oServiceModulo != null)
            {
                oDtoModulo.Carril = oServiceModulo.Carril;
                oDtoModulo.Ciudad = oServiceModulo.Ciudad;
                oDtoModulo.Estado = oServiceModulo.Estado;
                oDtoModulo.EstadoEstacionamiento = oServiceModulo.EstadoEstacionamiento;
                oDtoModulo.EstadoSede = oServiceModulo.EstadoSede;
                oDtoModulo.Extension = oServiceModulo.Extension;
                oDtoModulo.IdEstacionamiento = oServiceModulo.IdEstacionamiento;
                oDtoModulo.IdModulo = oServiceModulo.IdModulo;
                oDtoModulo.IdTipoModulo = oServiceModulo.IdTipoModulo;
                oDtoModulo.IP = oServiceModulo.IP;
                oDtoModulo.NombreEstacionamiento = oServiceModulo.NombreEstacionamiento;
                oDtoModulo.NombreSede = oServiceModulo.NombreSede;
                oDtoModulo.Partes = Mapper.FromDataTransferObjects(oServiceModulo.Partes);
            }

            return oDtoModulo;
        }

        internal static List<DtoParametros> FromDataTransferObjects(IList<ServiceDtoParametros> oServiceDtoParametro)
        {
            if (oServiceDtoParametro == null)
                return null;

            return oServiceDtoParametro.Select(c => FromDataTransferObject(c)).ToList();
        }
        internal static DtoParametros FromDataTransferObject(ServiceDtoParametros oServiceDtoParametro)
        {
            DtoParametros oDtoParametro = new DtoParametros();

            if (oServiceDtoParametro != null)
            {
                oDtoParametro.Codigo = oServiceDtoParametro.Codigo;
                oDtoParametro.Descripcion = oServiceDtoParametro.Descripcion;
                oDtoParametro.Estado = oServiceDtoParametro.Estado;
                oDtoParametro.Valor = oServiceDtoParametro.Valor;
                oDtoParametro.IdEstacionamiento = oServiceDtoParametro.IdEstacionamiento;
            }

            return oDtoParametro;
        }

        internal static List<DtoTarjetas> FromDataTransferObjects(IList<ServiceDtoTarjetas> oServiceDtoTarjetas)
        {
            if (oServiceDtoTarjetas == null)
                return null;

            return oServiceDtoTarjetas.Select(c => FromDataTransferObject(c)).ToList();
        }
        internal static DtoTarjetas FromDataTransferObject(ServiceDtoTarjetas oServiceDtoTarjetas)
        {
            DtoTarjetas oDtoTarjetas = new DtoTarjetas();

            if (oServiceDtoTarjetas != null)
            {
                oDtoTarjetas.Estado = oServiceDtoTarjetas.Estado;
                oDtoTarjetas.IdEstacionamiento = oServiceDtoTarjetas.IdEstacionamiento;
                oDtoTarjetas.IdTarjeta = oServiceDtoTarjetas.IdTarjeta;
            }

            return oDtoTarjetas;
        }
    }
}
