using Contracts;
using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly Lazy<IMedicineRepository> _medicineRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _pharmacyRepository = new Lazy<IPharmacyRepository>(() => new PharmacyRepository(repositoryContext));
            _pharmacyMedicineRepository = new Lazy<IPharmacyMedicineRepository>(() => new PharmacyMedicineRepository(repositoryContext));
            _medicineRepository = new Lazy<IMedicineRepository>(() => new MedicineRepository(repositoryContext));
        }
        public IPharmacyRepository Pharmacy => _pharmacyRepository.Value;
        public IPharmacyMedicineRepository PharmacyMedicine => _pharmacyMedicineRepository.Value;
        public IMedicineRepository Medicine => _medicineRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
