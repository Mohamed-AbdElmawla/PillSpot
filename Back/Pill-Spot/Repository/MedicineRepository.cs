using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;

namespace Repository
{
    internal sealed class MedicineRepository : RepositoryBase<Medicine>, IMedicineRepository
    {
        public MedicineRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<PagedList<Medicine>> GetAllMedicinesAsync(MedicinesRequestParameters medicinesRequestParameters, bool trackChanges)
        {
            var medicines = await FindAll(trackChanges)
                .Sort(medicinesRequestParameters.OrderBy)
                .Search(medicinesRequestParameters.SearchTerm)
                .Skip((medicinesRequestParameters.PageNumber - 1) * medicinesRequestParameters.PageSize)
                .Take(medicinesRequestParameters.PageSize)
                .Include(p => p.SubCategory)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Medicine>(medicines, count, medicinesRequestParameters.PageNumber, medicinesRequestParameters.PageSize);
        }
        public void CreateMedicine(Medicine medicine) => Create(medicine);

        public void DeleteMedicine(Medicine medicine) => Delete(medicine);

        public void UpdateMedicine(Medicine medicine) => Update(medicine);

        public async Task<Medicine> GetMedicineAsync(Guid productId, bool trackChanges) =>
            await FindByCondition(m => m.ProductId.Equals(productId), trackChanges).Include(m => m.SubCategory).SingleOrDefaultAsync();
    }
}
