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

        public DbSet<Address> Addresses { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ECommerceDbContext).Assembly);

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var states = new List<EntityState> 
            { 
                EntityState.Added,
                EntityState.Modified
            };

            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => states.Contains(q.State))) 
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
