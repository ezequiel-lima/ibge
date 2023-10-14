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

            builder.Property(x => x.CodeIbge)
                .HasMaxLength(7);

            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
