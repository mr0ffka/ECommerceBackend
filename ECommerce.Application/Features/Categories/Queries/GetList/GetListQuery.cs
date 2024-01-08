using ECommerce.Application.Models.Pager;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetList
{
    public record GetListQuery(CategoryFilterDto filter, Pager pager) : IRequest<PagedResult<CategoryListDto>>;
}
