using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class Payment : BaseEntity
    {
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
