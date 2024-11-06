namespace Entities.Models
{
    public class SearchHistory
    {
        public int SearchId { get; set; }
        public string SearchTerm { get; set; }
        public DateTime SearchedAt { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }

    }
}
