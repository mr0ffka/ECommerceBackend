using ECommerce.Application.Contracts.Persistence;
using ECommerce.Domain;
using ECommerce.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class ProductFileRepository : GenericRepository<ProductFile>, IProductFileRepository
    {
        public ProductFileRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<ProductFile?> GetAsync(long id)
        {
            return await _context.ProductFiles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductFile?> GetAsync(long productId, long fileId)
        {
            return await _context.ProductFiles
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProductId == productId && x.FileId == fileId);
        }

        public async Task<List<long>> GetFileIdsByProductIdAsync(long productId)
        {
            return await _context.ProductFiles
                .Where(x => x.ProductId == productId)
                .Select(x => x.FileId)
                .ToListAsync();
        }

        public async Task<List<string>> GetFileUrlsByProductIdAsync(long productId)
        {
            return await _context.ProductFiles
                .Include(x => x.File)
                .Where(x => x.ProductId == productId)
                .Select(x => x.File.Path.Substring(3))
                .ToListAsync();
        }
    }
}
