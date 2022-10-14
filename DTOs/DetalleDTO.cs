using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class DetalleDTO
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoDetalle { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoProcedimiento { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoHistorial { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(300)]
    public string Descripcion { get; set; }

    [JsonIgnore]
    public Procedimiento Procedimiento { get; set; }

    [JsonIgnore]
    public Historial Historial { get; set; }
  }
}
