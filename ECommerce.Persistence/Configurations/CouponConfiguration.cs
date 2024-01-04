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
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.ToTable("Coupons");

            builder.HasIndex(x => x.PublicId, "IX_Coupon_PublicId")
                .IsUnique();

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder
                .Property(e => e.PublicId)
                .HasMaxLength(36)
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsFixedLength();

            builder.Property(q => q.ValidFromUtc)
                .IsRequired();

            builder.Property(q => q.ValidToUtc)
                .IsRequired();

            builder.Property(q => q.Percentage)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasMany(e => e.Orders)
               .WithOne(e => e.Coupon)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
