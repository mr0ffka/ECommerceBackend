﻿using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Extensions;
using ECommerce.Application.Features.Example.Commands.CreateExample;
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
    public class ResetPasswordRequest : IValidatableObject
    {
        public string? UserId { get; set; }
        public string? ResetToken { get; set; }
        public string? NewPassword { get; set; }
        public string? NewPasswordConfirm { get; set; }

        public IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            return this.Rules<ResetPasswordRequest>(v =>
            {
                v.RuleFor(x => x.UserId).NotEmpty().WithMessage("Incorrect user");
                v.RuleFor(x => x.ResetToken).NotEmpty().WithMessage("Incorrect reset password code");
                v.RuleFor(x => x.NewPassword).NotEmpty().Equal(p => p.NewPasswordConfirm).WithMessage("Passwords must be the same");
                v.RuleFor(x => x.NewPassword).Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$").WithMessage("Incorrect password");

            })
            .Validate(this, options => options.ThrowOnFailures())
            .Result();
        }
    }
}
