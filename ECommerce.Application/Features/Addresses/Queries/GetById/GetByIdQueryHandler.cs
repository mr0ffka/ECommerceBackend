using AutoMapper;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, AddressDto>
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(
            IAddressRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AddressDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<AddressDto>(await _repository.GetByIdAsync(request.Id));

            if (entity == null)
                throw new NotFoundException(nameof(Address), request.Id);

            return entity;
        }
    }
}
