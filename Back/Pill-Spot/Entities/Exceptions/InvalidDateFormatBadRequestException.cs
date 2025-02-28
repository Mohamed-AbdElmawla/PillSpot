namespace Entities.Exceptions
{
    public sealed class IORequestException : IOException
    {
        public IORequestException() : base("Invalid date format. Use YYYY-MM-DD."){}
    }
}
