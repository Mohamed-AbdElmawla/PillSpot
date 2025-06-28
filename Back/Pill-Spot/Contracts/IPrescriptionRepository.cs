using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IPrescriptionRepository
    {
        Task<PagedList<Prescription>> GetAllPrescriptionAsync(PrescriptionParameters prescriptionParameters, bool trackChanges);
        Task<IEnumerable<Prescription>> GetPrescriptionUserAsync(string userId, bool trackChanges);
        Task<Prescription> GetPrescriptionByIdAsync(Guid prescriptionId, bool trackChanges);
        void CreatePrescription(Prescription prescription);
        void UpdatePrescription(Prescription prescription);
        void DeletePrescription(Prescription prescription);
    }
}