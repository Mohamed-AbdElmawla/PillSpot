namespace Entities.Models
{
    public class OrderItem
    {
        public string OrderItemId { get; set; } = Guid.NewGuid().ToString();
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string OrderId { get; set; }
        public string pharmacyId { get; set; }
        public string MedicineId { get; set; }
        public PharmacyMedicine PharmacyMedicine { get; set; }
        public Order Order { get; set; }
    }
}
