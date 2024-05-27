using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreFilms.entities.configurations
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();

            builder.Property(x=> x.Name).HasField("_name");

            //builder.Ignore(a => a.Age); // not save field age in database
            //builder.Ignore(a => a.Address);
        }
    }
}
