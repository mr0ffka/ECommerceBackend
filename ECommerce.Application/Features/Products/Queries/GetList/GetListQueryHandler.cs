using AutoMapper;
using ECommerce.Application.Contracts.Files;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Models.Pager;
using ECommerce.Application.Models.Simple.File;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Application.Features.Products.Queries.GetList;

public class GetListQueryHandler : IRequestHandler<GetListQuery, PagedResult<ProductDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;
    private readonly IProductFileRepository _productFileRepository;
    private readonly IAppLogger<GetListQueryHandler> _logger;

    public GetListQueryHandler(
        IMapper mapper,
        IProductRepository repository,
        IProductFileRepository productFileRepository,
        IAppLogger<GetListQueryHandler> logger)
    {
        _mapper = mapper;
        _repository = repository;
        _productFileRepository = productFileRepository;
        _logger = logger;
    }

    public async Task<PagedResult<ProductDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetListAsync(request.filter, request.pager);

        var mappedEntities = _mapper.Map<List<ProductDto>>(entities);

        return new PagedResult<ProductDto>(mappedEntities, request.pager.TotalRows, request.pager.TotalPages);
    }
}
