namespace Entities.Exceptions
{
    public class DtoArgumentNullException : ArgumentNullException
    {
        public DtoArgumentNullException(string dtoAction)
            : base($"this {dtoAction} is null.")
        {
        }
    }
}
