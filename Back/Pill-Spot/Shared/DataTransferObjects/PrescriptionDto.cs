using Entities.Models;

namespace Shared.DataTransferObjects
{
    public record PrescriptionDto
    {
        public Guid PrescriptionId { get; init; }
        public string UserId { get; init; }
        public DateTime IssueDate { get; init; }
        public DateTime ExpiryDate { get; init; }
        public PrescriptionStatus Status { get; init; }
        public string ImageUrl { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public bool IsDeleted { get; init; }
        public IEnumerable<PrescriptionProductDto> PrescriptionProducts { get; init; }
    }
}