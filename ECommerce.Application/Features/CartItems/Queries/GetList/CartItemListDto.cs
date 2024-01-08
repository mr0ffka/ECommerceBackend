using ECommerce.Application.Models.Simple.Product;

namespace ECommerce.Application.Features.CartItems.Queries.GetList
{
    public class CartItemListDto
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public SimpleProductDto Product { get; set; }
    }
}
