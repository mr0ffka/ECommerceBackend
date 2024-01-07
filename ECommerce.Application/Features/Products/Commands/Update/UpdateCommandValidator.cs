using ECommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCommandValidator(IProductRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;

            RuleFor(p => p)
                .MustAsync(Exists)
                .WithMessage("Product do not exists");

            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Price)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0m).WithMessage("{PropertyName} has to be greater than 0");

            RuleFor(p => p.Stock)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.CategoryId)
                .NotNull()
                .NotEmpty().WithMessage("Category is required");

            RuleFor(p => p)
                .MustAsync(NameUnique)
                .WithMessage($"Product name already exists.");

            RuleFor(p => p)
                .MustAsync(CategoryExists)
                .WithMessage("Product do not exists");
        }

        private Task<bool> NameUnique(UpdateCommand command, CancellationToken token)
        {
            return _repository.HasUniqueName(command.Name);
        }

        private async Task<bool> CategoryExists(UpdateCommand command, CancellationToken token)
        {
            return await _categoryRepository.Exists(command.CategoryId);
        }

        private async Task<bool> Exists(UpdateCommand command, CancellationToken token)
        {
            return await _repository.Exists(command.Id);
        }
    }
}
