namespace Entities.Exceptions
{
    public abstract class NotAuthorizedException : Exception
    {
        protected NotAuthorizedException(string message) : base(message) { }
    }
}