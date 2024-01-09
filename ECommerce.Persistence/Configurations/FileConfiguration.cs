using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<Domain.File>
    {
        public void Configure(EntityTypeBuilder<Domain.File> builder)
        {
            builder.ToTable("Files");

            builder
                .Property(e => e.Id).UseIdentityAlwaysColumn();

            builder.Property(q => q.Name)
                .IsRequired();

            builder.Property(q => q.Path)
                .IsRequired();

            builder.Property(q => q.ContentType)
                .IsRequired();

            builder.HasMany(e => e.Products)
               .WithOne(e => e.File)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
