using MediatR;

namespace ECommerce.Application.Features.Coupons.Queries.GetByCode
{
    public record GetByCodeQuery(string Code) : IRequest<CouponDto>;
}
