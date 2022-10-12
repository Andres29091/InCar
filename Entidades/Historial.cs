using InCar.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.Entidades
{
  public class Historial
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoUsuario { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoVehiculo { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(200)]
    public string Descripcion { get; set; }

    [JsonIgnore]
    public Vehiculo Vehiculo { get; set; }

    [JsonIgnore]
    public List<Detalle> Detalle { get; set; }

    [JsonIgnore]
    public Usuario Usuario { get; set; }
  }
}
