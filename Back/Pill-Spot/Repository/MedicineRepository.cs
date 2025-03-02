using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class MedicineRepository : RepositoryBase<Medicine>, IMedicineRepository
    {
        public MedicineRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateMedicine(Medicine medicine) => Create(medicine);

        public void DeleteMedicine(Medicine medicine) => Delete(medicine);

        public async Task<Medicine> GetMedicineAsync(ulong productId, bool trackChanges) =>
            await FindByCondition(m => m.ProductId.Equals(productId), trackChanges).SingleOrDefaultAsync();
    }
}
