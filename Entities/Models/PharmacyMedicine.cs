namespace Entities.Models
{
    public class PharmacyMedicine
    {
        public int PharmacyId { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public Medicine Medicine { get; set; }
    }
}
