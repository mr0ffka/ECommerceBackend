using AutoMapper;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.Coupons.Queries.GetByCode
{
    public class GetByCodeQueryHandler : IRequestHandler<GetByCodeQuery, CouponDto>
    {
        private readonly ICouponRepository _repository;
        private readonly IMapper _mapper;

        public GetByCodeQueryHandler(
            ICouponRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CouponDto> Handle(GetByCodeQuery request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<CouponDto>(await _repository.GetByCodeAsync(request.Code));

            if (entity == null)
                throw new NotFoundException(nameof(Coupon), request.Code);

            return entity;
        }
    }
}
