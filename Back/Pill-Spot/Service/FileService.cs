using Microsoft.AspNetCore.Http;
using Service.Contracts;

namespace Service
{
    public class FileService : IFileService
    {
        private readonly string _basePath;

        public FileService()
        {
            _basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folderName)
        {
            string folderPath = Path.Combine(_basePath, folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileExtension = Path.GetExtension(file.FileName);
            string newFileName = $"{Guid.NewGuid()}{fileExtension}";
            string filePath = Path.Combine(folderPath, newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{folderName}/{newFileName}";
        }
        public async Task<bool> DeleteFileAsync(string fileUrl)
        {
            if (string.IsNullOrWhiteSpace(fileUrl))
                return false;

            try
            {
                string filePath = Path.Combine(_basePath, fileUrl.TrimStart('/').Replace("/", "\\"));

                if (!File.Exists(filePath))
                {
                    return false;
                }

                await Task.Run(() => File.Delete(filePath));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<IFormFile> GetFileAsync(string fileUrl)
        {
            if (string.IsNullOrWhiteSpace(fileUrl))
                return null;

            try
            {
                string filePath = Path.Combine(_basePath, fileUrl.TrimStart('/').Replace("/", "\\"));

                if (!File.Exists(filePath))
                    return null;

                var stream = new MemoryStream(await File.ReadAllBytesAsync(filePath));
                var fileName = Path.GetFileName(filePath);
                var contentType = "application/octet-stream"; // You can detect MIME type here.

                return new FormFile(stream, 0, stream.Length, "file", fileName)
                {
                    Headers = new HeaderDictionary(),
                    ContentType = contentType
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
