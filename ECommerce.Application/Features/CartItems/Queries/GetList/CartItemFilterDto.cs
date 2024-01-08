using ECommerce.Application.Contracts.Common;

namespace ECommerce.Application.Features.CartItems.Queries.GetList
{
    public class CartItemFilterDto : IFilter
    {
        public long? ProductId { get; set; }
    }
}
