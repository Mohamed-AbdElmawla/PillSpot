using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PharmacyFeedback
    {
        [Key]
        public Guid FeedbackId { get; set; }

        [Required(ErrorMessage = "Pharmacy ID is required.")]
        public Guid PharmacyId { get; set; }

        [ForeignKey("FeedbackId")]
        public virtual Feedback Feedback { get; set; }

        [ForeignKey("PharmacyId")]
        public virtual Pharmacy Pharmacy { get; set; }
    }
}