using Contracts;
using Service.Contracts;
namespace Service
{
    public class PharmacyEmployeeRoleService : IPharmacyEmployeeRoleService
    {
        private readonly IRepositoryManager _repository;

        public PharmacyEmployeeRoleService(IRepositoryManager repository)=> _repository = repository;

        public async Task<bool> UserHasRoleInPharmacyAsync(string userId, string roleName, Guid pharmacyId, bool trackChanges)=>
            await _repository.PharmacyEmployeeRoleRepository.ExistsAsync(userId, roleName, pharmacyId,trackChanges);
    }

}
