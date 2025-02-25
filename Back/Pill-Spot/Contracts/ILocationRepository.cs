using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ILocationRepository
    {
        Task<PagedList<Location>> GetAllLocationsAsync(LocationRequestParameters locationRequestParameters, bool trackChanges);
        Task<Location> GetLocationByIdAsync(Guid locationId, bool trackChanges);
        void CreateLocation(Location location);
        void DeleteLocation(Location location);
        void UpdateLocation(Location location);
    }
}
