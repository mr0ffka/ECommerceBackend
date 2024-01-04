using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
