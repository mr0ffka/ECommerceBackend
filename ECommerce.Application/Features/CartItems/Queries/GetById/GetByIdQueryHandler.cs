using AutoMapper;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.CartItems.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CartItemDto>
    {
        private readonly ICartItemRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(
            ICartItemRepository repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CartItemDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {

            var entity = await _repository.GetAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(CartItem), request.Id);

            var mappedEntity = _mapper.Map<CartItemDto>(entity);

            return mappedEntity;
        }
    }
}
