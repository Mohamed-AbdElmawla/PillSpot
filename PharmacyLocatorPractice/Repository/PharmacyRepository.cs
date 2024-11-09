using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using Repository.Extensions;
using System.Collections.Concurrent;
namespace Repository
{
    public class PharmacyRepository : RepositoryBase<Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreatePharmacy(Pharmacy pharmacy) => Create(pharmacy);

        public void DeletePharmacy(Pharmacy pharmacy) => Delete(pharmacy);

        public async Task<PagedList<Pharmacy>> GetAllPharmaciesAsync(bool trackChanges, PharmaciesParameters pharmaciesparameters)
        {
            var Pharmacies = await FindAll(trackChanges)
            .OrderBy(ph => ph.Name)
            .Paging(pharmaciesparameters.PageNumber, pharmaciesparameters.PageSize)
            .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Pharmacy>(Pharmacies, count, pharmaciesparameters.PageNumber, pharmaciesparameters.PageSize);
        }

        public async Task<IEnumerable<Pharmacy>> GetByIdsAsync(IEnumerable<string> ids, bool trackChanges) => await FindByCondition(ph => ids.Contains(ph.PharmacyId), trackChanges).ToListAsync();

        public async Task<Pharmacy> GetPharmacyAsync(string pharmacyId, bool trackChanges) => await FindByCondition(ph => ph.PharmacyId.Equals(pharmacyId), trackChanges).SingleOrDefaultAsync();

    }
}
