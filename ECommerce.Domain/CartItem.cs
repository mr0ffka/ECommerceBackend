using ECommerce.Domain.Common;

namespace ECommerce.Domain
{
    public class CartItem : BaseEntity
    {
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
