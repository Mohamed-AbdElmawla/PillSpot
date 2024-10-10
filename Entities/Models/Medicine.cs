namespace Entities.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ActiveIngredient { get; set; }
        public string Dosage { get; set; }
        public string Brand { get; set; }

        public ICollection<PharmacyMedicine> PharmacyMedicine { get; set; }
    }
}
