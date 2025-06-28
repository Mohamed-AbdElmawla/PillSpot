






namespace Entities.Exceptions
{
    public sealed class DeactivateUserBadRequestException : BadRequestException
    {
        public DeactivateUserBadRequestException() : base("User is already deactivated.") { }
    }
}

