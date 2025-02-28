using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAdminPermissionService
    {
        Task<AdminPermissionDto> AssignPermissionToAdminAsync(CreateAdminPermissionDto createAdminPermissionDto);
        Task<IEnumerable<AdminPermissionDto>> AssignPermissionsToAdminAsync(string adminId, IEnumerable<int> permissionIds);
        Task<IEnumerable<PermissionDto>> GetPermissionsToAdminAsync(string adminId, bool trackChanges);
        Task RemovePermissionFromAdminAsync(string adminId, int permissionId);
        Task RemovePermissionsFromAdminAsync(string adminId, IEnumerable<int> permissionIds);
    }
}
