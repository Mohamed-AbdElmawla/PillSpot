using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    internal sealed class PrescriptionProductRepository(RepositoryContext context) : RepositoryBase<PrescriptionProduct>(context), IPrescriptionProductRepository
    {
        public async Task<IEnumerable<PrescriptionProduct>> GetPrescriptionProductsByPrescriptionIdAsync(Guid prescriptionId, bool trackChanges) =>
            await FindByCondition(pp => pp.PrescriptionId.Equals(prescriptionId) && !pp.IsDeleted, trackChanges).ToListAsync();

        public async Task<PrescriptionProduct> GetPrescriptionProductByIdAsync(Guid prescriptionId, Guid productId, bool trackChanges) => 
            await FindByCondition(pp => pp.PrescriptionId.Equals(prescriptionId) && pp.ProductId.Equals(productId) && !pp.IsDeleted, trackChanges).SingleOrDefaultAsync();

        public void AddPrescriptionProductsRange(IEnumerable<PrescriptionProduct> prescriptionProducts)
        {
            foreach (var pp in prescriptionProducts)
                Create(pp);
        }

        public void CreatePrescriptionProduct(PrescriptionProduct prescriptionProduct) => Create(prescriptionProduct);

        public void UpdatePrescriptionProduct(PrescriptionProduct prescriptionProduct) => Update(prescriptionProduct);

        public void DeletePrescriptionProduct(PrescriptionProduct prescriptionProduct)
        {
            prescriptionProduct.IsDeleted = true;
            Update(prescriptionProduct);
        }

        public void DeletePrescriptionProductsRange(IEnumerable<PrescriptionProduct> prescriptionProducts)
        {
            foreach (var pp in prescriptionProducts)
            {
                pp.IsDeleted = true;
                Update(pp);
            }
        }
    }
}