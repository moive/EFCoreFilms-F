using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreFilms.entities.configurations
{
    public class CinemaRoomConfig : IEntityTypeConfiguration<CinemaRoom>
    {
        public void Configure(EntityTypeBuilder<CinemaRoom> builder)
        {
            builder.Property(x => x.Price).HasPrecision(precision: 9, scale: 2);
            builder.Property(x => x.CinemaType).HasDefaultValue(CinemaType.TwoDimensions);
        }
    }
}
