using EFCoreFilms.entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFilms
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gender>().HasKey(prop => prop.Identifier);
            modelBuilder.Entity<Gender>().Property(prop => prop.Name).HasMaxLength(150).IsRequired();

            modelBuilder.Entity<Actor>().Property(x=> x.Name).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Actor>().Property(x => x.BirthDate).HasColumnType("date");

            modelBuilder.Entity<Cinema>().Property(x => x.Name).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Cinema>().Property(x => x.Price).HasPrecision(precision: 9, scale: 2);

            modelBuilder.Entity<Films>().Property(x => x.Title).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<Films>().Property(x => x.ReleaseDate).HasColumnType("date");
            modelBuilder.Entity<Films>().Property(x => x.posterURL).HasMaxLength(500).IsUnicode(false);
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Films> Films { get; set; }
    }
}
