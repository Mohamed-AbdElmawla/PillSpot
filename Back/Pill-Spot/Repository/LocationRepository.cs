using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateLocation(Location location) => Create(location);

        public void DeleteLocation(Location location) => Delete(location);

        public async Task<PagedList<Location>> GetAllLocationsAsync(LocationRequestParameters locationRequestParameters, bool trackChanges)
        {
            var locations = await FindAll(trackChanges)
               .Sort(locationRequestParameters.OrderBy)
               .Skip((locationRequestParameters.PageNumber - 1) * locationRequestParameters.PageSize)
               .Take(locationRequestParameters.PageSize)
               .ToListAsync();
            var count = await FindAll(trackChanges).CountAsync();
            return new PagedList<Location>(locations, count, locationRequestParameters.PageNumber, locationRequestParameters.PageSize);

        }

        public async Task<Location> GetLocationByIdAsync(Guid locationId, bool trackChanges) 
            => await FindByCondition(l => l.LocationID.Equals(locationId), trackChanges).SingleOrDefaultAsync();

        public void UpdateLocation(Location location) => Update(location);
    }
}
