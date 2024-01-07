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

namespace ECommerce.Application.Features.Coupons.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ICouponRepository _repository;
        private readonly IAppLogger<CreateCommandHandler> _logger;

        public CreateCommandHandler(
            IMapper mapper,
            ICouponRepository repository,
            IAppLogger<CreateCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<long> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            // validate
            var validator = new CreateCommandValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                _logger.LogWarn("Validation errors in create request for {0}", nameof(Category));
                throw new BadRequestException("Invalid Coupon", validatorResult);
            }
            // convert to domain entitty object
            var entity = _mapper.Map<Domain.Coupon>(request);

            // add to db
            await _repository.CreateAsync(entity);

            // return id
            return entity.Id;
        }
    }
}
