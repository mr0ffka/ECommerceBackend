using ECommerce.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Contracts.Email
{
    public interface IEmailPreperer
    {
        EmailMessage PrepareEmail();
    }
}
