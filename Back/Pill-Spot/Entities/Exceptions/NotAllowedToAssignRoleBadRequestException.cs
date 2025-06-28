

namespace Entities.Exceptions
{
    public sealed class NotAllowedToAssignRoleBadRequestException : BadRequestException
    {
        public NotAllowedToAssignRoleBadRequestException() : base("You are not allowed to assign roles to this user.") { }
    }
}
