using ECommerce.Application.Models.Common;
using MediatR;

namespace ECommerce.Application.Features.Payments.Queries.GetPaymentMethodList
{
    public record GetPaymentMethodListQuery() : IRequest<List<EnumValueDescription>>;
}
