namespace Entities.Exceptions
{
    public class NotAnAdminException : NotAuthorizedException
    {
        public NotAnAdminException(string adminId)
            : base($"User with ID '{adminId}' is not an admin."){ }
    }
}