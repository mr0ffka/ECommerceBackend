using ECommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.Categories.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        private readonly ICategoryRepository _repository;

        public CreateCommandValidator(ICategoryRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p)
                .MustAsync(Unique)
                .WithMessage("Category already exists");
        }

        private Task<bool> Unique(CreateCommand command, CancellationToken token)
        {
            return _repository.HasUniqueName(command.Name);
        }
    }
}
