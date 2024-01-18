using ECommerce.Application.Contracts.Files;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Models.Simple.File;
using ECommerce.Persistence.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Persistence.Repositories
{
    public class FileRepository : GenericRepository<Domain.File>, IFileRepository
    {
        private readonly IConfiguration _configuration;

        public FileRepository(ECommerceDbContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }

        public async Task DeleteFileAsync(long id)
        {
            var fileToDelete = await GetByIdAsync(id);
            if (fileToDelete == null)
                throw new NotFoundException("File does not exists", id);

            try
            {
                var filesToDelete = Directory.GetFiles(Path.Combine(_configuration["FileStorage:DefaultPath"]!, $"{fileToDelete!.ContentType}"), fileToDelete.Name, SearchOption.TopDirectoryOnly);

                if (filesToDelete.Length == 0)
                    throw new NotFoundException("File does not exists", id);

                foreach (var file in filesToDelete)
                {
                    System.IO.File.Delete(file);
                }

                await DeleteAsync(fileToDelete);
            }
            catch (Exception e)
            {
                throw new BadRequestException("Something went wrong during file deletion. Try again later." + e.ToString());
            }
        }

        public async Task DeleteFilesAsync(List<long> ids)
        {
            if (ids == null || ids.Count == 0)
                throw new BadRequestException("No files to delete");

            foreach (var id in ids)
            {
                await DeleteFileAsync(id);
            }
        }

        public async Task<FileStreamResult> GetFileAsync(long id)
        {
            var file = await GetByIdAsync(id);

            if (file == null || !System.IO.File.Exists(file.Path))
                throw new NotFoundException("File does not exists", id);

            var fileStream = new FileStream(file.Path, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(fileStream, file.ContentType);
        }

        public async Task<long> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new BadRequestException("No file uploaded");

            var fileExt = System.IO.Path.GetExtension(file.FileName);
            var uniqueFileName = $"{DateTime.UtcNow.Ticks}_{Guid.NewGuid()}{fileExt}";
            var filePath = Path.Combine(_configuration["FileStorage:DefaultPath"]!, $"{file.ContentType}", uniqueFileName);

            try
            {
                if (!Directory.Exists(_configuration["FileStorage:DefaultPath"]!))
                {
                    Directory.CreateDirectory(_configuration["FileStorage:DefaultPath"]!);
                }

                if (!Directory.Exists(Path.Combine(_configuration["FileStorage:DefaultPath"]!, $"{file.ContentType}")))
                {
                    Directory.CreateDirectory(Path.Combine(_configuration["FileStorage:DefaultPath"]!, $"{file.ContentType}"));
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var entity = new Domain.File
                {
                    Name = uniqueFileName,
                    Path = filePath,
                    ContentType = file.ContentType
                };

                await CreateAsync(entity);

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public async Task<List<long>> UploadFilesAsync(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                throw new BadRequestException("something went wrong");

            var ids = new List<long>();
            foreach (var file in files)
            {

                ids.Add(await UploadFileAsync(file));
            }

            return ids;
        }
    }
}
