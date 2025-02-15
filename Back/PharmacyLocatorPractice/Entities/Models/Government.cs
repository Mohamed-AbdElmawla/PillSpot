namespace Entities.Models
{
    public class Government
    {
        public string GovernmentId { get; set; } = Guid.NewGuid().ToString();
        public string Governmente_Name_AR { get; set; }
        public string Governmente_Name_EN { get; set; }
    }
}
