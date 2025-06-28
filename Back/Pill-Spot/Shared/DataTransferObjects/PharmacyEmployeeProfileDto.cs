namespace Shared.DataTransferObjects
{
    public record PharmacyEmployeeProfileDto
    {
        public Guid EmployeeId { get; init; }
        public string Role { get; init; }
        public DateTime HireDate { get; init; }
        public PharmacyDto PharmacyDto { get; init; }
    }
}

namespace Shared.DataTransferObjects
{
    public record EmployeeDetailsDto
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Role { get; init; }
        public DateTime CreatedDate { get; init; }
        public string PhoneNumber { get; init; }
        public string PharmacyNames { get; init; }
        public IEnumerable<string> Permissions { get; init; }
    }
}