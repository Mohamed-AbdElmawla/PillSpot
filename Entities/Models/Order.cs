namespace Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int LocationId { get; set; }
        public DateTime OrderedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public int PharmacyId { get; set; }
        public User User { get; set; }
        public Location Location { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
