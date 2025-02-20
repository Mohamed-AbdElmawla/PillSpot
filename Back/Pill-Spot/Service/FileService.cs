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
            _basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
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
    }
}
