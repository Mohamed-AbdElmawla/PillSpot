using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PrescriptionForCreationDto
    {
        [Required(ErrorMessage = "User ID is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Issue date is required")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Expiry date is required")]
        public DateTime ExpiryDate { get; set; }

        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "At least one product is required")]
        [MinLength(1, ErrorMessage = "At least one product is required")]
        public List<PrescriptionProductForCreationDto> PrescriptionProducts { get; set; }
    }
}