using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class DetalleDTO
  {
    public int Id { get; set; }
    [StringLength(200)]
    public string Descripcion { get; set; }
    [JsonIgnore]
    public Procedimiento Procedimiento { get; set; }
  }
}
