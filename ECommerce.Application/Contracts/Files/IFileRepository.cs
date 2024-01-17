using ECommerce.Application.Contracts.Persistence;
using ECommerce.Application.Models.Simple.File;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.Application.Contracts.Files
{
    public interface IFileRepository : IGenericRepository<Domain.File>
    {
        Task<long> UploadFileAsync(IFormFile file);
        Task<List<long>> UploadFilesAsync(List<IFormFile> files);
        Task DeleteFileAsync(long id);
        Task DeleteFilesAsync(List<long> ids);
        Task<FileStreamResult> GetFileAsync(long id);
    }
}
