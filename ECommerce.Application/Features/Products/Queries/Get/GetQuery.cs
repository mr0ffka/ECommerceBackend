using MediatR;

namespace ECommerce.Application.Features.Products.Queries.Get
{
    public record GetQuery(long Id) : IRequest<ProductDetailsDto>;
}
