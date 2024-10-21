using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class PharmacyRepository : RepositoryBase<Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreatePharmacy(Pharmacy pharmacy) => Create(pharmacy);

        public async Task<IEnumerable<Pharmacy>> GetAllPharmaciesAsync(bool trackChanges) => await FindAll(trackChanges).OrderBy(ph=>ph.Name).ToListAsync();

        public async Task<IEnumerable<Pharmacy>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges) => await FindByCondition(ph => ids.Contains(ph.PharmacyId), trackChanges).ToListAsync();

        public async Task<Pharmacy> GetPharmacyAsync(int pharmacyId, bool trackChanges) => await FindByCondition(ph => ph.PharmacyId.Equals(pharmacyId), trackChanges).SingleOrDefaultAsync();

    }
}
