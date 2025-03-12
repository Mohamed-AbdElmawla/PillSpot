namespace Entities.Exceptions
{
    public abstract class ArgumentNullException : Exception
    {
        protected ArgumentNullException(string message) : base(message) { }
    }
}