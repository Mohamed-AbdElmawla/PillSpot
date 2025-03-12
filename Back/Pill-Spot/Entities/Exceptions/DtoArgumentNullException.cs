namespace Entities.Exceptions
{
    public class DtoArgumentNullException : BadRequestException
    {
        public DtoArgumentNullException(string dtoAction)
            : base($"this {dtoAction} is null.")
        {
        }
    }
}
