using System.ComponentModel;

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
