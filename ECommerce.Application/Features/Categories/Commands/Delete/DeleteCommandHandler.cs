using AutoMapper;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        private readonly IAppLogger<DeleteCommandHandler> _logger;

        public DeleteCommandHandler(
            IMapper mapper,
            ICategoryRepository repository,
            IAppLogger<DeleteCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new NotFoundException(nameof(Category), request.Id);

            await _repository.DeleteAsync(entity);
            return Unit.Value;
        }
    }
}
