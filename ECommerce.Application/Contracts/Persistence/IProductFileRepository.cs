using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface IProductFileRepository : IGenericRepository<ProductFile>
    {
        Task<ProductFile?> GetAsync(long id);
        Task<ProductFile?> GetAsync(long productId, long fileId);
        Task<List<long>> GetFileIdsByProductIdAsync(long productId);
    }
}
