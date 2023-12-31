﻿using AutoMapper;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Models.Pager;
using MediatR;

namespace ECommerce.Application.Features.Coupons.Queries.GetList
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, PagedResult<CouponListDto>>
    {
        private readonly ICouponRepository _repository;
        private readonly IMapper _mapper;

        public GetListQueryHandler(
            ICouponRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResult<CouponListDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetListAsync(request.filter, request.pager);

            var mappedEntities = _mapper.Map<List<CouponListDto>>(entities);

            return new PagedResult<CouponListDto>(mappedEntities, request.pager.TotalRows, request.pager.TotalPages);
        }
    }
}
