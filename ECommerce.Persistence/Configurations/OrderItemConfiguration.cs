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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(q => q.Quantity)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(q => q.Price)
                .IsRequired()
                .HasDefaultValue(0m);

            builder.HasOne(l => l.Order)
               .WithMany(c => c.OrderItems)
               .HasForeignKey(c => c.OrderId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_OrderItem_OrderId");

            builder.HasOne(l => l.Product)
               .WithMany(c => c.OrderItems)
               .HasForeignKey(c => c.ProductId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_OrderItem_ProductId");
        }
    }
}
