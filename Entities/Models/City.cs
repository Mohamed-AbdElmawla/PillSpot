namespace Entities.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string City_Name_AR { get; set; }
        public string City_Name_EN { get; set; }
        public int GovernmentId { get; set; }

        public  Government Government { get; set; }
    }
}
