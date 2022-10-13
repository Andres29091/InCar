using InCar.Entidades;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.Models
{
  public class Usuario: IdentityUser
  {
    public int CodigoTipoDocumento { get; set; }
    public string Direccion { get; set; }
    public string Movil { get; set; }

    [JsonIgnore]
    public TipoDocumento TipoDocumento { get; set; }
  }
}
