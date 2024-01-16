using ECommerce.Application.Features.Coupons.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface IUserCouponRepository : IGenericRepository<UserUsedCoupon>
    {
        Task<bool> IsValidForUser(string couponCode, string userId);
    }
}
