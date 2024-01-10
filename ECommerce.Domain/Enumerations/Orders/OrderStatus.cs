using System.ComponentModel;

namespace ECommerce.Domain.Enumerations.Orders
{
    public enum OrderStatus
    {
        [Description("Pending")]
        Pending = 0,
        [Description("Processing")]
        Processing = 1,
        [Description("Confirmed")]
        Confirmed = 2,
        [Description("Shipped")]
        Shipped = 3,
        [Description("InTransit")]
        InTransit = 4,
        [Description("Delivered")]
        Delivered = 5,
        [Description("OnHold")]
        OnHold = 6,
        [Description("Cancelled")]
        Cancelled = 7,
        [Description("Returned")]
        Returned = 8,
        [Description("Failed")]
        Failed = 9,
        [Description("Complited")]
        Complited = 10
    }
}
