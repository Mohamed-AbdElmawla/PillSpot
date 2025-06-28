



namespace Entities.Exceptions
{
    public sealed class UserHaveRoleBadRequestException : BadRequestException
    {
        public UserHaveRoleBadRequestException(string role) : base($"User already has the role '{role}'.") { }
    }
}
