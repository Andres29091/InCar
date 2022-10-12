using System.ComponentModel.DataAnnotations;

namespace InCar.DTOs
{
  public class MarcaDTO
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(20)]
    public string Tipo { get; set; }
  }
}


