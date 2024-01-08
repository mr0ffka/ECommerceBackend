using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(q => q.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(e => e.Products)
               .WithOne(e => e.Category)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
