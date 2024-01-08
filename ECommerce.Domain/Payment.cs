using ECommerce.Domain.Common;

namespace ECommerce.Domain
{
    public class Payment : BaseEntity
    {
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
