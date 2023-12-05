using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.Email
{
    public class EmailSettings
    {
        public string Server { get; set; } = string.Empty;
        public int Port { get; set; }
        public string SenderName { get; set; } = string.Empty;
        public string SenderEmail { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool UseSsl { get; set; } = false;
        public bool WithoutCredentials { get; set; } = true;
    }
}
