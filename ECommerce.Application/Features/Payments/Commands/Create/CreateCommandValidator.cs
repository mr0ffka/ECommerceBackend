using ECommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.Payments.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        private readonly IPaymentRepository _repository;
        //private readonly IOrderRepository _orderRepository;

        public CreateCommandValidator(IPaymentRepository repository)
        {
            _repository = repository;
            //_orderRepository = orderRepository;

            RuleFor(p => p.PaymentMethod)
                .NotNull().WithMessage("{PropertyName} is required")
                .IsInEnum().WithMessage("{PropertyName} is not a valid method");

            RuleFor(p => p.Amount)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0m).WithMessage("{PropertyName} has to be greater than 0");

            RuleFor(p => p.OrderId)
                .NotNull()
                .NotEmpty().WithMessage("Category is required");

            RuleFor(p => p)
                .MustAsync(OrderExists)
                .WithMessage("Order not exists");

            RuleFor(p => p)
                .MustAsync(IsUsersOrder)
                .WithMessage("Order not exists");
        }
        private async Task<bool> OrderExists(CreateCommand command, CancellationToken token)
        {
            //return await _orderRepository.Exists(command.OrderId);
            return true;
        }

        private async Task<bool> IsUsersOrder(CreateCommand command, CancellationToken token)
        {
            //return await _orderRepository.IsUsersOrder(command.OrderId);
            return true;
        }
    }
}
