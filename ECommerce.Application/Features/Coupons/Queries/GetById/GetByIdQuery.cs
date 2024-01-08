using MediatR;

namespace ECommerce.Application.Features.Coupons.Queries.GetById
{
    public record GetByIdQuery(long Id) : IRequest<CouponDto>;
}
