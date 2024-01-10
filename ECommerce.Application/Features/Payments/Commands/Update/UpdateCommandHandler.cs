using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _repository;
        private readonly IPaymentHistoryRepository _historyRepository;
        private readonly IAppLogger<UpdateCommandHandler> _logger;

        public UpdateCommandHandler(
            IMapper mapper, 
            IAppLogger<UpdateCommandHandler> logger,
            IPaymentRepository repository,
            IPaymentHistoryRepository historyRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _historyRepository = historyRepository;
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                throw new NotFoundException(nameof(Payment), request.Id);

            var validator = new UpdateCommandValidator(_repository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid payment update", validationResult);

            _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            var historyEntity = _mapper.Map<Domain.PaymentHistory>(entity);
            await _historyRepository.CreateAsync(historyEntity);

            return Unit.Value;
        }
    }
}
