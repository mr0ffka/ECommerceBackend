using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.CartItems.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ICartItemRepository _repository;
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<CreateCommandHandler> _logger;

        public CreateCommandHandler(
            IMapper mapper, 
            ICartItemRepository repository,
            IAppLogger<CreateCommandHandler> logger,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<long> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            // validate
            var validator = new CreateCommandValidator(_repository, _productRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                _logger.LogWarn("Validation errors in create request for {0}", nameof(CartItem));
                throw new BadRequestException("Invalid CartItem", validatorResult);
            }

            // convert to domain entitty object
            var entity = _mapper.Map<Domain.CartItem>(request);

            if (await _repository.Exists(entity))
            {
                // get old
                var old = await _repository.GetAsync(entity.UserId, entity.ProductId);
                old!.Quantity += entity.Quantity;
                await _repository.UpdateAsync(old);
                return old!.Id;
            }

            await _repository.CreateAsync(entity);

            // return id
            return entity.Id;
        }
    }
}
