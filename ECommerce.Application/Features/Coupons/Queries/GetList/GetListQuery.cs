using ECommerce.Application.Models.Pager;
using MediatR;

namespace ECommerce.Application.Features.Coupons.Queries.GetList
{
    public record GetListQuery(CouponFilterDto filter, Pager pager) : IRequest<PagedResult<CouponListDto>>;
}
