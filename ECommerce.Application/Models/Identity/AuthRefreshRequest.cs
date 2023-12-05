using ECommerce.Application.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.Identity
{
    public class AuthRefreshRequest
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
