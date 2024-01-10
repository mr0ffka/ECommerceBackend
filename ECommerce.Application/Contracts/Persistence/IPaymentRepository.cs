using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<Payment?> GetAsync(long id);
    }
}
