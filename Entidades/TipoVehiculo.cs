﻿using System.ComponentModel.DataAnnotations;

namespace InCar.Entidades
{
  public class TipoVehiculo
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo {0} es requerido")]
    [StringLength(10)]
    public string Tipo { get; set; }
  }
}
