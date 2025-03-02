using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Notification
    {
        [Key]
        public ulong NotificationId { get; set; }

        [Required(ErrorMessage = "Actor ID is required.")]
        [MaxLength(450, ErrorMessage = "Actor ID cannot exceed 450 characters.")]
        public string ActorId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Content is required.")]
        [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
        public string Content { get; set; }

        public DateTime? NotifiedDate { get; set; }

        [Required]
        public bool IsNotified { get; set; }

        [Required]
        public bool IsBroadcast { get; set; }

        [ForeignKey("ActorId")]
        public virtual User Actor { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}