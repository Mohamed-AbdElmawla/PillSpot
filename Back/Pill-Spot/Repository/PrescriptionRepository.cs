using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
    internal sealed class PrescriptionRepository(RepositoryContext context) : RepositoryBase<Prescription>(context), IPrescriptionRepository
    {
        public async Task<PagedList<Prescription>> GetAllPrescriptionAsync(PrescriptionParameters prescriptionParameters, bool trackChanges)
        {
            var prescriptions = await FindAll(trackChanges)
                .Where(p => !p.IsDeleted)
                .Include(p => p.PrescriptionProducts.Where(pp => !pp.IsDeleted))
                .ThenInclude(pp => pp.Product)
                .Search(prescriptionParameters.SearchTerm)
                .Sort(prescriptionParameters.OrderBy)
                .Skip((prescriptionParameters.PageNumber - 1) * prescriptionParameters.PageSize)
                .Take(prescriptionParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();
            return new PagedList<Prescription>(prescriptions, count, prescriptionParameters.PageNumber, prescriptionParameters.PageSize);
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionUserAsync(string userId, bool trackChanges)=>
            await FindByCondition(p => p.UserId.Equals(userId) && !p.IsDeleted, trackChanges)
            .Include(p => p.PrescriptionProducts.Where(pp => !pp.IsDeleted))
            .ThenInclude(pp => pp.Product)
            .ToListAsync();

        public async Task<Prescription> GetPrescriptionByIdAsync(Guid prescriptionId, bool trackChanges)=>
           await FindByCondition(p => p.PrescriptionId.Equals(prescriptionId) && !p.IsDeleted, trackChanges)
            .Include(p => p.PrescriptionProducts.Where(pp => !pp.IsDeleted))
            .ThenInclude(pp => pp.Product)
            .SingleOrDefaultAsync();

        public void CreatePrescription(Prescription prescription) => Create(prescription);

        public void UpdatePrescription(Prescription prescription)
        {
            prescription.UpdatedAt = DateTime.UtcNow;
            Update(prescription);
        }

        public void DeletePrescription(Prescription prescription)
        {
            prescription.IsDeleted = true;
            prescription.UpdatedAt = DateTime.UtcNow;
            Update(prescription);

            var prescriptionProducts = context.ProductPrescriptions
                .Where(pp => pp.PrescriptionId.Equals(prescription.PrescriptionId));

            foreach (var pp in prescriptionProducts)
                pp.IsDeleted = true;
        }
    }
}