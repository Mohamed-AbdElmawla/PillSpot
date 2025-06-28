namespace Shared.RequestFeatures
{
    public class PrescriptionProductParameters : RequestParameters
    {
        public PrescriptionProductParameters() => OrderBy = "ProductName";

        public string? ProductName { get; set; }
        public Guid? CategoryId { get; set; }
        public int? MinQuantity { get; set; } 
        public int? MaxQuantity { get; set; } 
    }
}
