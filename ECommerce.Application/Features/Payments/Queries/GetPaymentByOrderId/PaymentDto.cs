using ECommerce.Application.Models.Simple.Order;

namespace ECommerce.Application.Features.Payments.Queries.GetPaymentByOrderId
{
    public class PaymentDto
    {
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreatedUtc { get; set; }
        public DateTime DateModifiedUtc { get; set; }
        public SimpleOrderDto Order { get; set; }
        public List<PaymentHistoryDto> PaymentHistory { get; set; } = new List<PaymentHistoryDto>();

    }
}
