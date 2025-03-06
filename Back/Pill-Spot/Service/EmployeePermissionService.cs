using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class EmployeePermissionService : IEmployeePermissionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EmployeePermissionService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeePermissionDto> AssignPermissionToEmployeeAsync(CreateEmployeePermissionDto createEmployeePermissionDto)
        {
            var employeePermissionEntity = _mapper.Map<PharmacyEmployeePermission>(createEmployeePermissionDto);
            await _repository.EmployeePermissionRepository.AssignPermissionToEmployeeAsync(employeePermissionEntity);
            await _repository.SaveAsync();
            return _mapper.Map<EmployeePermissionDto>(employeePermissionEntity);
        }

        public async Task<IEnumerable<EmployeePermissionDto>> AssignPermissionsToEmployeeAsync(ulong employeeId, IEnumerable<int> permissionIds)
        {
            if (permissionIds == null || !permissionIds.Any())
                throw new EmployeePermissionCollectionBadRequestException();

            var epmloyeePermissions = permissionIds
                .Select(pid => new PharmacyEmployeePermission { EmployeeId = employeeId, PermissionId = pid });

            await _repository.EmployeePermissionRepository.AssignPermissionsToEmployeeAsync(epmloyeePermissions);
            await _repository.SaveAsync();

            return _mapper.Map<IEnumerable<EmployeePermissionDto>>(epmloyeePermissions);
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissionsToEmployeeAsync(ulong employeeId, bool trackChanges)
        {
            var employeePermissions = await _repository.EmployeePermissionRepository.GetEmployeePermissionsAsync(employeeId, trackChanges);
            if (employeePermissions == null || !employeePermissions.Any())
                throw new EployeePermissionNotFoundException(employeeId);

            var permissionDtos = employeePermissions
                .Select(ap => _mapper.Map<PermissionDto>(ap.Permission));
            return permissionDtos;
        }

        public async Task RemovePermissionFromEmployeeAsync(ulong employeeId, int permissionId)
        {
            var employeePermission = (await _repository.EmployeePermissionRepository.GetEmployeePermissionsAsync(employeeId, false))
                .FirstOrDefault(ap => ap.PermissionId == permissionId);
            if (employeePermission == null)
                throw new EployeePermissionNotFoundException(employeeId, permissionId);

            _repository.EmployeePermissionRepository.RemovePermissionFromEmployee(employeePermission);
            await _repository.SaveAsync();
        }

        public async Task RemovePermissionsFromEmployeeAsync(ulong employeeId, IEnumerable<int> permissionIds)
        {
            if (permissionIds == null || !permissionIds.Any())
                throw new EmployeePermissionCollectionBadRequestException();

            var employeePermissions = (await _repository.EmployeePermissionRepository.GetEmployeePermissionsAsync(employeeId, false))
                .Where(ap => permissionIds.Contains(ap.PermissionId))
                .ToList();

            if (!employeePermissions.Any())
                throw new EployeePermissionNotFoundException(employeeId);

            _repository.EmployeePermissionRepository.RemovePermissionsFromEmployee(employeePermissions);
            await _repository.SaveAsync();
        }

    }
}