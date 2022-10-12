using System.ComponentModel.DataAnnotations;

namespace InCar.DTOs
{
  public class MarcaCreacionDTO
  {
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(20)]
    public string Tipo { get; set; }
  }
}
