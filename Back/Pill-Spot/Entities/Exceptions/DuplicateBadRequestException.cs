
namespace Entities.Exceptions
{
    public sealed class DuplicateBadRequestException : BadRequestException
    {
        public DuplicateBadRequestException() : base("A request already exists for this user in this pharmacy.")
        {
        }
    }
}
