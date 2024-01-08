using ECommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.CartItems.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        private readonly ICartItemRepository _repository;
        private readonly IProductRepository _productRepository;

        public UpdateCommandValidator(
            ICartItemRepository repository,
            IProductRepository productRepository
            )
        {
            _repository = repository;
            _productRepository = productRepository;

            RuleFor(p => p)
                .MustAsync(Exists)
                .WithMessage("Cart entry does not exists");

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

        private Task<bool> ProductExists(UpdateCommand command, CancellationToken token)
        {
            return _productRepository.Exists(command.ProductId);
        }

        private async Task<bool> Exists(UpdateCommand command, CancellationToken token)
        {
            return await _repository.Exists(command.Id);
        }
    }
}
