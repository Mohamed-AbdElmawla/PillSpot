using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;
using System.Collections.Immutable;
using System.Linq.Dynamic.Core;

namespace Repository
{
    internal sealed class PharmacyRepository : RepositoryBase<Pharmacy>, IPharmacyRepository
    {
        public PharmacyRepository(RepositoryContext repositoryContext) : base(repositoryContext){}

        public void CreatePharmacy(Pharmacy pharmacy) => Create(pharmacy);

        public void DeletePharmacy(Pharmacy pharmacy) => Delete(pharmacy);

        public async Task<PagedList<Pharmacy>> GetAllPharmaciesAsync(PharmaciesParameters pharmaciesparameters, bool trackChanges)
        {
            var Pharmacies = await FindAll(trackChanges)
            .OrderBy(ph => ph.Name)
            .Search(pharmaciesparameters.SearchTerm)
            .Skip((pharmaciesparameters.PageNumber - 1) * pharmaciesparameters.PageSize)
            .Take(pharmaciesparameters.PageSize)
            .Where(ph=>ph.IsActive)
            .Include(pr => pr.Location)
            .Include(pr => pr.Location.City)
            .Include(pr => pr.Location.City.Government)
            .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Pharmacy>(Pharmacies, count, pharmaciesparameters.PageNumber, pharmaciesparameters.PageSize);
        }
        public async Task<PagedList<Pharmacy>> GetByIdsAsync(IEnumerable<Guid> ids, PharmaciesParameters pharmaciesparameters, bool trackChanges) {

            var Pharmacies = await FindByCondition(ph => ids.Contains(ph.PharmacyId) && ph.IsActive, trackChanges)
                .OrderBy(ph => ph.Name)
                .Skip((pharmaciesparameters.PageNumber - 1) * pharmaciesparameters.PageSize)
                .Take(pharmaciesparameters.PageSize)
                .Include(pr => pr.Location)
                .Include(pr => pr.Location.City)
                .Include(pr => pr.Location.City.Government)
                .ToListAsync();

            var count = await FindByCondition(ph => ids.Contains(ph.PharmacyId), trackChanges).CountAsync();
            return new PagedList<Pharmacy>(Pharmacies, count, pharmaciesparameters.PageNumber, pharmaciesparameters.PageSize);
        }

        public async Task<Pharmacy> GetPharmacyAsync(Guid pharmacyId, bool trackChanges) => await FindByCondition(ph => ph.PharmacyId.Equals(pharmacyId), trackChanges)
                .Include(pr => pr.Location)
                .Include(pr => pr.Location.City)
                .Include(pr => pr.Location.City.Government)
                .SingleOrDefaultAsync();

    }
}
