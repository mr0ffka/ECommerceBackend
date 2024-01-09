using AutoMapper;
using ECommerce.Application.Contracts.Files;
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
        private readonly IFileRepository _fileRepository;
        private readonly IProductFileRepository _productFileRepository;
        private readonly IAppLogger<UpdateCommandHandler> _logger;

        public UpdateCommandHandler(
            IMapper mapper, 
            IAppLogger<UpdateCommandHandler> logger,
            IProductRepository repository,
            ICategoryRepository categoryRepository,
            IFileRepository fileRepository,
            IProductFileRepository productFileRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _categoryRepository = categoryRepository;
            _fileRepository = fileRepository;
            _productFileRepository = productFileRepository;
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAsync(request.Id);

            if (entity is null)
                throw new NotFoundException(nameof(Product), request.Id);

            var validator = new UpdateCommandValidator(_repository, _categoryRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid product update", validationResult);

            _mapper.Map(request, entity);

            await _repository.UpdateAsync(entity);

            foreach (var file in request.Files)
            {
                var fileId = await _fileRepository.UploadFileAsync(file);
                var productFile = new ProductFile
                {
                    FileId = fileId,
                    ProductId = entity.Id,
                };
                await _productFileRepository.CreateAsync(productFile);
            }

            return Unit.Value;
        }
    }
}
