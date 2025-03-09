using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string folderName);
        Task<bool> DeleteFileAsync(string fileUrl);
        Task<IFormFile> GetFileAsync(string fileUrl);
        Task<string> AddProductImageIfNotNull(IFormFile Image);
    }
}
