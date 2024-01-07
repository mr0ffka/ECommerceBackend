using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<UpdateCommandHandler> _logger;

        public UpdateCommandHandler(
            IMapper mapper, 
            IProductRepository repository,
            IAppLogger<UpdateCommandHandler> logger,
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                throw new NotFoundException(nameof(Product), request.Id);

            var validator = new UpdateCommandValidator(_repository, _categoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid product update", validationResult);

            _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
