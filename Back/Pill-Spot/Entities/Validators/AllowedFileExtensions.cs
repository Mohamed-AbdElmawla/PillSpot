using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class AllowedFileExtensions : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedFileExtensions(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not IFormFile file)
                return ValidationResult.Success;

            var extension = Path.GetExtension(file.FileName);
            return _extensions.Contains(extension.ToLower())
                ? ValidationResult.Success
                : new ValidationResult($"Allowed file types: {string.Join(", ", _extensions)}");
        }
    }
}
