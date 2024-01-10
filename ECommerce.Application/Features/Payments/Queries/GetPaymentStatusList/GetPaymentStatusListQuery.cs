using ECommerce.Application.Models.Common;
using MediatR;

namespace ECommerce.Application.Features.Payments.Queries.GetPaymentStatusList
{
    public record GetPaymentStatusListQuery() : IRequest<List<EnumValueDescription>>;
}
