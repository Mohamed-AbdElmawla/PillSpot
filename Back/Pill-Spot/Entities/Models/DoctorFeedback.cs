using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class DoctorFeedback
    {
        [Key]
        public Guid FeedbackId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public required string UserId { get; set; }

        [ForeignKey("FeedbackId")]
        public virtual Feedback Feedback { get; set; }

        [ForeignKey("UserId")]
        public virtual Doctor Doctor { get; set; }
    }
}