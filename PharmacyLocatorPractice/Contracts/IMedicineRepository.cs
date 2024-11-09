using Entities.Models;
namespace Contracts
{
    public interface IMedicineRepository
    {
        Task<Medicine> GetMedicineAsync(string medicineId, bool trackChanges);
        void CreateMedicine(Medicine medicine);
        void DeleteMedicine(Medicine Medicine);
    }
}
