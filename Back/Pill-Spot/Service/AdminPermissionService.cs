using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class AdminPermissionService : IAdminPermissionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public AdminPermissionService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AdminPermissionDto> AssignPermissionToAdminAsync(CreateAdminPermissionDto createAdminPermissionDto)
        {
            var adminPermissionEntity = _mapper.Map<AdminPermission>(createAdminPermissionDto);
            await _repository.AdminPermissionRepository.AssignPermissionToAdminAsync(adminPermissionEntity);
            await _repository.SaveAsync();
            return _mapper.Map<AdminPermissionDto>(adminPermissionEntity);
        }

        public async Task<IEnumerable<AdminPermissionDto>> AssignPermissionsToAdminAsync(string adminId, IEnumerable<int> permissionIds)
        {
            if (permissionIds == null || !permissionIds.Any())
                throw new AdminPermissionCollectionBadRequestException();

            var adminPermissions = permissionIds
                .Select(pid => new AdminPermission { AdminId = adminId, PermissionId = pid });

            await _repository.AdminPermissionRepository.AssignPermissionsToAdminAsync(adminPermissions);
            await _repository.SaveAsync();

            return _mapper.Map<IEnumerable<AdminPermissionDto>>(adminPermissions);
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissionsToAdminAsync(string adminId, bool trackChanges)
        {
            var adminPermissions = await _repository.AdminPermissionRepository.GetAdminPermissionsAsync(adminId, trackChanges);
            if (adminPermissions == null || !adminPermissions.Any())
                throw new AdminPermissionNotFoundException(adminId);

            // Map each AdminPermission to its related PermissionDto
            var permissionDtos = adminPermissions
                .Select(ap => _mapper.Map<PermissionDto>(ap.Permission));
            return permissionDtos;
        }

        public async Task RemovePermissionFromAdminAsync(string adminId, int permissionId)
        {
            var adminPermission = (await _repository.AdminPermissionRepository.GetAdminPermissionsAsync(adminId, false))
                .FirstOrDefault(ap => ap.PermissionId == permissionId);
            if (adminPermission == null)
                throw new AdminPermissionNotFoundException(adminId, permissionId);

            _repository.AdminPermissionRepository.RemovePermissionFromAdmin(adminPermission);
            await _repository.SaveAsync();
        }

        public async Task RemovePermissionsFromAdminAsync(string adminId, IEnumerable<int> permissionIds)
        {
            if (permissionIds == null || !permissionIds.Any())
                throw new AdminPermissionCollectionBadRequestException();

            var adminPermissions = (await _repository.AdminPermissionRepository.GetAdminPermissionsAsync(adminId, false))
                .Where(ap => permissionIds.Contains(ap.PermissionId))
                .ToList();

            if (!adminPermissions.Any())
                throw new AdminPermissionNotFoundException(adminId);

            _repository.AdminPermissionRepository.RemovePermissionsFromAdmin(adminPermissions);
            await _repository.SaveAsync();
        }

    }
}
