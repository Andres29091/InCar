using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class ImagenVehiculoCreacionDTO
  {
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoVehiculo { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(200)]
    public IFormFile Foto { get; set; }

    [JsonIgnore]
    [NotMapped]
    public Vehiculo Vehiculo { get; set; }
  }
}
