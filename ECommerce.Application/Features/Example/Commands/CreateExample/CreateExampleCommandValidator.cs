using ECommerce.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Example.Commands.CreateExample
{
    public class CreateExampleCommandValidator : AbstractValidator<CreateExampleCommand>
    {
        private readonly IExampleRepository _repository;

        public CreateExampleCommandValidator(IExampleRepository repository)
        {
            _repository = repository;
            
            RuleFor(p => p.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.Description)
                .MaximumLength(2000).WithMessage("{PropertyName} must be fewer than 2000 characters");

            RuleFor(p => p)
                .MustAsync(ExampleUnique)
                .WithMessage("Example already exists");
        }

        private Task<bool> ExampleUnique(CreateExampleCommand command, CancellationToken token)
        {
            return _repository.IsUnique(command.Name);
        }
    }
}
