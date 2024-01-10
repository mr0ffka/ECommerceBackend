using ECommerce.Domain.Enumerations.Payments;

namespace ECommerce.Application.Features.Payments.Queries.GetPaymentByOrderId
{
    public class PaymentHistoryDto
    {
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreatedUtc { get; set; }

    }
}
