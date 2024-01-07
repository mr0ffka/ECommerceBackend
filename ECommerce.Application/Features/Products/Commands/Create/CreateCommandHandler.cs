using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Products.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAppLogger<CreateCommandHandler> _logger;

        public CreateCommandHandler(
            IMapper mapper, 
            IProductRepository repository,
            IAppLogger<CreateCommandHandler> logger,
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public async Task<long> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            // validate
            var validator = new CreateCommandValidator(_repository, _categoryRepository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                _logger.LogWarn("Validation errors in create request for {0}", nameof(Product));
                throw new BadRequestException("Invalid Product", validatorResult);
            }
            // convert to domain entitty object
            var entity = _mapper.Map<Domain.Product>(request);

            // add to db
            await _repository.CreateAsync(entity);

            // return id
            return entity.Id;
        }
    }
}
