namespace Shared.DataTransferObjects
{
    public record UserDto
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string UserName { get; init; }
        public string PhoneNumber { get; init; }
        public string? ProfilePictureUrl { get; init; }
        public DateTime DateOfBirth { get; init; }
        public Gender Gender { get; init; }
    }
}
