using ECommerce.Domain.Common;
using ECommerce.Domain.Enumerations.Orders;

namespace ECommerce.Domain
{
    public class OrderHistory : BaseEntity
    {
        public OrderStatus Status { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
