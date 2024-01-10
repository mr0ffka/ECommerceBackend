using MediatR;

namespace ECommerce.Application.Features.Payments.Queries.GetPaymentByOrderId
{
    public record GetPaymentByOrderIdQuery(long orderId) : IRequest<PaymentDto>;

}
