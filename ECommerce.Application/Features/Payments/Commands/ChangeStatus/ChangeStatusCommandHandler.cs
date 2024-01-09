using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Features.Payments.Commands.ChangeStatus;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.Create
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _repository;
        private readonly IAppLogger<ChangeStatusCommandHandler> _logger;

        public ChangeStatusCommandHandler(
            IMapper mapper,
            IPaymentRepository repository,
            IAppLogger<ChangeStatusCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<long> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            // validate
            var validator = new ChangeStatusCommandValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            
            if (!validatorResult.IsValid)
            {
                _logger.LogWarn("Validation errors in change status request for {0}", nameof(Product));
                throw new BadRequestException("Invalid Payment", validatorResult);
            }
            // convert to domain entitty object
            var entity = _mapper.Map<Domain.Payment>(request);

            // add to db
            await _repository.UpdateAsync(entity);

            // return id
            return entity.Id;
        }
    }
}
