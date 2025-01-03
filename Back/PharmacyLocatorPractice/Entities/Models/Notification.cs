namespace Entities.Models
{
    public class Notification
    {
        public string NotificationId { get; set; } = Guid.NewGuid().ToString();
        public bool IsNotified { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime NotifiedAt { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public string PharmacyId { get; set; }
        public string MedicineId { get; set; }

        public PharmacyMedicine PharmacyMedicine { get; set; }
        public User User { get; set; }
    }
}
