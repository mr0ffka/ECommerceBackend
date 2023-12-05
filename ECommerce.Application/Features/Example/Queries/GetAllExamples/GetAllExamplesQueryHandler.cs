using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Example.Queries.GetAllExample
{
    public class GetAllExamplesQueryHandler : IRequestHandler<GetAllExamplesQuery, List<ExampleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IExampleRepository _repository;
        private readonly IAppLogger<GetAllExamplesQueryHandler> _logger;

        public GetAllExamplesQueryHandler(
            IMapper mapper, 
            IExampleRepository repository,
            IAppLogger<GetAllExamplesQueryHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<ExampleDto>> Handle(GetAllExamplesQuery request, CancellationToken cancellationToken)
        {
            var examples = await _repository.GetAllAsync();

            var result = _mapper.Map<List<ExampleDto>>(examples);

            return result;
        }
    }
}
