
namespace Entities.Exceptions
{
    public sealed class UserDeletedBadRequestException : BadRequestException
    {
        public UserDeletedBadRequestException() : base("Cannot modify a deleted user.") { }
    }
}

