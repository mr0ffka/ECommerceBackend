using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.Payments.Commands.ChangeStatus;
using FluentValidation;

namespace ECommerce.Application.Features.Payments.Commands.Create
{
    public class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
    {
        private readonly IPaymentRepository _repository;
        //private readonly IOrderRepository _orderRepository;

        public ChangeStatusCommandValidator(IPaymentRepository repository)
        {
            _repository = repository;
            //_orderRepository = orderRepository;

            RuleFor(p => p.PaymentMethod)
                .NotNull().WithMessage("{PropertyName} is required")
                .IsInEnum().WithMessage("{PropertyName} is not a valid method");

            RuleFor(p => p.PaymentId)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p)
                .MustAsync(Exists)
                .WithMessage("Payment not exists");
        }

        private async Task<bool> Exists(ChangeStatusCommand command, CancellationToken token)
        {
            return await _repository.Exists(command.PaymentId);
        }
    }
}
