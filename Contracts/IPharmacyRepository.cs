using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Contracts
{
    public interface IPharmacyRepository
    {
        Task<IEnumerable<Pharmacy>> GetAllPharmaciesAsync(bool trackChanges);
        Task<Pharmacy> GetPharmacyAsync(int pharmacyId, bool trackChanges);
        void CreatePharmacy(Pharmacy pharmacy);
        Task<IEnumerable<Pharmacy>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
    }
}

