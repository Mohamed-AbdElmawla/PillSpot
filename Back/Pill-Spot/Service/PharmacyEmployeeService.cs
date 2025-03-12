using Contracts;
using Service.Contracts;

namespace Service
{
    public class PharmacyEmployeeService : IPharmacyEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        public PharmacyEmployeeService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    }
}
