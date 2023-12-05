using AutoMapper;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Example.Queries.GetExampleDetails
{
    public class GetExampleDetailsQueryHandler : IRequestHandler<GetExampleDetailsQuery, ExampleDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IExampleRepository _repository;

        public GetExampleDetailsQueryHandler(IMapper mapper, IExampleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ExampleDetailsDto> Handle(GetExampleDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity is null)
                throw new NotFoundException(nameof(Example), request.Id);

            var result = _mapper.Map<ExampleDetailsDto>(entity);

            return result;
        }
    }
}
