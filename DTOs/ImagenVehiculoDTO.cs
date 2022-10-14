using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class ImagenVehiculoDTO
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(200)]
    public IFormFile Foto { get; set; }
    [JsonIgnore]
    public Vehiculo Vehiculo { get; set; }
  }
}
