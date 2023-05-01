using EFCoreFilms.entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreFilms
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Gender> Genders { get; set; }
    }
}
