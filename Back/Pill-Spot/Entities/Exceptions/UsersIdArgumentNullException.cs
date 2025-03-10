namespace Entities.Exceptions
{
    public class UsersIdArgumentNullException : ArgumentNullException
    {
        public UsersIdArgumentNullException(string dtoUsersId)
            : base($"Current user id: {dtoUsersId} must be provided.")
        {
        }
    }
}