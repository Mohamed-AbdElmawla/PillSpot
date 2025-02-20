using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class MaxFileSize : ValidationAttribute
    {
        private readonly int _maxSize;

        public MaxFileSize(int maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not IFormFile file)
                return ValidationResult.Success;

            return file.Length <= _maxSize
                ? ValidationResult.Success
                : new ValidationResult($"Maximum allowed file size is {_maxSize / (1024 * 1024)}MB.");
        }
    }
}
