using ECommerce.Application.Contracts.Files;
using ECommerce.Application.Features.Payments.Commands.Create;
using ECommerce.Application.Features.Payments.Queries.GetPaymentMethodList;
using ECommerce.Application.Features.Payments.Queries.GetPaymentStatusList;
using ECommerce.Application.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers.Admin
{
    [Route("api/file/")]
    [ApiController]
    [Authorize(Roles = "Administrator, User")]
    public class FileController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;

        public FileController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFile(long id)
        {
            return await _fileRepository.GetFileAsync(id);
        }
    }
}
