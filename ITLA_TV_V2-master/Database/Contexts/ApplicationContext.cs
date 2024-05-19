using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options) { }

        public DbSet<Usuario>  Usuarios { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Productora> Productoras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tablas

            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Serie>().ToTable("Serie");
            modelBuilder.Entity<Genero>().ToTable("Genero");
            modelBuilder.Entity<Productora>().ToTable("Productora");

            #endregion

            #region primaryKeys
            modelBuilder.Entity<Usuario>().HasKey(usuario => usuario.Id);
            modelBuilder.Entity<Serie>().HasKey(serie => serie.SerieId);
            modelBuilder.Entity<Genero>().HasKey(genero => genero.GeneroId);
            modelBuilder.Entity<Productora>().HasKey(productora => productora.ProductoraId);
            #endregion

            #region "foreignKeys / relationships"
            modelBuilder.Entity<Genero>() //Generos a serie -- Muchos a uno
                .HasMany(e => e.Series)
                .WithOne(e => e.Genero)
                .HasForeignKey(e => e.GeneroPrimarioId)
                .IsRequired();

            modelBuilder.Entity<Productora>() //Productoras a serie -- Muchos a uno
                .HasMany(e => e.Series)
                .WithOne(e => e.Productora)
                .HasForeignKey(e => e.ProductoraId)
                .IsRequired();
            #endregion

            #region "configuracion de propiedades"

            //Configurando las propiedades de mis columnas
            #region Usuario
            modelBuilder.Entity<Usuario>()
                       .Property(s => s.NombreUsuario)
                       .IsRequired()
                       .HasMaxLength(40);

            modelBuilder.Entity<Usuario>()
                   .Property(s => s.Contraseña)
                   .IsRequired()
                   .HasMaxLength(40);

            #endregion
            #region serie
            modelBuilder.Entity<Serie>()
                        .Property(s => s.SerieName)
                        .IsRequired()
                        .HasMaxLength(40);

            modelBuilder.Entity<Serie>()
                        .Property(s => s.ImagePath)
                        .IsRequired()
                        .HasMaxLength(255);

            modelBuilder.Entity<Serie>()
                        .Property(s => s.VideoPath)
                        .IsRequired()
                        .HasMaxLength(255);

            modelBuilder.Entity<Serie>()
                       .Property(s => s.Descripcion)
                       .IsRequired()
                       .HasMaxLength(1000);

            modelBuilder.Entity<Serie>()
                       .Property(s => s.Actores)
                       .IsRequired()
                       .HasMaxLength(40);

            modelBuilder.Entity<Serie>()
                     .Property(s => s.Director)
                     .IsRequired()
                     .HasMaxLength(40);

            modelBuilder.Entity<Serie>()
                     .Property(s => s.Año)
                     .IsRequired();
                   


            #endregion

            #region genero
            modelBuilder.Entity<Genero>()
                        .Property(g => g.GeneroName)
                        .IsRequired()
                        .HasMaxLength(40);
            #endregion

            #region productora
            modelBuilder.Entity<Productora>()
                        .Property(p => p.ProductoraName)
                        .IsRequired()
                        .HasMaxLength(40);
            #endregion

            #endregion
        }

    }
}
