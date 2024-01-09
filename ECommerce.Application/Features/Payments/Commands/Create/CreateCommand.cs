using ECommerce.Domain.Enumerations.Payments;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.Create
{
    public class CreateCommand : IRequest<long>
    {
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public long OrderId { get; set; }
    }
}
