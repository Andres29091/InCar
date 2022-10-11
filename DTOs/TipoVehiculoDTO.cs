using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class TipoVehiculoDTO
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string TipoVehiculo { get; set; }

    //relacion uno a muchos con Vehiculo
    [JsonIgnore]
    public List<Vehiculo> Vehiculos { get; set; }
  }
}
