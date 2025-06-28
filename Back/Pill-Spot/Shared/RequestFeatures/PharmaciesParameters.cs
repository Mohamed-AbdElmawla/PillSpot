namespace Shared.RequestFeatures
{
    public class PharmaciesParameters : RequestParameters
    {
        public PharmaciesParameters() => OrderBy = "Name";
        public string? SearchTerm { get; set; }
    }
}
