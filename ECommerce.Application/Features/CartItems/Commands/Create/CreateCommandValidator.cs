using ECommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.CartItems.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        private readonly ICartItemRepository _repository;
        private readonly IProductRepository _productRepository;

        public CreateCommandValidator(
            ICartItemRepository repository,
            IProductRepository productRepository
            )
        {
            _repository = repository;
            _productRepository = productRepository;

            RuleFor(p => p.Quantity)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} has to be more than 0");

            RuleFor(p => p.ProductId)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p)
                .MustAsync(ProductExists)
                .WithMessage("Product does not exists");
        }

        private Task<bool> ProductExists(CreateCommand command, CancellationToken token)
        {
            return _productRepository.Exists(command.ProductId);
        }
    }
}
