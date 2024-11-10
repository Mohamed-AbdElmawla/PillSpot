namespace Entities.Models
{
    public class City
    {
        public string CityId { get; set; } = Guid.NewGuid().ToString();
        public string City_Name_AR { get; set; }
        public string City_Name_EN { get; set; }
        public string GovernmentId { get; set; }

        public Government Government { get; set; }
    }
}
