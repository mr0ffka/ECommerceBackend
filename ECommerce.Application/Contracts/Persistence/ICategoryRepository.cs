using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetListAsync(CategoryFilterDto filter, IPager pager);
        Task<bool> HasUniqueName(string name);

    }
}
