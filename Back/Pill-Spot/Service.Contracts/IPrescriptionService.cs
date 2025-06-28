using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IPrescriptionService
    {
        Task<(IEnumerable<PrescriptionDto> prescriptions, MetaData metaData)> GetAllPrescriptionsAsync(PrescriptionParameters prescriptionParameters, bool trackChanges);
        Task<PagedList<PrescriptionDto>> GetPrescriptionsByUserAsync(string userId, PrescriptionParameters prescriptionParameters, bool trackChanges);
        Task<PrescriptionDto> GetPrescriptionByIdAsync(Guid id, bool trackChanges);
        Task<PrescriptionDto> CreatePrescriptionAsync(PrescriptionForCreationDto prescriptionDto);
        Task UpdatePrescriptionAsync(Guid id, PrescriptionForUpdateDto prescriptionDto, bool trackChanges);
        Task DeletePrescriptionAsync(Guid id, bool trackChanges);
    }
}