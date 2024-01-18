using AutoMapper;
using ECommerce.Application.Contracts.Files;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Exceptions;
using ECommerce.Domain;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.DeleteFile
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductFileRepository _repository;
        private readonly IFileRepository _fileRepository;
        private readonly IAppLogger<DeleteFileCommandHandler> _logger;

        public DeleteFileCommandHandler(
            IMapper mapper,
            IProductFileRepository repository,
            IFileRepository fileRepository,
            IAppLogger<DeleteFileCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _fileRepository = fileRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAsync(request.ProductId, request.FileId);

            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }

            await _fileRepository.DeleteFileAsync(request.FileId);

            return Unit.Value;
        }
    }
}
