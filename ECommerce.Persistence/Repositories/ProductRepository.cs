using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;
using ECommerce.Persistence.DbContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<Product?> GetAsync(long id)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.Files)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetListAsync(ProductFilterDto filter, IPager pager)
        {
            var predicate = PredicateBuilder.New<Product>(true);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                predicate.And(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                predicate.And(x => x.Description.ToLower().Contains(filter.Description.ToLower()));
            }

            if (filter.PriceFrom.HasValue)
            {
                predicate.And(x => x.Price >=  filter.PriceFrom.Value);
            }

            if (filter.PriceTo.HasValue)
            {
                predicate.And(x => x.Price <= filter.PriceTo.Value);
            }

            if (filter.StockFrom.HasValue)
            {
                predicate.And(x => x.Stock >= filter.StockFrom.Value);
            }

            if (filter.StockTo.HasValue)
            {
                predicate.And(x => x.Stock <= filter.StockTo.Value);
            }

            if (filter.CategoryIds.Count > 0)
            {
                predicate.And(x => filter.CategoryIds.Contains(x.CategoryId));
            }

            return await _context.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .Where(predicate)
                .PaginateData(pager)
                .ToListAsync();
        }

        public async Task<bool> HasUniqueName(string name)
        {
            return !(await _context.Products.AnyAsync(x => x.Name == name));
        }
    }
}
