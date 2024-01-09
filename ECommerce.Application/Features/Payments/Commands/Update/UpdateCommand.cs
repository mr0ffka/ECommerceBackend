using ECommerce.Domain.Enumerations.Payments;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.Update
{
    public class UpdateCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public long OrderId { get; set; }
    }
}
