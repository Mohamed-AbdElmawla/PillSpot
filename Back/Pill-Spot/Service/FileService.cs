using Microsoft.AspNetCore.Http;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
