namespace Entities.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public bool IsNotified { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime NotifiedAt { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }

        public PharmacyMedicine PharmacyMedicine { get; set; }
        public User User { get; set; }
    }
}
