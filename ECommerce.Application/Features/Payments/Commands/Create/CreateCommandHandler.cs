using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _repository;
        private readonly IPaymentHistoryRepository _historyRepository;
        private readonly IAppLogger<CreateCommandHandler> _logger;

        public CreateCommandHandler(
            IMapper mapper,
            IPaymentRepository repository,
            IPaymentHistoryRepository historyRepository,
            IAppLogger<CreateCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _historyRepository = historyRepository;
            _logger = logger;
        }

        public async Task<long> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCommandValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                _logger.LogWarn("Validation errors in create request for {0}", nameof(Product));
                throw new BadRequestException("Invalid Product", validatorResult);
            }
            var entity = _mapper.Map<Domain.Payment>(request);

            await _repository.CreateAsync(entity);

            var historyEntity = _mapper.Map<Domain.PaymentHistory>(entity);
            await _historyRepository.CreateAsync(historyEntity);

            return entity.Id;
        }
    }
}
