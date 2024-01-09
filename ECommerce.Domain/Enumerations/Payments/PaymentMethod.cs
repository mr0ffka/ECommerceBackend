using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Enumerations.Payments
{
    public enum PaymentMethod
    {
        [Description("None")]
        None = 0,
        [Description("Payment via online services")]
        Online = 1,
        [Description("Payment via credit/debit card")]
        Card = 2,
        [Description("Payment via bank transfer")]
        BankTransfer = 3
    }
}
