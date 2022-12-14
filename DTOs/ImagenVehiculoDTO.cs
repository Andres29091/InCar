using AutoMapper.Configuration.Annotations;
using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class ImagenVehiculoDTO
  {
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(200)]
    public IFormFile Foto { get; set; }

    [JsonIgnore]
    [NotMapped]
    public Vehiculo Vehiculo { get; set; }
  }
}
