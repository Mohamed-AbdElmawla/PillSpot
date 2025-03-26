namespace Entities.Exceptions
{
    public sealed class PharmacySuspendBadRequestException : BadRequestException
    {
        public PharmacySuspendBadRequestException() : base("this Pharmacy Is Suspend") { }
    }
}
