using ECommerce.Domain.Common;
using ECommerce.Domain.Enumerations.Payments;

namespace ECommerce.Domain
{
    public class PaymentHistory : BaseEntity
    {
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public long PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
