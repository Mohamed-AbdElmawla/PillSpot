namespace Entities.Exceptions
{
    public abstract class IOException : Exception
    {
        protected IOException(string message) : base(message) { }
    }
}