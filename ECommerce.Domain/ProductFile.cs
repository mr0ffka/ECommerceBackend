using ECommerce.Domain.Common;

namespace ECommerce.Domain
{
    public class ProductFile : BaseEntity
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long FileId { get; set; }
        public File File { get; set; }
    }
}
