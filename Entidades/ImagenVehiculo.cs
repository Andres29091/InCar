using System.ComponentModel.DataAnnotations;

namespace InCar.Entidades
{
  public class ImagenVehiculo
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(200)]
    public string Foto { get; set; }
  }
}
