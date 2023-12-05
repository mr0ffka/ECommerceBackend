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
    public class AuthRequest : IValidatableObject
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return this.Rules<AuthRequest>(v =>
            {
                v.RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
                v.RuleFor(x => x.Email).EmailAddress().WithMessage("Incorrect email address");
                v.RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
            })
            .Validate(this, options => options.ThrowOnFailures())
            .Result();
        }
    }
}
