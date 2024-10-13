using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        public string Name {  get; set; }
        public int Age { get; set; }
        public int LocationId { get; set; }
        public int RoleId { get; set; }
        public string SOSNumber { get; set; }
        public string Gender { get; set; }
        public int PrescriptionId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Location Location { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
        public ICollection<SearchHistory> SearchHistories { get; set; }

    }
}
