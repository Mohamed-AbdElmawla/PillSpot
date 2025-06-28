using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public class EmployeePermissionService : IEmployeePermissionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public EmployeePermissionService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<EmployeePermissionDto> AssignPermissionToEmployeeAsync(AssignEmployeePermissionDto assignEmployeePermissionDto)
        {

            if (!await IsEmployeeAsync(assignEmployeePermissionDto.EmployeeId))
                throw new NotAnEmployeeException(assignEmployeePermissionDto.EmployeeId.ToString());

            var employeePermissionEntity = _mapper.Map<PharmacyEmployeePermission>(assignEmployeePermissionDto);
            _repository.EmployeePermissionRepository.AssignPermissionToEmployeeAsync(employeePermissionEntity);
            await _repository.SaveAsync();
            return _mapper.Map<EmployeePermissionDto>(employeePermissionEntity);
        }

        public async Task<IEnumerable<EmployeePermissionDto>> AssignPermissionsToEmployeeAsync(Guid employeeId, IEnumerable<Guid> permissionIds)
        {
            if (permissionIds == null || !permissionIds.Any())
                throw new EmployeePermissionCollectionBadRequestException();

            var epmloyeePermissions = permissionIds
                .Select(pid => new PharmacyEmployeePermission { EmployeeId = employeeId, PermissionId = pid });

            _repository.EmployeePermissionRepository.AssignPermissionsToEmployeeAsync(epmloyeePermissions);
            await _repository.SaveAsync();

            return _mapper.Map<IEnumerable<EmployeePermissionDto>>(epmloyeePermissions);
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissionsToEmployeeAsync(Guid employeeId, bool trackChanges)
        {
            var employeePermissions = await _repository.EmployeePermissionRepository.GetEmployeePermissionsAsync(employeeId, trackChanges);
            if (employeePermissions == null || !employeePermissions.Any())
                throw new EployeePermissionNotFoundException(employeeId);

            var permissionDtos = employeePermissions
                .Select(ap => _mapper.Map<PermissionDto>(ap.Permission));
            return permissionDtos;
        }

        public async Task RemovePermissionFromEmployeeAsync(Guid employeeId, Guid permissionId)
        {
            var employeePermission = (await _repository.EmployeePermissionRepository.GetEmployeePermissionsAsync(employeeId, false))
                .FirstOrDefault(ap => ap.PermissionId.Equals(permissionId));

            if (employeePermission == null)
                throw new EployeePermissionNotFoundException(employeeId, permissionId);

            _repository.EmployeePermissionRepository.RemovePermissionFromEmployee(employeePermission);
            await _repository.SaveAsync();
        }

        public async Task RemovePermissionsFromEmployeeAsync(Guid employeeId, IEnumerable<Guid> permissionIds)
        {
            if (permissionIds == null || !permissionIds.Any())
                throw new EmployeePermissionCollectionBadRequestException();

            var employeePermissions = await _repository.EmployeePermissionRepository
                .GetEmployeePermissionsByIdsAsync(employeeId, permissionIds, false);

            if (!employeePermissions.Any())
                throw new EployeePermissionNotFoundException(employeeId);

            _repository.EmployeePermissionRepository.RemovePermissionsFromEmployee(employeePermissions);
            await _repository.SaveAsync();
        }
        public async Task<bool> IsEmployeeAsync(Guid employeeId)
        {
            var userId = await _repository.PharmacyEmployeeRepository.GetUserIdByEmployeeIdAsync(employeeId, false);

            if (string.IsNullOrEmpty(userId))
                throw new UserNotFoundException(employeeId.ToString());

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new UserNotFoundException(userId);

            return await _userManager.IsInRoleAsync(user, "PharmacyEmployee");
        }
        public async Task<Guid> GetEmployeeIdByUserIdAsync(string userId, bool trackChanges)
        {
            return await _repository.PharmacyEmployeeRepository.GetEmployeeIdByUserIdAsync(userId, trackChanges);
        }
        public async Task<bool> HasPermissionAsync(string userId, string requiredPermission, bool isAdminCheck = false)
        {

            var employeeId = await _repository.PharmacyEmployeeRepository.GetEmployeeIdByUserIdAsync(userId, false);
            if (employeeId == null)
                return false;

            var employeePermissions = await _repository.EmployeePermissionRepository.GetEmployeePermissionsAsync(employeeId, false);
            return employeePermissions.Any(p => p.Permission.Name == requiredPermission);
        }
        public async Task<bool> EmployeeHasPermissionAsync(Guid employeeId, string permissionName,bool trackChanges)
        {
            var permission = await _repository.PermissionRepository.GetByNameAsync(permissionName, trackChanges);
            if (permission == null) return false;

            return await _repository.EmployeePermissionRepository.ExistsAsync(employeeId, permission.PermissionId,trackChanges);
        }
        public async Task<(IEnumerable<EmployeePermissionDto> employeePermissions, MetaData metaData)> GetAllEmployeePermissionsAsync(EmployeePermissionParameters employeePermissionParameters, bool trackChanges)
        {
            var employeePermissionsPagedList = await _repository.EmployeePermissionRepository
                .GetAllEmployeePermissionsAsync(employeePermissionParameters, trackChanges);

            var employeePermissionDto = _mapper.Map<IEnumerable<EmployeePermissionDto>>(employeePermissionsPagedList);

            return (employeePermissions: employeePermissionDto, employeePermissionsPagedList.MetaData);
        }
    }
}