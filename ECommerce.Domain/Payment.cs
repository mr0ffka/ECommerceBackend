using ECommerce.Domain.Common;
using ECommerce.Domain.Enumerations.Payments;

namespace ECommerce.Domain
{
    public class Payment : BaseEntity
    {
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Amount { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
