using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAdminService
    {
        Task BulkManageUsersAsync(BulkUserManagementDto dto, string currentUserId, bool trackChanges);
        Task AssignUserRoleAsync(AssignUserRoleDto dto, string currentUserId, bool trackChanges);
      // Task<byte[]> ExportUserDataAsync();
    }
}
