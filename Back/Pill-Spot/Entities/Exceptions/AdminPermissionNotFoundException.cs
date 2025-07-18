﻿namespace Entities.Exceptions
{
    public sealed class AdminPermissionNotFoundException : NotFoundException
    {
        public AdminPermissionNotFoundException(string adminId)
            : base($"No permissions found for Admin with ID: {adminId}.")
        { }

        public AdminPermissionNotFoundException(string adminId, Guid permissionId)
            : base($"Permission with ID: {permissionId} not found for Admin with ID: {adminId}.")
        { }
    }
}
