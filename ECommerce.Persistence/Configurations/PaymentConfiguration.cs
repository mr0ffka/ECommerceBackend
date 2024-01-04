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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasIndex(x => x.PublicId, "IX_Payment_PublicId")
                .IsUnique();

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder
                .Property(e => e.PublicId)
                .HasMaxLength(36)
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsFixedLength();

            builder.Property(q => q.Amount)
                .IsRequired()
                .HasDefaultValue(0m);

            builder.HasOne(x => x.Order)
                .WithOne(x => x.Payment)
                .HasForeignKey<Payment>(x => x.OrderId);
        }
    }
}
