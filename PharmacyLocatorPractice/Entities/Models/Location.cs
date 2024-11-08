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
        public  Government Governorate { get; set; }
        public  City City { get; set; }
        public Pharmacy Pharmacies { get; set; }
    }
}
