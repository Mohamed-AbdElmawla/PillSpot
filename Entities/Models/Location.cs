namespace Entities.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string AdditionalInfo { get; set; }
        public int CityId { get; set; }
        public int GovernmentId { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Government>Governments { get; set; }
        public ICollection<Pharmacy> Pharmacies { get; set; }
    }
}
