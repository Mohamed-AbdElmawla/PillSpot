using Entities.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PrescriptionForUpdateDto
    {
        [Required(ErrorMessage = "Prescription ID is required.")]
        public Guid PrescriptionId { get; init; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; init; }

        [Required(ErrorMessage = "Issue date is required")]
        public DateTime IssueDate { get; init; }

        [Required(ErrorMessage = "Expiry date is required")]
        public DateTime ExpiryDate { get; init; }

        [Required(ErrorMessage = "Status is required")]
        public PrescriptionStatus Status { get; init; }

        public IFormFile? ImageFile { get; init; }

        public ICollection<PrescriptionProductForCreationDto>? PrescriptionProducts { get; init; }
    }
}