
namespace Entities.Exceptions
{
    public sealed class UnauthorizedApprovalException : BadRequestException
    {
        public UnauthorizedApprovalException() : base("You are not allowed to approve this request.") { }
    }
}
