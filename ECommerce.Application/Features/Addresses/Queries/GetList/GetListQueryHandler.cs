using AutoMapper;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Models.Pager;
using MediatR;

namespace ECommerce.Application.Features.Addresses.Queries.GetList
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, PagedResult<AddressListDto>>
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public GetListQueryHandler(
            IAddressRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResult<AddressListDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetListAsync(request.filter, request.pager);

            var mappedEntities = _mapper.Map<List<AddressListDto>>(entities);

            return new PagedResult<AddressListDto>(mappedEntities, request.pager.TotalRows, request.pager.TotalPages);
        }
    }
}
