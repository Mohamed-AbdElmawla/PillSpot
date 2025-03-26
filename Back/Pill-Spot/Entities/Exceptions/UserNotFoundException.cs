namespace Entities.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string userId) : base($"User with Email: {userId} was not found")
        {
            
        }
    }
}
