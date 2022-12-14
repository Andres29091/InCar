using InCar.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.Entidades
{
  public class TipoDocumento
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(50)]
    public string Tipo { get; set; }

    [JsonIgnore]
    public List<Usuario> Usuario { get; set; }
  }
}
