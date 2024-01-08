using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _repository;
        private readonly IAppLogger<UpdateCommandHandler> _logger;

        public UpdateCommandHandler(
            IMapper mapper, 
            IAddressRepository repository,
            IAppLogger<UpdateCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                throw new NotFoundException(nameof(Address), request.Id);

            var validator = new UpdateCommandValidator(_repository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Address update", validationResult);

            _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
