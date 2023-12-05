using AutoMapper;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Example.Commands.DeleteExample
{
    public class DeleteExampleCommandHandler : IRequestHandler<DeleteExampleCommand, Unit>
    {
        private readonly IExampleRepository _repository;

        public DeleteExampleCommandHandler(IExampleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteExampleCommand request, CancellationToken cancellationToken)
        {
            // get object from db
            var entity = await _repository.GetByIdAsync(request.Id);

            // validate
            if (entity is null)
                throw new NotFoundException(nameof(Example), request.Id);

            // remove from db
            await _repository.DeleteAsync(entity);

            return Unit.Value;
        }
    }
}
