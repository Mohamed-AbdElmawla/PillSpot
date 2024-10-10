namespace Entities.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int MedicineId { get; set; }
        public int LocationId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
    }
}
