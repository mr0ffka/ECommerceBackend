using ECommerce.Application.Models.Identity;
using ECommerce.Application.Models.Simple.Product;

namespace ECommerce.Application.Features.CartItems.Queries.GetById
{
    public class CartItemDto
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public UserDto User { get; set; }
        public SimpleProductDto Product { get; set; }
    }
}
