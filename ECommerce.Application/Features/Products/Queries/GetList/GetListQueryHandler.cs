using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Features.Products.Queries.Get;
using ECommerce.Application.Models.Pager;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Queries.GetList;

public class GetListQueryHandler : IRequestHandler<GetListQuery, PagedResult<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;
    private readonly IAppLogger<GetListQueryHandler> _logger;

    public GetListQueryHandler(
        IMapper mapper,
        IProductRepository repository,
        IAppLogger<GetListQueryHandler> logger)
    {
        _mapper = mapper;
        _repository = repository;
        _logger = logger;
    }

    public async Task<PagedResult<ProductDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetListAsync(request.filter, request.pager);

        var mappedEntities = _mapper.Map<List<ProductDto>>(entities);

        return new PagedResult<ProductDto>(mappedEntities, request.pager.TotalPages);
    }
}
