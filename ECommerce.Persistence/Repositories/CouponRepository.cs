using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.Coupons.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;
using ECommerce.Persistence.DbContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class CouponRepository : GenericRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<Coupon?> GetAsync(long id)
        {
            return await _context.Coupons
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Coupon?> GetByCodeAsync(string code)
        {
            return await _context.Coupons
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<List<Coupon>> GetListAsync(CouponFilterDto filter, IPager pager)
        {
            var predicate = PredicateBuilder.New<Coupon>(true);

            if (!string.IsNullOrEmpty(filter.Code))
            {
                predicate.And(x => x.Code.ToLower().Contains(filter.Code.ToLower()));
            }

            if (filter.ValidFromUtc != null)
            {
                if (filter.ValidFromUtc.FromUtc != null && filter.ValidFromUtc.ToUtc != null)
                {
                    predicate.And(x =>
                        x.ValidFromUtc.Date >= filter.ValidFromUtc.FromUtc.Value.Date &&
                        x.ValidFromUtc.Date <= filter.ValidFromUtc.ToUtc.Value.Date
                    );
                }
                else if (filter.ValidFromUtc.FromUtc != null && filter.ValidFromUtc.ToUtc == null)
                {
                    predicate.And(x => x.ValidFromUtc.Date >= filter.ValidFromUtc.FromUtc.Value.Date);
                }
                else if (filter.ValidFromUtc.ToUtc != null && filter.ValidFromUtc.FromUtc == null)
                {
                    predicate.And(x => x.ValidFromUtc.Date <= filter.ValidFromUtc.ToUtc.Value.Date);
                }
            }

            if (filter.ValidToUtc != null)
            {
                if (filter.ValidToUtc.FromUtc != null && filter.ValidToUtc.ToUtc != null)
                {
                    predicate.And(x =>
                        x.ValidToUtc.Date >= filter.ValidToUtc.FromUtc.Value.Date &&
                        x.ValidToUtc.Date <= filter.ValidToUtc.ToUtc.Value.Date
                    );
                }
                else if (filter.ValidToUtc.FromUtc != null && filter.ValidToUtc.ToUtc == null)
                {
                    predicate.And(x => x.ValidToUtc.Date >= filter.ValidToUtc.FromUtc.Value.Date);
                }
                else if (filter.ValidToUtc.ToUtc != null && filter.ValidToUtc.FromUtc == null)
                {
                    predicate.And(x => x.ValidToUtc.Date <= filter.ValidToUtc.ToUtc.Value.Date);
                }
            }

            if (filter.PercentageFrom.HasValue)
            {
                predicate.And(x => x.Percentage >= filter.PercentageFrom.Value);
            }

            if (filter.PercentageTo.HasValue)
            {
                predicate.And(x => x.Percentage <= filter.PercentageTo.Value);
            }

            return await _context.Coupons
                .AsNoTracking()
                .Where(predicate)
                .PaginateData(pager)
                .ToListAsync();
        }

        public async Task<bool> HasUniqueCode(long? id, string code)
        {
            var predicate = PredicateBuilder.New<Coupon>(true);

            if (id.HasValue)
            {
                predicate.And(x => x.Id != id.Value);
            }

            predicate.And(x => x.Code == code);

            return !(await _context.Coupons.Where(predicate).AnyAsync());
        }
    }
}
