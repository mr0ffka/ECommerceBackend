using ECommerce.Application.Models.Pager;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Queries.GetList
{
    public record GetListQuery(AddressFilterDto filter, Pager pager) : IRequest<PagedResult<AddressListDto>>;
}
