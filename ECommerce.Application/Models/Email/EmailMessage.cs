﻿namespace ECommerce.Application.Models.Email
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
