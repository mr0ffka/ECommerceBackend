using ECommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.Coupons.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        private readonly ICouponRepository _repository;

        public CreateCommandValidator(ICouponRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Code)
                .Length(5, 25)
                .Matches(@"\A\S+\z")
                .WithMessage("{PropertyName} has to be from 5 to 25 characters without whitespaces");

            RuleFor(p => p)
                .MustAsync(Unique)
                .WithMessage("Coupon code already exists. Coupon code has to be unique");

            RuleFor(p => p.ValidToUtc)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.ValidToUtc)
                .GreaterThan(x => x.ValidFromUtc)
                .WithMessage("{PropertyName} has to be greater than ValidFromUtc");

            RuleFor(p => p.Percentage)
                .GreaterThan(0)
                .LessThanOrEqualTo(100)
                .WithMessage("{PropertyName} has to be greater than 0 and less than or equal to 100");
        }

        private async Task<bool> Unique(CreateCommand command, CancellationToken token)
        {
            return await _repository.HasUniqueCode(null, command.Code);
        }
    }
}
