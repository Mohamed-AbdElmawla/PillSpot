namespace Entities.Models
{
    public class SearchHistory
    {
        public string SearchId { get; set; } = Guid.NewGuid().ToString();
        public string SearchTerm { get; set; }
        public DateTime SearchedAt { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }

    }
}
