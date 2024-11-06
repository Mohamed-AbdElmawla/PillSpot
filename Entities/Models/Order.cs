namespace Entities.Models
{
    public enum Status
    {
        Pinding,
        ReadyToDeliver,
        Delivered
    }
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public int LocationId { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
        public Location Location { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
