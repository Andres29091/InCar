using InCar.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InCar.Entidades
{
  public class Vehiculo
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoMarca { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoTipoVehiculo { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int CodigoUsuario { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string Placa { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int Modelo { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public DateTime? FechaFabricacion { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(20)]
    public string Color { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string Precio { get; set; }

    [JsonIgnore]
    [NotMapped]
    public TipoVehiculo TipoVehiculo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public Marca Marca { get; set; }

    [JsonIgnore]
    [NotMapped]
    public List<Historial> Historial { get; set; }
    
    [JsonIgnore]
    [NotMapped]
    public List<ImagenVehiculo> ImagenVehiculo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public Usuario Usuario { get; set; }
  }
}
