namespace Entities.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string userId) : base($"User with Name: {userId} was not found")
        {
            
        }
    }
}
