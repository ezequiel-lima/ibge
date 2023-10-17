using IBGE.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IBGE.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Address)
                    .HasColumnName("Email")
                    .IsRequired();

                email.Ignore(e => e.Notifications);
            });

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.Role)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}
