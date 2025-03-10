using Contracts;
using Service.Contracts;

namespace Service
{
    public class PharmacyEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        public PharmacyEmployeeService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    }
}
