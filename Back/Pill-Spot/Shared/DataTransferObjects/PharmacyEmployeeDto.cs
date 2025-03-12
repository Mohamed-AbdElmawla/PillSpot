namespace Shared.DataTransferObjects
{
    public record PharmacyEmployeeDto
    {
        public Guid EmployeeId { get; init; }
        public string UserId { get; init; }
        public Guid PharmacyId { get; init; }
        public string Role { get; init; }
        public DateTime HireDate { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? ModifiedDate { get; init; }
        public bool IsDeleted { get; init; }
        public UserDto User { get; init; }
        public PharmacyDto Pharmacy { get; init; }
        public ICollection<EmployeePermissionDto> PharmacyEmployeePermissions { get; init; }
    }
}
