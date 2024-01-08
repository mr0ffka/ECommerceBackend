using ECommerce.Domain.Common;

namespace ECommerce.Domain
{
    public class Coupon : BaseEntity
    {
        public string Code { get; set; }
        public DateTime ValidFromUtc { get; set; }
        public DateTime ValidToUtc { get; set; }
        public int Percentage { get; set; }


        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
