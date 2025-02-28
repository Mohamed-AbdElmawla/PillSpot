using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPermissionRepository
    {
        Task CreatePermissionAsync(Permission permission);
        Task<PagedList<Permission>> GetAllPermissionAsync(PermissionParameters permissionParameters, bool trackChanges);
        Task<Permission> GetPermissionByIdAsync(int id, bool trackChanges);
        void UpdatePermission(Permission permission , bool trackChanges);
        void DeletePermission(Permission permission);
    }
}
