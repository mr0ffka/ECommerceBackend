using AutoMapper;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Models.Pager;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetList
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, PagedResult<CategoryListDto>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetListQueryHandler(
            ICategoryRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResult<CategoryListDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetListAsync(request.filter, request.pager);

            var mappedEntities = _mapper.Map<List<CategoryListDto>>(entities);

            return new PagedResult<CategoryListDto>(mappedEntities, request.pager.TotalRows, request.pager.TotalPages);
        }
    }
}
