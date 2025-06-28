using System;

namespace Entities.Exceptions
{
    public sealed class InvalidApprovalStatusException : BadRequestException
    {
        public InvalidApprovalStatusException(string status)
            : base($"Approval status '{status}' is invalid. Valid statuses are Pending, Approved, or Rejected.") { }
    }
}