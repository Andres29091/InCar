using InCar.Entidades;
using InCar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InCar.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Procedimiento> Procedimiento { get; set; }
    public DbSet<Detalle> Detalle { get; set; }
    public DbSet<Historial> Historial { get; set; }
    public DbSet<ImagenVehiculo> ImagenVehiculo { get; set; }
    public DbSet<Vehiculo> Vehiculo { get; set; }
    public DbSet<Marca> Marca { get; set; }
    public DbSet<TipoVehiculo> TipoVehiculo { get; set; }
    public DbSet<TipoDocumento> TipoDocumento { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
  }
}
