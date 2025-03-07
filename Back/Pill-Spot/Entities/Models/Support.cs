using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Support
    {
        [Key]
        public Guid SupportId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [MaxLength(450, ErrorMessage = "User ID cannot exceed 450 characters.")]
        public required string UserId { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public int Type { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        public int Priority { get; set; }

        [Required(ErrorMessage = "Issue title is required.")]
        [MaxLength(100, ErrorMessage = "Issue title cannot exceed 100 characters.")]
        public required string IssueTitle { get; set; }

        [Required(ErrorMessage = "Issue details are required.")]
        [MaxLength(500, ErrorMessage = "Issue details cannot exceed 500 characters.")]
        public required string IssueDetails { get; set; }

        [Required(ErrorMessage = "Assigned to is required.")]
        [MaxLength(450, ErrorMessage = "Assigned to cannot exceed 450 characters.")]
        public required string AssignedTo { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public int Status { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ResolvedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}