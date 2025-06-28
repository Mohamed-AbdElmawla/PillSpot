using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Message
    {
        [Key]
        public Guid MessageId { get; set; }

        [Required(ErrorMessage = "Chat ID is required.")]
        public Guid ChatId { get; set; }

        [Required(ErrorMessage = "Sender ID is required.")]
        [MaxLength(450, ErrorMessage = "Sender ID cannot exceed 450 characters.")]
        public required string SenderId { get; set; }

        [Required(ErrorMessage = "Recipient ID is required.")]
        [MaxLength(450, ErrorMessage = "Recipient ID cannot exceed 450 characters.")]
        public required string RecipientId { get; set; }

        [Required(ErrorMessage = "Message content is required.")]
        [MaxLength(1000, ErrorMessage = "Message content cannot exceed 1000 characters.")]
        public required string Content { get; set; }

        [Required]
        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsRead { get; set; } = false;

        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }

        [ForeignKey("RecipientId")]
        public virtual User Recipient { get; set; }

        [ForeignKey("ChatId")]
        public virtual Chat Chat { get; set; }
    }
}