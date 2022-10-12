using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class VehiculoDTO
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string Placa { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int Modelo { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public DateTime? FechaFabricacion { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string Color { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string Precio { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(200)]
    public string Foto { get; set; }
    [JsonIgnore]
    public TipoVehiculo TipoVehiculo { get; set; }
    [JsonIgnore]
    public Marca Marca { get; set; }
  }
}
