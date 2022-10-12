using System.ComponentModel.DataAnnotations;

namespace InCar.DTOs
{
  public class TipoVehiculoDTO
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string TipoVehiculo { get; set; }
  }
}
