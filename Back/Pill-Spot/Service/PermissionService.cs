using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    internal sealed class PermissionService : IPermissionService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PermissionService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PermissionDto> CreatePermissionAsync(CreatePermissionDto permissionDto)
        {
            var permissionEntity = _mapper.Map<Permission>(permissionDto);
            _repository.PermissionRepository.CreatePermissionAsync(permissionEntity);
            await _repository.SaveAsync();
            return _mapper.Map<PermissionDto>(permissionEntity);
        }
        public async Task<(IEnumerable<PermissionDto> pharmacies, int ids)> CreatePermissionCollectionAsync(IEnumerable<CreatePermissionDto> permissionCollection)
        {
            if (permissionCollection is null)
                throw new PermissionCollectionBadRequest();

            var permissionEntities = _mapper.Map<IEnumerable<Permission>>(permissionCollection);
            
            foreach (var permission in permissionEntities)
                _repository.PermissionRepository.CreatePermissionAsync(permission);
            
            await _repository.SaveAsync();
            var permissionCollectionToReturn = _mapper.Map<IEnumerable<PermissionDto>>(permissionEntities);
            var ids = permissionCollectionToReturn.Select(ph => ph.PermissionId).FirstOrDefault();
            return (pharmacies: permissionCollectionToReturn, ids:ids);
        }
        public async Task<(IEnumerable<PermissionDto> permissions , MetaData metaData)> GetAllPermissionsAsync(PermissionParameters permissionParameters, bool trackChanges)
        {
            var permissions = await _repository.PermissionRepository.GetAllPermissionAsync(permissionParameters,trackChanges);
            var permissionDto =  _mapper.Map<IEnumerable<PermissionDto>>(permissions);
            return (permissions: permissionDto, permissions.MetaData);
        }
        public async Task<PermissionDto> GetPermissionByIdAsync(int id, bool trackChanges)
        {
            var permission = await _repository.PermissionRepository.GetPermissionByIdAsync(id, trackChanges)
                ?? throw new PermissionNotFoundException(id);

            return _mapper.Map<PermissionDto>(permission);
        }
        public async Task UpdatePermissionAsync(int id, UpdatePermissionDto permissionDto , bool trackChanges)
        {
            var permission = await _repository.PermissionRepository.GetPermissionByIdAsync(id, trackChanges)
                ?? throw new PermissionNotFoundException(id);

            _mapper.Map(permissionDto, permission);
            await _repository.SaveAsync();
        }
        public async Task DeletePermissionAsync(int id, bool trackChanges)
        {
            var permission = await _repository.PermissionRepository.GetPermissionByIdAsync(id,trackChanges)
                ?? throw new PermissionNotFoundException(id);

            _repository.PermissionRepository.DeletePermission(permission);
            await _repository.SaveAsync();
        }
    }
}
