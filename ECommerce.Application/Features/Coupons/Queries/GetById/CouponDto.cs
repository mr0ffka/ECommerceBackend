using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Coupons.Queries.GetById
{
    public class CouponDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime ValidFromUtc { get; set; } = DateTime.UtcNow;
        public DateTime ValidToUtc { get; set; }
        public int Percentage { get; set; }
        //public List<Order> Orders { get; set; } = new List<Order>();
    }
}
