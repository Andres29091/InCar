using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class HistorialDTO
  {
    public int Id { get; set; }
    [StringLength(200)]
    public string Descripcion { get; set; }
    [JsonIgnore]
    public Vehiculo Vehiculo { get; set; }
  }
}
