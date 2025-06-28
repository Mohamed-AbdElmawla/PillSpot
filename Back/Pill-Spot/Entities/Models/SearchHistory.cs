using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class SearchHistory
    {
        [Key]
        public Guid SearchId { get; set; }

        [Required(ErrorMessage = "Search term is required.")]
        [MaxLength(500, ErrorMessage = "Search term cannot exceed 500 characters.")]
        public required string SearchTerm { get; set; }

        [Required(ErrorMessage = "Search date is required.")]
        public DateTime SearchedAt { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "User ID is required.")]
        [MaxLength(450, ErrorMessage = "User ID cannot exceed 450 characters.")]
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}