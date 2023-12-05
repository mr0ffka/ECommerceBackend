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

namespace ECommerce.Application.Features.Example.Commands.CreateExample
{
    public class CreateExampleCommandHandler : IRequestHandler<CreateExampleCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IExampleRepository _repository;
        private readonly IAppLogger<CreateExampleCommandHandler> _logger;

        public CreateExampleCommandHandler(
            IMapper mapper, 
            IExampleRepository repository,
            IAppLogger<CreateExampleCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<string> Handle(CreateExampleCommand request, CancellationToken cancellationToken)
        {
            // validate
            var validator = new CreateExampleCommandValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                _logger.LogWarn("Validation errors in create request for {0}", nameof(Example));
                throw new BadRequestException("Invalid Example", validatorResult);
            }
            // convert to domain entitty object
            var entity = _mapper.Map<Domain.Example>(request);

            // add to db
            await _repository.CreateAsync(entity);

            // return id
            return entity.PublicId;
        }
    }
}
