using ECommerce.Domain.Common;

namespace ECommerce.Domain
{
    public class UserUsedCoupon : BaseEntity
    {
        public string UserId { get; set; }
        public long CouponId { get; set; }
    }
}
