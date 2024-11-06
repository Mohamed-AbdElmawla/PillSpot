using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class User : IdentityUser
    {
        public string Name {  get; set; }
        public int Age { get; set; }
        public string? SOSNumber { get; set; }
        public Gender? Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? RefreshToken { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public int? LocationId { get; set; }

        public Location Location { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Message> SentMessages { get; set; }
        public ICollection<Message> ReceivedMessages { get; set; }
        public ICollection<SearchHistory> SearchHistories { get; set; }

    }
}
