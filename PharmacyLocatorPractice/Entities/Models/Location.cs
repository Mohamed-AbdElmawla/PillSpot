namespace Entities.Models
{
    public class Location
    {
        public string LocationId { get; set; } = Guid.NewGuid().ToString();
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string AdditionalInfo { get; set; }
        public string CityId { get; set; }
        public string UserId { get; set; }

        public ICollection<Order> Orders { get; set; }
        public User Users { get; set; }
        public City City { get; set; }
        public Pharmacy Pharmacies { get; set; }
    }
}
