namespace Entities.Exceptions
{
    public class CurrentUserNotFoundException : NotFoundException
    {
        public CurrentUserNotFoundException(string userId) : base($"Current User with userName: {userId} was not found")
        {
            
        }
    }
}
