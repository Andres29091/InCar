using System.ComponentModel.DataAnnotations;
using InCar.Entidades;

namespace InCar.DTOs
{
  public class VehiculoCreacionDTO
  {
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
  }
}

