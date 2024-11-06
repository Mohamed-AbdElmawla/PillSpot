namespace Entities.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public PharmacyMedicine PharmacyMedicine { get; set; }
        public Order Order { get; set; }
    }
}
