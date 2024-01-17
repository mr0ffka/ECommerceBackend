using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Extensions;
using ECommerce.Application.Features.Coupons.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;
using ECommerce.Persistence.DbContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class UserCouponRepository : GenericRepository<UserUsedCoupon>, IUserCouponRepository
    {
        private readonly ICouponRepository _couponRepository;

        public UserCouponRepository(ECommerceDbContext context, ICouponRepository couponRepository) : base(context)
        {
            _couponRepository = couponRepository;
        }

        public async Task<bool> IsValidForUser(string couponCode, string userId)
        {
            var now = DateTime.UtcNow;
            var coupon = await _couponRepository.GetByCodeAsync(couponCode);
            if (coupon is null || !now.IsDateInRange(coupon.ValidFromUtc, coupon.ValidToUtc)) 
                return false;

            return !(await _context.UserUsedCoupons.AnyAsync(x => x.UserId == userId && x.CouponId == coupon.Id));
        }
    }
}
