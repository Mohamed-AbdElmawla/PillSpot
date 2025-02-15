namespace Entities.Models
{
    public class PharmacyMedicine
    {
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Quantity { get; set; }
        public string PharmacyId { get; set; }
        public string MedicineId { get; set; }

        public Pharmacy Pharmacy { get; set; }
        public Medicine Medicine { get; set; }
    }
}