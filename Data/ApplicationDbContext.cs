using InCar.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InCar.Data
{
  public class ApplicationDbContext : DbContext
  {

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<Detalle> Detalle { get; set; }
    public DbSet<Historial> Historial { get; set; }
    public DbSet<ImagenVehiculo> ImagenVehiculo { get; set; }
    public DbSet<Marca> Marca { get; set; }
    public DbSet<Procedimiento> Procedimiento { get; set; }
    public DbSet<TipoDocumento> TipoDocumento { get; set; }
    public DbSet<TipoVehiculo> TipoVehiculo { get; set; }
    public DbSet<Vehiculo> Vehiculo { get; set; }

    //protected override void  OnModelCreating(ModelBuilder modelBuilder)
    //{

    //    modelBuilder.Entity<PeliculasGeneros>()
    //        .HasKey(x => new { x.GeneroId, x.PeliculaId });

    //    base.OnModelCreating(modelBuilder);

    //}

  }
}
