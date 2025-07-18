﻿using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
    internal sealed class PermissionRepository(RepositoryContext context) : RepositoryBase<Permission>(context), IPermissionRepository
    {
        public async Task<Permission?> GetByNameAsync(string name, bool trackChanges) =>
           await FindByCondition(p => p.Name.Equals(name), trackChanges)
               .FirstOrDefaultAsync();

        public void CreatePermissionAsync(Permission permission) => Create(permission);

        public async Task<PagedList<Permission>> GetAllPermissionAsync(PermissionParameters permissionParameters, bool trackChanges)
        {
            var permissions = await FindAll(trackChanges)
                .OrderBy(p => p.Name)
                .Skip((permissionParameters.PageNumber - 1) * permissionParameters.PageSize)
                .Take(permissionParameters.PageSize)
                .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();
            return new PagedList<Permission>(permissions, count, permissionParameters.PageNumber, permissionParameters.PageSize);
        }
        
        public async Task<Permission> GetPermissionByIdAsync(Guid permissionId, bool trackChanges) =>
            await FindByCondition(p => p.PermissionId.Equals(permissionId), trackChanges).SingleOrDefaultAsync();

        public void DeletePermission(Permission permission) => Delete(permission);
    }
}
