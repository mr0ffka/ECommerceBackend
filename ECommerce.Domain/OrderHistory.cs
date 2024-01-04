﻿using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain
{
    public class OrderHistory : BaseEntity
    {
        public string Status { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
