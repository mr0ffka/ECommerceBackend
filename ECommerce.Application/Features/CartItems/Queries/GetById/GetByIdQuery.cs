using MediatR;

namespace ECommerce.Application.Features.CartItems.Queries.GetById
{
    public record GetByIdQuery(long Id) : IRequest<CartItemDto>;
}
