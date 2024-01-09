using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.Get
{
    public class GetQueryHandler : IRequestHandler<GetQuery, ProductDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IProductFileRepository _productFileRepository;
        private readonly IAppLogger<GetQueryHandler> _logger;

        public GetQueryHandler(
            IMapper mapper,
            IProductRepository repository,
            IProductFileRepository productFileRepository,
            IAppLogger<GetQueryHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _productFileRepository = productFileRepository;
            _logger = logger;
        }

        public async Task<ProductDetailsDto> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException("Product not found", request.Id);
            }

            var result = _mapper.Map<ProductDetailsDto>(entity);

            var files = await _productFileRepository.GetFileIdsByProductIdAsync(request.Id);
            result.FileIds = files;

            return result;
        }
    }
}
