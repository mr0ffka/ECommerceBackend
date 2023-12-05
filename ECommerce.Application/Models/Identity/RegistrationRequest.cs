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
    public class RegistrationRequest : IValidatableObject
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordConfirmation { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            return this.Rules<RegistrationRequest>(v =>
            {
                v.RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
                v.RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
                v.RuleFor(x => x.Password).NotEmpty().Equal(p => p.PasswordConfirmation).WithMessage("Passwords must be the same");
                v.RuleFor(x => x.Password).Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$").WithMessage("Incorrect password");
                v.RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
                v.RuleFor(x => x.Email).EmailAddress().WithMessage("Incorrect email address");
            })
            .Validate(this, options => options.ThrowOnFailures())
            .Result();
        }
    }
}
