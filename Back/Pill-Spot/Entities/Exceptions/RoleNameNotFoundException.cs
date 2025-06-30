namespace Entities.Exceptions
{
    public sealed class RoleNameNotFoundException : NotFoundException
    {
        public RoleNameNotFoundException(string roleName)
          : base($"Role '{roleName}' does not exist.") { }
    }
}
