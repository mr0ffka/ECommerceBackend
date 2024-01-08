using ECommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.Addresses.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        private readonly IAddressRepository _repository;

        public CreateCommandValidator(IAddressRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Country)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(70).WithMessage("{PropertyName} cannot have more than 70 characters");

            RuleFor(p => p.Region)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} cannot have more than 100 characters");

            RuleFor(p => p.City)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} cannot have more than 100 characters");

            RuleFor(p => p.ZipCode)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Matches(@"^\d{2}-\d{3}$")
                .WithMessage("{PropertyName} must follow the format: DD-DDD where D is a digit.");

            RuleFor(p => p.StreetAddress)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} cannot have more than 100 characters");
        }
    }
}
