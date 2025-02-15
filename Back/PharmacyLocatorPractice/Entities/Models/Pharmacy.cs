namespace Entities.Models
{
    public class Pharmacy
    {
        public string PharmacyId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string? Logo { get; set; }
        public string ContactNumber { get; set; }
        public string OpeningHours { get; set; }
        public bool IsOpen24Hours { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LicenseID { get; set; }
        public string LocationId { get; set; }

        public Location Location { get; set; }
        public ICollection<PharmacyMedicine> PharmacyMedicines { get; set; }
    }
}
