using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InCar.Entidades
{
  public class ImagenVehiculo
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoVehiculo { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(200)]
    public string Foto { get; set; }

    [JsonIgnore]
    [NotMapped]
    public Vehiculo Vehiculo { get; set; }
  }
}
