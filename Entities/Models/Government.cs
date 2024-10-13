namespace Entities.Models
{
    public class Government
    {
        public int GovernmentId { get; set; }
        public int LocationId { get; set; }
        public string Governmente_Name_AR { get; set; }
        public string Governmente_Name_EN { get; set; }

        public City City { get; set; }
        public Location Location { get; set; }

    }
}
