using EFCoreFilms.entities;
using EFCoreFilms.entities.configurations;
using EFCoreFilms.entities.keyless;
using EFCoreFilms.entities.seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCoreFilms
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new GenderConfig()); // implementing one by one 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingConsultModule.Seed(modelBuilder);
            SeedingPersonMessage.Seed(modelBuilder);
            //modelBuilder.Entity<Log>().Property(l=>l.Id).ValueGeneratedNever(); // no generate guid
            //modelBuilder.Ignore<Address>();
            modelBuilder.Entity<CinemaNoLocation>()
                .HasNoKey().ToSqlQuery("Select Id, Name FROM Cinemas").ToView(null);
            modelBuilder.Entity<FilmsWithCount>().HasNoKey().ToView("FilmsWithCount");
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Films> Films { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<CinemaRoom> CinemaRooms { get; set; }
        public DbSet<FilmActor> FilmsActors { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<CinemaNoLocation> CinemaNoLocations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CinemaDetail> CinemaDetails { get; set; }
    }
}
