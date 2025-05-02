using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class AdminPermissionService : IAdminPermissionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AdminPermissionService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<bool> AdminHasPermissionAsync(string adminId, string permissionName, bool trackChanges)
        {
            var permission = await _repository.PermissionRepository.GetByNameAsync(permissionName, trackChanges);
            if (permission == null) return false;

            return await _repository.AdminPermissionRepository.ExistsAsync(adminId, permission.PermissionId);
        }
        public async Task<AdminPermissionDto> AssignPermissionToAdminAsync(AssignAdminPermissionDto assignAdminPermissionDto, bool trackChanges)
        {
            if (!await IsAdminAsync(assignAdminPermissionDto.AdminId))
                throw new NotAnAdminException(assignAdminPermissionDto.AdminId);

            var hasThisPermission = await _repository.AdminPermissionRepository.GetAdminPermissionAsync(assignAdminPermissionDto.AdminId,
                assignAdminPermissionDto.PermissionId, trackChanges);

            if (hasThisPermission != null)
                throw new AdminPermissionAlreadyAssignedException(assignAdminPermissionDto.AdminId, new List<Guid> { assignAdminPermissionDto.PermissionId });

            var adminPermissionEntity = _mapper.Map<AdminPermission>(assignAdminPermissionDto);
            _repository.AdminPermissionRepository.AssignPermissionToAdminAsync(adminPermissionEntity);
            await _repository.SaveAsync();
            return _mapper.Map<AdminPermissionDto>(adminPermissionEntity);
        }

        public async Task<IEnumerable<AdminPermissionDto>> AssignPermissionsToAdminAsync(string adminId, IEnumerable<Guid> permissionIds)
        {
            if (!await IsAdminAsync(adminId))
                throw new NotAnAdminException(adminId);

            if (permissionIds == null || !permissionIds.Any())
                throw new AdminPermissionCollectionBadRequestException();

            if (await _repository.AdminPermissionRepository.AdminHasAnyPermissionAsync(adminId, permissionIds))
                throw new AdminPermissionAlreadyAssignedException(adminId, permissionIds);

            var adminPermissions = permissionIds
                .Select(pid => new AdminPermission { AdminId = adminId, PermissionId = pid });

            _repository.AdminPermissionRepository.AssignPermissionsToAdminAsync(adminPermissions);
            await _repository.SaveAsync();

            return _mapper.Map<IEnumerable<AdminPermissionDto>>(adminPermissions);
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissionsToAdminAsync(string adminId, bool trackChanges)
        {
            if (!await IsAdminAsync(adminId))
                throw new NotAnAdminException(adminId);

            var adminPermissions = await _repository.AdminPermissionRepository.GetAdminPermissionsAsync(adminId, trackChanges);
            if (adminPermissions == null || !adminPermissions.Any())
                throw new AdminPermissionNotFoundException(adminId);

            return adminPermissions.Select(ep => _mapper.Map<PermissionDto>(ep.Permission));
        }

        public async Task RemovePermissionFromAdminAsync(string adminId, Guid permissionId)
        {
            if (!await IsAdminAsync(adminId))
                throw new NotAnAdminException(adminId);

            var adminPermission = await _repository.AdminPermissionRepository.GetAdminPermissionAsync(adminId, permissionId, false);

            if (adminPermission == null)
                throw new AdminPermissionNotFoundException(adminId, permissionId);

            _repository.AdminPermissionRepository.RemovePermissionFromAdmin(adminPermission);
            await _repository.SaveAsync();
        }

        public async Task RemovePermissionsFromAdminAsync(string adminId, IEnumerable<Guid> permissionIds)
        {
            if (!await IsAdminAsync(adminId))
                throw new NotAnAdminException(adminId);

            if (permissionIds == null || !permissionIds.Any())
                throw new AdminPermissionCollectionBadRequestException();

            var adminPermissions = await _repository.AdminPermissionRepository.
                GetAdminPermissionsByIdsAsync(adminId, permissionIds, false);

            if (!adminPermissions.Any())
                throw new AdminPermissionNotFoundException(adminId);

            _repository.AdminPermissionRepository.RemovePermissionsFromAdmin(adminPermissions);
            await _repository.SaveAsync();
        }

        public async Task<bool> IsAdminAsync(string adminId)
        {
            var user = await _userManager.FindByIdAsync(adminId);
            if (user == null)
                throw new UserNotFoundException(adminId);

            return await _userManager.IsInRoleAsync(user, "Admin");
        }
        public async Task<bool> HasPermissionAsync(string userId, string requiredPermission, bool isAdminCheck = true)
        {
            var adminPermissions = await _repository.AdminPermissionRepository.GetAdminPermissionsAsync(userId,false);
            return adminPermissions.Any(p => p.Permission.Name == requiredPermission);
        }
    }
}
