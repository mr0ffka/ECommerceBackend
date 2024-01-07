using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Extensions;
using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.Identity
{
    public class ResetPasswordResponse 
    {
        public bool Succeeded { get; set; }
    }
}
