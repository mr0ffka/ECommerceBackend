using ECommerce.Domain.Common;

namespace ECommerce.Domain
{
    public class OrderHistory : BaseEntity
    {
        public string Status { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
