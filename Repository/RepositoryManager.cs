using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IPharmacyRepository> _pharmacyRepository;
        private readonly Lazy<IPharmacyMedicineRepository> _pharmacyMedicineRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _pharmacyRepository = new Lazy<IPharmacyRepository>(() => new PharmacyRepository(repositoryContext));
            _pharmacyMedicineRepository = new Lazy<IPharmacyMedicineRepository>(() => new
            PharmacyMedicineRepository(repositoryContext));
        }
        public IPharmacyRepository Pharmacy => _pharmacyRepository.Value;
        public IPharmacyMedicineRepository PharmacyMedicine => _pharmacyMedicineRepository.Value;
        public void Save() => _repositoryContext.SaveChanges();
    }
}
