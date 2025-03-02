using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class UserChat
    {
        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        [Key, Column(Order = 1)]
        public ulong ChatId { get; set; }

        [MaxLength(500, ErrorMessage = "Image path cannot exceed 500 characters.")]
        public string ImagePath { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ChatId")]
        public virtual Chat Chat { get; set; }
    }
}