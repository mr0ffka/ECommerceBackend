using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetListAsync(ProductFilterDto filter, IPager pager);
        Task<Product?> GetAsync(long id);
        Task<bool> HasUniqueName(long? id, string name);

    }
}
