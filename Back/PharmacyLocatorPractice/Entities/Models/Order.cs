namespace Entities.Models
{
    public enum Status
    {
        Pending,
        ReadyToDeliver,
        Delivered
    }
    public class Order
    {
        public string OrderId { get; set; } = Guid.NewGuid().ToString();
        public DateTime OrderedAt { get; set; }
        public decimal TotalPrice { get; set; }
        public Status Status { get; set; }
        public string LocationId { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
        public Location Location { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
