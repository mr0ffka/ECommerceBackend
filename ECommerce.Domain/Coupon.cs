using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class Coupon : BaseEntity
    {
        public DateTime ValidFromUtc { get; set; }
        public DateTime ValidToUtc { get; set; }
        public int Percentage { get; set; }


        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
