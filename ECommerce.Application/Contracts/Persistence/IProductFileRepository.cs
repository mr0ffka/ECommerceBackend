using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface IProductFileRepository : IGenericRepository<ProductFile>
    {
        Task<ProductFile?> GetAsync(long id);
        Task<ProductFile?> GetAsync(long productId, long fileId);
        Task<List<long>> GetFileIdsByProductIdAsync(long productId);
        Task<List<string>> GetFileUrlsByProductIdAsync(long productId);
    }
}
