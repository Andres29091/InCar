using AutoMapper;
using InCar.DTOs;
using InCar.Entidades;

namespace InCar.Helpers
{
  public class AutoMapperProfiles : Profile
  {

    public AutoMapperProfiles()
    {
      CreateMap<Detalle, DetalleDTO>().ReverseMap();
      CreateMap<DetalleCreacionDTO, DetalleDTO>();

      CreateMap<Historial, HistorialDTO>().ReverseMap();
      CreateMap<HistorialCreacionDTO, HistorialDTO>();

      CreateMap<ImagenVehiculo, ImagenVehiculoDTO>().ReverseMap();
      CreateMap<ImagenVehiculoCreacionDTO, ImagenVehiculoDTO>();

      CreateMap<Marca, MarcaDTO>().ReverseMap();
      CreateMap<MarcaCreacionDTO, MarcaDTO>();

      CreateMap<Procedimiento, ProcedimientoDTO>().ReverseMap();
      CreateMap<ProcedimientoCreacionDTO, ProcedimientoDTO>();

      CreateMap<TipoDocumento, TipoDocumentoDTO>().ReverseMap();
      CreateMap<TipoDocumentoCreacionDTO, TipoDocumentoDTO>();

      CreateMap<TipoVehiculo, TipoVehiculoDTO>().ReverseMap();
      CreateMap<TipoVehiculoCreacionDTO, TipoVehiculoDTO>();

      CreateMap<Vehiculo, VehiculoDTO>().ReverseMap();
      CreateMap<VehiculoCreacionDTO, VehiculoDTO>();
    }
  }
}
