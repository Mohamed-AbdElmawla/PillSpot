using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IPermissionRepository
    {
        void CreatePermissionAsync(Permission permission);
        Task<PagedList<Permission>> GetAllPermissionAsync(PermissionParameters permissionParameters, bool trackChanges);
        Task<Permission> GetPermissionByIdAsync(Guid permissionId, bool trackChanges);
        void UpdatePermission(Permission permission, bool trackChanges);
        void DeletePermission(Permission permission);
    }
}
