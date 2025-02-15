using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class SearchHistory
    {
        [Key]
        public string SearchId { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Search term is required.")]
        [MaxLength(500, ErrorMessage = "Search term cannot exceed 500 characters.")]
        public string SearchTerm { get; set; }

        [Required(ErrorMessage = "Search date is required.")]
        public DateTime SearchedAt { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "User ID is required.")]
        [MaxLength(450, ErrorMessage = "User ID cannot exceed 450 characters.")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}