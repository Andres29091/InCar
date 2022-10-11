using InCar.Entidades;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InCar.DTOs
{
  public class MarcaDTO
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(20)]
    public string Marca { get; set; }

    //relacion uno a muchos con Vehiculo
    [JsonIgnore]
    public List<Vehiculo> Vehiculos { get; set; }
  }
}


