using System.ComponentModel.DataAnnotations;

namespace InCar.DTOs
{
  public class TipoDocumentoCreacionDTO
  {
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(50)]
    public string Tipo { get; set; }
  }
}
