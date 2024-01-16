using ECommerce.Application.Features.Coupons.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface ICouponRepository : IGenericRepository<Coupon>
    {
        Task<List<Coupon>> GetListAsync(CouponFilterDto filter, IPager pager);
        Task<Coupon?> GetAsync(long id);
        Task<Coupon?> GetByCodeAsync(string code);
        Task<bool> HasUniqueCode(string name);

    }
}
