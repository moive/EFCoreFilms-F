using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreFilms.entities.configurations
{
    public class FilmActorConfig : IEntityTypeConfiguration<FilmActor>
    {
        public void Configure(EntityTypeBuilder<FilmActor> builder)
        {
            builder.HasKey(prop => new { prop.FilmId, prop.ActorId });

            builder.HasOne(pa => pa.Actor)
                .WithMany(a => a.FilmsActors)
                .HasForeignKey(pa => pa.ActorId);

            builder.HasOne(pa => pa.Film)
                .WithMany(p => p.FilmsActors)
                .HasForeignKey(pa => pa.FilmId);

            builder.Property(x => x.Character).HasMaxLength(150);
        }
    }
}
