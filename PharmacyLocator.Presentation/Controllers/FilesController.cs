using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocator.Presentation.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            #region Checking Extension
            var extension = Path.GetExtension(file.FileName);
            //TODO: It's better to be part of appsettings.json
            var allowedExtenstions = new string[]
            {
            ".png",
            ".jpg",
            ".svg"
            };
            bool isExtensionAllowed = allowedExtenstions.Contains(extension,
            StringComparer.InvariantCultureIgnoreCase);
            if (!isExtensionAllowed)
            {
                return BadRequest("Extension is not valid");
            }
            #endregion

            #region Checking Length
            bool isSizeAllowed = file.Length is > 0 and <= 10000000;
            if (!isSizeAllowed) 
                return BadRequest("Size is not allowed");
            #endregion

            #region Storing The Image
            var newFileName = $"{Guid.NewGuid()}{extension}";
            var imagesPath = Path.Combine(Environment.CurrentDirectory, "Images");
            var fullFilePath = Path.Combine(imagesPath, newFileName);
            using var stream = new FileStream(fullFilePath, FileMode.Create); file.CopyTo(stream);
            #endregion

            #region Generating URL
            var url = $"{Request.Scheme}://{Request.Host}/Images/{newFileName}";
            return Ok(url);
            #endregion
        }
    }
}
