namespace Entities.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string UserId { get; set; }
        public int MedicineId { get; set; }
        public bool IsNotified { get; set; }
        public int PharmacyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime NotifiedAt { get; set; }

        public User User { get; set; }
    }
}
