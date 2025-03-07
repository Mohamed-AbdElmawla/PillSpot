using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    internal sealed class MedicineRepository : RepositoryBase<Medicine>, IMedicineRepository
    {
        public MedicineRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateMedicine(Medicine medicine) => Create(medicine);

        public void DeleteMedicine(Medicine medicine) => Delete(medicine);

        public async Task<Medicine> GetMedicineAsync(Guid productId, bool trackChanges) =>
            await FindByCondition(m => m.ProductId.Equals(productId), trackChanges).SingleOrDefaultAsync();
    }
}
