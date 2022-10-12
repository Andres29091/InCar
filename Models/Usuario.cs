using InCar.Entidades;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.Models
{
  public class Usuario: IdentityUser
  {
    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoTipoDocumento { get; set; }
    public string Direccion { get; set; }
    public string Movil { get; set; }

    [JsonIgnore]
    public TipoDocumento TipoDocumento { get; set; }
  }
}
