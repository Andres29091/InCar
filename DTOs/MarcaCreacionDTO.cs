using System.ComponentModel.DataAnnotations;
using InCar.Entidades;

namespace InCar.DTOs
{
  public class MarcaCreacionDTO
  {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(20)]
        public string Marca { get; set; }
    }
}
