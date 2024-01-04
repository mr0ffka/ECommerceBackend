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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasIndex(x => x.PublicId, "IX_Category_PublicId")
                .IsUnique();

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder
                .Property(e => e.PublicId)
                .HasMaxLength(36)
                .HasDefaultValueSql("uuid_generate_v4()")
                .IsFixedLength();

            builder.Property(q => q.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(e => e.Products)
               .WithOne(e => e.Category)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
