using ECommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.Addresses.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        private readonly IAddressRepository _repository;

        public UpdateCommandValidator(IAddressRepository repository)
        {
            _repository = repository;

            RuleFor(p => p)
                .MustAsync(Exists)
                .WithMessage("Address do not exists");

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

        private async Task<bool> Exists(UpdateCommand command, CancellationToken token)
        {
            return await _repository.Exists(command.Id);
        }
    }
}
