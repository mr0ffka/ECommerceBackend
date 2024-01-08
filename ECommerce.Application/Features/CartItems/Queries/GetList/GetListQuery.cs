using ECommerce.Application.Models.Pager;
using MediatR;

namespace ECommerce.Application.Features.CartItems.Queries.GetList
{
    public record GetListQuery(CartItemFilterDto filter, Pager pager) : IRequest<PagedResult<CartItemListDto>>;
}
