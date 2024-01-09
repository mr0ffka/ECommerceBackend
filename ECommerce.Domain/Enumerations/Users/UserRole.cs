using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Enumerations.Users
{
    public enum UserRole
    {
        [Description("Administrator")]
        Administrator,
        [Description("User")]
        User
    }
}
