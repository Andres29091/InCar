using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class ProcedimientoCreacionDTO
  {
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoProcedimiento { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(200)]
    public string Descripcion { get; set; }
    public string Estado { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(200)]
    public string FechaInicio { get; set; }
    public string FechaFin { get; set; }

    [JsonIgnore]
    public List<Detalle> Detalle { get; set; }
  }
}
