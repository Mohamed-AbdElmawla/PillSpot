using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PharmacyFeedback
    {
        [Key]
        public ulong FeedbackID { get; set; }

        [Required(ErrorMessage = "Pharmacy ID is required.")]
        public ulong PharmacyID { get; set; }

        [ForeignKey("FeedbackID")]
        public virtual Feedback Feedback { get; set; }

        [ForeignKey("PharmacyID")]
        public virtual Pharmacy Pharmacy { get; set; }
    }
}