namespace Entities.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string userId) : base($"User with Id: {userId} was not found")
        {
            
        }
    }
}
