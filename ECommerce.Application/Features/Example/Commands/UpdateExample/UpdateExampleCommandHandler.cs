using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Example.Commands.UpdateExample
{
    public class UpdateExampleCommandHandler : IRequestHandler<UpdateExampleCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IExampleRepository _repository;
        private readonly IAppLogger<UpdateExampleCommandHandler> _logger;

        public UpdateExampleCommandHandler(
            IMapper mapper, 
            IExampleRepository repository,
            IAppLogger<UpdateExampleCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateExampleCommand request, CancellationToken cancellationToken)
        {
            // validate
            var validator = new UpdateExampleCommandValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                _logger.LogWarn("Validation errors in create request for {0} - {1}", nameof(Example), request.Id);
                throw new BadRequestException("Invalid Example", validatorResult);
            }

            // convert to domain entitty object
            var entity = _mapper.Map<Domain.Example>(request);

            // update to db
            await _repository.UpdateAsync(entity);

            // return
            return Unit.Value;
        }
    }
}
