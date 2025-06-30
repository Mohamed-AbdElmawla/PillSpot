using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class PharmacyEmployeeRequest
    {
        [Key]
        public Guid RequestId { get; set; }

        [Required]
        public required string UserId { get; set; }
        [Required]
        public required string RequesterId { get; set; }
        [Required]
        public required Guid PharmacyId { get; set; }
        [Required]
        public required string RoleName { get; set; }
        public string? Permissions { get; set; }

        [Required]
        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("RequesterId")]
        public virtual User Requester { get; set; }

        [ForeignKey("PharmacyId")]
        public virtual Pharmacy Pharmacy { get; set; }
    }
    public enum RequestStatus
    {
        Approved,
        Pending,
        Rejected
    }
}
