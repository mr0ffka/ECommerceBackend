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
    public class OrderHistoryConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder.ToTable("OrderHistories");

            builder.HasIndex(x => x.PublicId, "IX_OrderHistory_PublicId")
                .IsUnique();

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder
                .Property(e => e.PublicId)
                .HasMaxLength(36)
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsFixedLength();


            builder.Property(q => q.Status)
                .IsRequired();

            builder.HasOne(l => l.Order)
               .WithMany(c => c.OrderHistories)
               .HasForeignKey(c => c.OrderId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_OrderHistory_OrderId");
        }
    }
}
