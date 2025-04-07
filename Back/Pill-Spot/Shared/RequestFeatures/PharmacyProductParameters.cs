namespace Shared.RequestFeatures
{
    public class PharmacyProductParameters : RequestParameters
    {
        public string? SearchTerm { get; set; }
        public Guid? SubCategoryId { get; set; }

        public bool? IsAvailable { get; set; }

        public bool? RequiresPrescription { get; set; }

        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }

        public double? UserLatitude { get; set; }
        public double? UserLongitude { get; set; }
        public double? MaxDistance { get; set; } // Distance in kilometers
        public bool SortByDistanceAscending { get; set; } // Sort direction for distance (true = ascending, false = descending)
    }
}
