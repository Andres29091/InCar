using System.ComponentModel.DataAnnotations;

namespace InCar.Entidades
{
  public class Marca
    {
    public int Id { get; set; }
    

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(20)]
    public string Tipo { get; set; }

    //relacion uno a muchos con Vehiculo
    public List<Vehiculo> Vehiculos { get; set; }



    }
}
