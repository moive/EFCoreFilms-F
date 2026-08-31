using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreFilms.entities.configurations
{
    public class CinemaConfig : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();

            builder
                .HasOne(c => c.CinemaOffer)
                .WithOne()
                .HasForeignKey<CinemaOffer>(co => co.CinemaId);

            builder
                .HasMany(c => c.Cinemaroom)
                .WithOne(s => s.Cinema)
                .HasForeignKey(s => s.CinemaId);
        }
    }
}
