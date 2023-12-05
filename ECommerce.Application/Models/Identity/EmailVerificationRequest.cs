using ECommerce.Application.Extensions;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Application.Models.Identity
{
    public class EmailVerificationRequest : IValidatableObject
    {
        public string? Id { get; set; } = string.Empty;
        public string? VerificationCode { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return this.Rules<EmailVerificationRequest>(v =>
            {
                v.RuleFor(x => x.Id).NotEmpty().WithMessage("User id is required");
                v.RuleFor(x => x.VerificationCode).NotEmpty().WithMessage("Verification code is required");
            })
            .Validate(this, options => options.ThrowOnFailures())
            .Result();
        }
    }
}
