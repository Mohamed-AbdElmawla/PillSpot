namespace Entities.Exceptions
{
    public sealed class EmployeeApprovedBadRequestException : BadRequestException
    {
        public EmployeeApprovedBadRequestException() : base("A request already approved this pharmacy.")
        {
        }
    }
}