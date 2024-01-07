using ECommerce.Application.Contracts.Common;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;
using ECommerce.Persistence.DbContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceDbContext context) : base(context)
        {

        }

        public async Task<List<Category>> GetListAsync(CategoryFilterDto filter, IPager pager)
        {
            var predicate = PredicateBuilder.New<Category>(true);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                predicate.And(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            return await _context.Categories
                .AsNoTracking()
                .Where(predicate)
                .PaginateData(pager)
                .ToListAsync();
        }

        public async Task<bool> HasUniqueName(string name)
        {
            return !(await _context.Categories.AnyAsync(x => x.Name == name));
        }
    }
}
