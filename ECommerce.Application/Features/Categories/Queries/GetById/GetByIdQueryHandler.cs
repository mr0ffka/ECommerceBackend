using AutoMapper;
using ECommerce.Application.Contracts.Identity;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Categories.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(
            ICategoryRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {

            var entity = _mapper.Map<CategoryDto>(await _repository.GetByIdAsync(request.Id));

            if (entity == null)
                throw new NotFoundException(nameof(Category), request.Id);

            return entity;
        }
    }
}
