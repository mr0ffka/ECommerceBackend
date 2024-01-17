using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class File : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<ProductFile> Products { get; set; } = new HashSet<ProductFile>();

    }
}
