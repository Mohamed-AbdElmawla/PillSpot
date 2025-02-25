using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPharmacyRepository
    {
        Task<PagedList<Pharmacy>> GetAllPharmaciesAsync(PharmaciesParameters pharmaciesparameters, bool trackChanges);
        Task<Pharmacy> GetPharmacyAsync(ulong pharmacyId, bool trackChanges);
        void CreatePharmacy(Pharmacy pharmacy);
        Task<PagedList<Pharmacy>> GetByIdsAsync(IEnumerable<ulong> ids, PharmaciesParameters pharmaciesparameters, bool trackChanges);
        void DeletePharmacy(Pharmacy pharmacy);
    }
}
