using AutoMapper;
using ECommerce.Application.Contracts.Files;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IProductFileRepository _productFileRepository;
        private readonly IAppLogger<CreateCommandHandler> _logger;

        public CreateCommandHandler(
            IMapper mapper, 
            IAppLogger<CreateCommandHandler> logger,
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

        public async Task<long> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCommandValidator(_repository, _categoryRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                _logger.LogWarn("Validation errors in create request for {0}", nameof(Product));
                throw new BadRequestException("Invalid Product", validatorResult);
            }

            var entity = _mapper.Map<Domain.Product>(request); 

            if (request.Thumbnail != null)
            {
                var thumbnailId = await _fileRepository.UploadFileAsync(request.Thumbnail);
                entity.ThumbnailId = thumbnailId;
            }

            await _repository.CreateAsync(entity);

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

            return entity.Id;
        }
    }
}
