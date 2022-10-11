using Microsoft.AspNetCore.Identity;

namespace InCar.Models
{
  public class IdentityModels: IdentityUser
  {
    public string Documento { get; set; }
    public string Direccion { get; set; }
    public string Movil { get; set; }
  }
}
