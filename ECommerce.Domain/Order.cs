using ECommerce.Domain.Common;

namespace ECommerce.Domain
{
    public class Order : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        public long AddressId { get; set; }
        public Address Address { get; set; }
        public string UserId { get; set; }
        public long CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public long PaymentId { get; set; }
        public Payment Payment { get; set; }    
        public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new HashSet<OrderHistory>();
        public virtual ICollection<OrderItem> OrderItems{ get; set; } = new HashSet<OrderItem>();

    }
}
