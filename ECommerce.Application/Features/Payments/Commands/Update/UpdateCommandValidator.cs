using ECommerce.Application.Contracts.Persistence;
using FluentValidation;

namespace ECommerce.Application.Features.Payments.Commands.Update
{
    public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
    {
        private readonly IPaymentRepository _repository;
        //private readonly IOrderRepository _orderRepository;

        public UpdateCommandValidator(IPaymentRepository repository)
        {
            _repository = repository;
            //_orderRepository = orderRepository;

            RuleFor(p => p.PaymentMethod)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required")
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

        private async Task<bool> OrderExists(UpdateCommand command, CancellationToken token)
        {
            //return await _orderRepository.Exists(command.OrderId);
            return true;
        }

        private async Task<bool> IsUsersOrder(UpdateCommand command, CancellationToken token)
        {
            //return await _orderRepository.IsUsersOrder(command.OrderId);
            return true;
        }

        private async Task<bool> Exists(UpdateCommand command, CancellationToken token)
        {
            return await _repository.Exists(command.Id);
        }
    }
}
