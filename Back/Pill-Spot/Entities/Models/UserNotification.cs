using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class UserNotification
    {
        [Key, Column(Order = 0)]
        public string ReceiverId { get; set; }

        [Key, Column(Order = 1)]
        public ulong NotificationID { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual User Receiver { get; set; }

        [ForeignKey("NotificationID")]
        public virtual Notification Notification { get; set; }
    }
}