﻿using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

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
            var validator = new CreateCommandValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                _logger.LogWarn("Validation errors in create request for {0}", nameof(Category));
                throw new BadRequestException("Invalid Coupon", validatorResult);
            }
            var entity = _mapper.Map<Domain.Coupon>(request);

            await _repository.CreateAsync(entity);

            return entity.Id;
        }
    }
}
