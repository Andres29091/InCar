using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.Entidades
{
  public class Marca
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(20)]
    public string Nombre { get; set; }

    [StringLength(100)]
    public string Pais { get; set; }

    [JsonIgnore]
    public List<Vehiculo> Vehiculo { get; set; }
  }
}
