using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Enumerations.Payments
{
    public enum PaymentStatus
    {
        [Description("Pending")]
        Pending = 0,
        [Description("Cancelled")]
        Cancelled = 1,
        [Description("Failed")]
        Failed = 2,
        [Description("Completed")]
        Completed = 3 
    }
}
