



namespace Entities.Exceptions
{
    public sealed class ActivateUserBadRequestException : BadRequestException
    {
        public ActivateUserBadRequestException() : base("User is already active.") { }
    }
}

