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
            builder.Property(x => x.Character).HasMaxLength(150);
        }
    }
}
