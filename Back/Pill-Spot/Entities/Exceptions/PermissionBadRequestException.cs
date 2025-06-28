namespace Entities.Exceptions
{
    public sealed class PermissionBadRequestException : BadRequestException
    {
        public PermissionBadRequestException() : base("Permission data is null.") { }
    }
}
