using AutoMapper;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Models.Pager;
using MediatR;

namespace ECommerce.Application.Features.CartItems.Queries.GetList
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, PagedResult<CartItemListDto>>
    {
        private readonly ICartItemRepository _repository;
        private readonly IMapper _mapper;

        public GetListQueryHandler(
            ICartItemRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResult<CartItemListDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetListAsync(request.filter, request.pager);

            var mappedEntities = _mapper.Map<List<CartItemListDto>>(entities);

            return new PagedResult<CartItemListDto>(mappedEntities, request.pager.TotalRows, request.pager.TotalPages);
        }
    }
}
