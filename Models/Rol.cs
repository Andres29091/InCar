using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace InCar.Models
{
  public class Rol : IdentityRole
  {
    [JsonIgnore]
    public List<UsuarioRol> UsuarioRol { get; set; }
  }
}
