using IBGE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBGE.Data.Mappings
{
    public class IbgeMap : IEntityTypeConfiguration<Ibge>
    {
        public void Configure(EntityTypeBuilder<Ibge> builder)
        {
            builder.ToTable("IBGE");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(7);

            builder.Property(x => x.State)
                .HasMaxLength(2);

            builder.Property(x => x.City)
                .HasMaxLength(80);
        }
    }
}
