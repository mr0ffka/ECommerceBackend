using ECommerce.Application.Features.CartItems.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;

namespace ECommerce.Application.Contracts.Persistence
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<List<CartItem>> GetListAsync(CartItemFilterDto filter, IPager pager);
        Task<CartItem?> GetAsync(long id);
        Task<CartItem?> GetAsync(string userId, long productId);
        Task<bool> Exists(CartItem item);
    }
}
