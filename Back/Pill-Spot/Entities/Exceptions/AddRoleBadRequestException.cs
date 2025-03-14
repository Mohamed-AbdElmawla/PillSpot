namespace Entities.Exceptions
{
    public sealed class AddRoleBadRequestException : BadRequestException
    {
        public AddRoleBadRequestException() : base("Failed to add user to role.") { }
    }
}