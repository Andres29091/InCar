using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.Entidades
{
  public class TipoVehiculo
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(20)]
    public string Tipo { get; set; }

    [JsonIgnore]
    public List<Vehiculo> Vehiculo { get; set; }
  }
}
