using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class DoctorFeedback
    {
        [Key]
        public ulong FeedbackID { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserID { get; set; }

        [ForeignKey("FeedbackID")]
        public virtual Feedback Feedback { get; set; }

        [ForeignKey("UserID")]
        public virtual Doctor Doctor { get; set; }
    }
}