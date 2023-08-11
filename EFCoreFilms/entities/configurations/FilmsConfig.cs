using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreFilms.entities.configurations
{
    public class FilmsConfig : IEntityTypeConfiguration<Films>
    {
        public void Configure(EntityTypeBuilder<Films> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(250).IsRequired();
            builder.Property(x => x.posterURL).HasMaxLength(500).IsUnicode(false);
        }
    }
}
