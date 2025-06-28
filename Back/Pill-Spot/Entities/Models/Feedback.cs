using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Feedback
    {
        [Key]
        public Guid FeedbackId { get; set; }

        [Required(ErrorMessage = "Sender ID is required.")]
        public required string SenderId { get; set; }

        [Required(ErrorMessage = "Rate is required.")]
        [Range(0, 5, ErrorMessage = "Rate must be between 0 and 5.")]
        public decimal Rate { get; set; }

        public DateTime? NotifiedDate { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
        public required string Content { get; set; }

        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}