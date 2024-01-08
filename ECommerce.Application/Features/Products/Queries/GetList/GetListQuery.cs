using ECommerce.Application.Models.Pager;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetList
{
    public record GetListQuery(ProductFilterDto filter, Pager pager) : IRequest<PagedResult<ProductDto>>;
}
