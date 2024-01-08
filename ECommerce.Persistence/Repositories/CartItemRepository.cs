using ECommerce.Application.Contracts.Identity;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.CartItems.Queries.GetList;
using ECommerce.Application.Models.Pager;
using ECommerce.Domain;
using ECommerce.Persistence.DbContext;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly IUserService _userService;

        public CartItemRepository(ECommerceDbContext context, IUserService userService) : base(context)
        {
            _userService = userService;
        }

        public async Task<CartItem?> GetAsync(long id)
        {
            return await _context.CartItems
                .AsNoTracking()
                .Include(x => x.Product)
                    .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Exists(CartItem item)
        {
            return await _context.CartItems
                .AnyAsync(x => x.UserId == item.UserId && x.ProductId == item.ProductId);
        }

        public async Task<CartItem?> GetAsync(string userId, long productId)
        {
            return await _context.CartItems
                .FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
        }

        public async Task<List<CartItem>> GetListAsync(CartItemFilterDto filter, IPager pager)
        {
            var predicate = PredicateBuilder.New<CartItem>(true);

            predicate.And(x => x.UserId.ToLower().Contains(_userService.CurrUserId.ToLower()));

            if (filter.ProductId != null)
            {
                predicate.And(x => x.ProductId == filter.ProductId.Value);
            }

            return await _context.CartItems
                .AsNoTracking()
                .Include(x => x.Product)
                    .ThenInclude(x => x.Category)
                .Where(predicate)
                .PaginateData(pager)
                .ToListAsync();
        }
    }
}
