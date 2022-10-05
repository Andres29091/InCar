using Microsoft.EntityFrameworkCore;

namespace InCar.Data
{
  public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions options): base (options)
        {

        }

        //protected override void  OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<PeliculasGeneros>()
        //        .HasKey(x => new { x.GeneroId, x.PeliculaId });

        //    base.OnModelCreating(modelBuilder);

        //}



        //public DbSet<Genero> Genero { get; set; }

        //public DbSet<Actor> Actores{ get; set; }

        //public DbSet<Pelicula> Pelicula { get; set; }

        //public DbSet<PeliculasGeneros> PeliculasGeneros { get; set; }
        //public DbSet<IdentityModels> Users { get; set; }

    }
}
