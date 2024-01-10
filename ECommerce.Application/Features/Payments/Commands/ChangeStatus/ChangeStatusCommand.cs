using ECommerce.Domain.Enumerations.Payments;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.ChangeStatus
{
    public class ChangeStatusCommand : IRequest<long>
    {
        public long PaymentId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
