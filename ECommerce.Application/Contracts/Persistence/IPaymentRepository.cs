using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        //Task<List<Payment>> GetListAsync(ProductFilterDto filter, IPager pager);
        Task<Payment?> GetAsync(long id);
        //Task<bool> HasUniqueName(string name);
    }
}
