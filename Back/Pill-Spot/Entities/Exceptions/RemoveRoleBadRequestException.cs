namespace Entities.Exceptions
{
    public sealed class RemoveRoleBadRequestException : BadRequestException
    {
        public RemoveRoleBadRequestException() : base("Failed to remove user roles.") { }
    }
}
