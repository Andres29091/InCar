using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class ImagenVehiculoCreacionDTO
  {
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(200)]
    public string Foto { get; set; }
  }
}
