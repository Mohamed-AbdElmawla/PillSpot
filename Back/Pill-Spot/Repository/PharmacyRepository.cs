using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class PharmacyRepository : RepositoryBase<Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreatePharmacy(Pharmacy pharmacy) => Create(pharmacy);

        public void DeletePharmacy(Pharmacy pharmacy) => Delete(pharmacy);

        public async Task<PagedList<Pharmacy>> GetAllPharmaciesAsync(PharmaciesParameters pharmaciesparameters, bool trackChanges)
        {
            var Pharmacies = await FindAll(trackChanges)
            .OrderBy(ph => ph.Name)
            .Skip((pharmaciesparameters.PageNumber - 1) * pharmaciesparameters.PageSize)
            .Take(pharmaciesparameters.PageSize)
            .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Pharmacy>(Pharmacies, count, pharmaciesparameters.PageNumber, pharmaciesparameters.PageSize);
        }
        public async Task<PagedList<Pharmacy>> GetByIdsAsync(IEnumerable<ulong> ids, PharmaciesParameters pharmaciesparameters, bool trackChanges) {

            var Pharmacies = await FindByCondition(ph => ids.Contains(ph.PharmacyID), trackChanges)
                .OrderBy(ph => ph.Name)
                .Skip((pharmaciesparameters.PageNumber - 1) * pharmaciesparameters.PageSize)
                .Take(pharmaciesparameters.PageSize)
                .ToListAsync();
            var count = await FindByCondition(ph => ids.Contains(ph.PharmacyID), trackChanges).CountAsync();
            return new PagedList<Pharmacy>(Pharmacies, count, pharmaciesparameters.PageNumber, pharmaciesparameters.PageSize);
        }

        public async Task<Pharmacy> GetPharmacyAsync(ulong pharmacyId, bool trackChanges) => await FindByCondition(ph => ph.PharmacyID.Equals(pharmacyId), trackChanges).SingleOrDefaultAsync();

    }
}
