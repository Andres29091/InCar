using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.Models
{
  public class UsuarioRol
  {
    public int Id { get; set; }


    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoRol { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoUsuario { get; set; }

    [JsonIgnore]
    public Usuario Usuario { get; set; }

    [JsonIgnore]
    public Rol Rol { get; set; }

  }
}
