namespace Entities.Models
{
    public class City
    {
        public int CityId { get; set; }
        public int GovernmenteId { get; set; }
        public string City_Name_AR { get; set; }
        public string City_Name_EN { get; set; }

        public  ICollection<Government> Governments { get; set; }
        public Location Location { get; set; }
    }
}
