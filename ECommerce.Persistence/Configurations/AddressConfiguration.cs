using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(q => q.Country)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(q => q.Region)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(q => q.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(q => q.ZipCode)
                .IsRequired()
                .HasMaxLength(6);

            builder.Property(q => q.StreetAddress)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(e => e.Orders)
               .WithOne(e => e.Address)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
