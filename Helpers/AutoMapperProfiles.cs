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
      CreateMap<DetalleCreacionDTO, Detalle>();

      CreateMap<Historial, HistorialDTO>().ReverseMap();
      CreateMap<HistorialCreacionDTO, Historial>();

      CreateMap<ImagenVehiculo, ImagenVehiculoDTO>().ReverseMap();
      CreateMap<ImagenVehiculoCreacionDTO, ImagenVehiculo>();

      CreateMap<Marca, MarcaDTO>().ReverseMap();
      CreateMap<MarcaCreacionDTO, Marca>();

      CreateMap<Procedimiento, ProcedimientoDTO>().ReverseMap();
      CreateMap<ProcedimientoCreacionDTO, Procedimiento>();

      CreateMap<TipoDocumento, TipoDocumentoDTO>().ReverseMap();
      CreateMap<TipoDocumentoCreacionDTO, TipoDocumento>();

      CreateMap<TipoVehiculo, TipoVehiculoDTO>().ReverseMap();
      CreateMap<TipoVehiculoCreacionDTO, TipoVehiculo>();

      CreateMap<Vehiculo, VehiculoDTO>().ReverseMap();
      CreateMap<VehiculoCreacionDTO, Vehiculo>();
    }
  }
}
