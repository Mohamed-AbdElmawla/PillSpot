namespace Entities.Exceptions
{
    public sealed class ActionBadRequestException : BadRequestException
    {
        public ActionBadRequestException(string action) : base($"this {action} is Invalid action specified.") { }
    }
}
