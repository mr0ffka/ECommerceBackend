using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public string PublicId { get; set; } = string.Empty;
        public DateTime? DateCreatedUtc { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModifiedUtc { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
