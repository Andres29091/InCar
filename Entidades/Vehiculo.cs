using System.ComponentModel.DataAnnotations;

namespace InCar.Entidades
{
  public class Vehiculo
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string Placa { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public int Modelo { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    public DateTime? FechaFabricacion { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string Color { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string Precio { get; set; }

    //propiedades de navegacion a las tablas relacionadas
    public TipoVehiculo TipoVehiculo { get; set; }
    public Marca Marca { get; set; }

  }
}
