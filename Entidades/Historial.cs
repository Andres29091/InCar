using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.Entidades
{
  public class Historial
  {
    public int Id { get; set; }
    [StringLength(200)]
    public string Descripcion{ get; set; }
    [JsonIgnore]
    public Vehiculo Vehiculo { get; set; }
  }
}
