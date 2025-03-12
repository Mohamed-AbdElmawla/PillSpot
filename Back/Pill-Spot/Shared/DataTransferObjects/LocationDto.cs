namespace Shared.DataTransferObjects
{
    public class LocationDto
    {
        public double Longitude { get; init; }

        public double Latitude { get; init; }

        public string AdditionalInfo { get; init; }

        public CityDto CityDto { get; init; }
    }
}
