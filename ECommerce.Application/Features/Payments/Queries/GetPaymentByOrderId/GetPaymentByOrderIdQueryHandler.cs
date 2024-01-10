using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.Payments.Queries.GetPaymentByOrderId;
using MediatR;

namespace ECommerce.Application.Features.Payments.Queries.Get
{
    public class GetPaymentByOrderIdQueryHandler : IRequestHandler<GetPaymentByOrderIdQuery, PaymentDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IProductFileRepository _productFileRepository;
        private readonly IAppLogger<GetPaymentByOrderIdQueryHandler> _logger;

        public GetPaymentByOrderIdQueryHandler(
            IMapper mapper,
            IProductRepository repository,
            IProductFileRepository productFileRepository,
            IAppLogger<GetPaymentByOrderIdQueryHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _productFileRepository = productFileRepository;
            _logger = logger;
        }

        public async Task<PaymentDto> Handle(GetPaymentByOrderIdQuery request, CancellationToken cancellationToken)
        {
            //var entity = await _repository.GetAsync(request.Id);

            //if (entity == null)
            //{
            //    throw new NotFoundException("Product not found", request.Id);
            //}

            //var result = _mapper.Map<ProductDetailsDto>(entity);

            //var files = await _productFileRepository.GetFileIdsByProductIdAsync(request.Id);
            //result.FileIds = files;

            //return result;
            return new PaymentDto();
        }
    }
}
