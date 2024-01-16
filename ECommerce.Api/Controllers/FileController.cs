using ECommerce.Application.Contracts.Files;
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

        [HttpPost("upload/list")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UploadFiles(List<IFormFile> files)
        {
            var entityIds = await _fileRepository.UploadFilesAsync(files);
            return CreatedAtAction(nameof(UploadFile), new { ids = entityIds });
        }

        [HttpPost("upload")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UploadFile(IFormFile file)
        {
            var entityId = await _fileRepository.UploadFileAsync(file);
            return CreatedAtAction(nameof(UploadFile), new { id = entityId });
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(long id)
        {
            await _fileRepository.DeleteFileAsync(id);
            return NoContent();
        }

        [HttpDelete("delete/list")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteList([FromQuery] List<long> ids)
        {
            await _fileRepository.DeleteFilesAsync(ids);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFile(long id)
        {
            return await _fileRepository.GetFileAsync(id);
        }
    }
}
