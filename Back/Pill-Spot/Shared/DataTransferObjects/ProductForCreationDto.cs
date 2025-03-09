using Entities.Validators;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record ProductForCreationDto
    {
        [Required(ErrorMessage = "SubCategory ID is required.")]
        public Guid SubCategoryId { get; init; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters.")]
        public string Name { get; init; }
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; init; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public double Price { get; init; }

        [AllowedFileExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(1 * 1024 * 1024)]
        public IFormFile? Image { get; set; }
    }
}
