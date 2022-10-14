using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using InCar.Entidades;
using InCar.Models;

namespace InCar.DTOs
{
  public class VehiculoCreacionDTO
  {
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
    public TipoVehiculo TipoVehiculo { get; set; }

    [JsonIgnore]
    public Marca Marca { get; set; }

    [JsonIgnore]
    public List<Historial> Historial { get; set; }

    [JsonIgnore]
    public List<ImagenVehiculo> ImagenVehiculo { get; set; }

    [JsonIgnore]
    public Usuario Usuario { get; set; }
  }
}

