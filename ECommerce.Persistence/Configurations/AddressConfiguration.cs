using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasIndex(x => x.PublicId, "IX_Address_PublicId")
                .IsUnique();

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder
                .Property(e => e.PublicId)
                .HasMaxLength(36)
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsFixedLength();

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
