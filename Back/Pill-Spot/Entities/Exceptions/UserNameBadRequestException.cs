namespace Entities.Exceptions
{
    public sealed class UserNameBadRequestException: BadRequestException
    {
        public UserNameBadRequestException() : base("Invalid user name") { }
    }
}
