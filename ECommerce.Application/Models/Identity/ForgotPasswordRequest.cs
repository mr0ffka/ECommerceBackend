using ECommerce.Application.Extensions;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.Models.Identity
{
    public class ForgotPasswordRequest : IValidatableObject
    {
        public string? Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return this.Rules<ForgotPasswordRequest>(v =>
            {
                v.RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
                v.RuleFor(x => x.Email).EmailAddress().WithMessage("Incorrect email address");
            })
            .Validate(this, options => options.ThrowOnFailures())
            .Result();
        }
    }
}
