using ECommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.Categories.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCommandValidator(ICategoryRepository repository)
        {
            _repository = repository;

            RuleFor(p => p)
                .MustAsync(Exists)
                .WithMessage("Category do not exists");

            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p)
                .MustAsync(NameUnique)
                .WithMessage("Category name already exists");
        }

        private Task<bool> NameUnique(UpdateCommand command, CancellationToken token)
        {
            return _repository.HasUniqueName(command.Id, command.Name);
        }

        private async Task<bool> Exists(UpdateCommand command, CancellationToken token)
        {
            return await _repository.Exists(command.Id);
        }
    }
}
