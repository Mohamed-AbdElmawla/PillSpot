namespace Shared.DataTransferObjects
{
    public record PharmacyEmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public IEnumerable<string> Permissions { get; set; }
        public string PharmacyName { get; set; }  // Add this line
    }
}
