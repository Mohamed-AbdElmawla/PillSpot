using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IPermissionService
    {
        Task<PermissionDto> CreatePermissionAsync(CreatePermissionDto permissionDto);
        Task<(IEnumerable<PermissionDto> pharmacies, int ids)> CreatePermissionCollectionAsync(IEnumerable<CreatePermissionDto> permissionCollection);
        Task<(IEnumerable<PermissionDto> permissions, MetaData metaData)> GetAllPermissionsAsync(PermissionParameters permissionParameters, bool trackChanges);
        Task<PermissionDto> GetPermissionByIdAsync(int id, bool trackChanges);
        Task DeletePermissionAsync(int permissionId , bool trackChanges);
        Task UpdatePermissionAsync(int permissionId, UpdatePermissionDto permissionDto , bool trackChanges);
    }
}
