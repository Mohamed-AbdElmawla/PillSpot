namespace Entities.Models
{
    public class Medicine
    {
        public string MedicineId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public string ActiveIngredient { get; set; }
        public string Dosage { get; set; }
        public string Brand { get; set; }
        public string Logo { get; set; }
        public ICollection<PharmacyMedicine> PharmacyMedicine { get; set; }
    }
}
