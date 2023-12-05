using ECommerce.Application.Contracts.Identity;
using ECommerce.Domain;
using ECommerce.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.DbContext
{
    public class ECommerceDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IUserService _userService;

        public ECommerceDbContext(
            DbContextOptions<ECommerceDbContext> options,
            IUserService userService
        )
            : base(options)
        {
            _userService = userService;
        }

        public DbSet<Example> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresExtension("uuid-ossp");

            builder.ApplyConfigurationsFromAssembly(typeof(ECommerceDbContext).Assembly);

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified)) 
            {
                entry.Entity.DateModifiedUtc = DateTime.UtcNow;
                entry.Entity.ModifiedBy = _userService.CurrUserId;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreatedUtc = DateTime.UtcNow;
                    entry.Entity.CreatedBy = _userService.CurrUserId;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
