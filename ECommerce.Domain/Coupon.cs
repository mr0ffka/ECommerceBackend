using ECommerce.Domain.Common;

namespace ECommerce.Domain
{
    public class Coupon : BaseEntity
    {
        public string Code { get; set; }
        public DateTime ValidFromUtc { get; set; }
        public DateTime ValidToUtc { get; set; }
        public int Percentage { get; set; }
        public int? AvailableAmount { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<UserUsedCoupon> Users { get; set; } = new HashSet<UserUsedCoupon>();
    }
}
