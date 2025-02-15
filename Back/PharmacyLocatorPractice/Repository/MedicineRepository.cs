using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class MedicineRepository : RepositoryBase<Medicine>, IMedicineRepository
    {
        public MedicineRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateMedicine(Medicine medicine) => Create(medicine);

        public async Task<Medicine> GetMedicineAsync(string medicineId, bool trackChanges) => await FindByCondition(md => md.MedicineId.Equals(medicineId), trackChanges).SingleOrDefaultAsync();

        public void DeleteMedicine(Medicine Medicine) => Delete(Medicine);
    }
}
