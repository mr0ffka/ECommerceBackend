using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class Address : BaseEntity
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }

        public string UserId { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
