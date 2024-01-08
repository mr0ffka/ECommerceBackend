using ECommerce.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            var hasher = new PasswordHasher<AppUser>();
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "37d59905-2282-4f0d-b72d-9bb08cdd20ed",
                    UserId = "d3c78dce-d413-4345-b5e6-004667574c82"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "31a298c2-1333-4896-93b5-682663130265",
                    UserId = "421bba63-e34f-4308-b737-61c59c316b86"
                }
            );
        }
    }
}
