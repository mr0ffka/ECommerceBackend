using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.Email
{
    public class EmailMessage
    {
        public string ToAddress { get; set; } = string.Empty;
        public string ToName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string TextBody { get; set; } = string.Empty;
        public string HtmlBody { get; set; } = string.Empty;
    }
}
