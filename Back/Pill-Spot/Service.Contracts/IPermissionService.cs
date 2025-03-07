using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IPermissionService
    {
        Task<PermissionDto> CreatePermissionAsync(CreatePermissionDto permissionDto);
        Task<(IEnumerable<PermissionDto> pharmacies, Guid ids)> CreatePermissionCollectionAsync(IEnumerable<CreatePermissionDto> permissionCollection);
        Task<(IEnumerable<PermissionDto> permissions, MetaData metaData)> GetAllPermissionsAsync(PermissionParameters permissionParameters, bool trackChanges);
        Task<PermissionDto> GetPermissionByIdAsync(Guid id, bool trackChanges);
        Task DeletePermissionAsync(Guid permissionId, bool trackChanges);
        Task UpdatePermissionAsync(Guid permissionId, UpdatePermissionDto permissionDto, bool trackChanges);
    }
}
