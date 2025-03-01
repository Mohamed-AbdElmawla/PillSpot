using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ILocationService
    {
        Task<Guid> CreateLocationAsync(LocationForCreationDto location, bool trackChanges);
        Task DeleteLocationAsync(Guid locationId, bool trackChanges);
        Task<(IEnumerable<LocationDto> locations, MetaData metaData)> GetAllLocationsAsync(LocationRequestParameters locationRequestParameters, bool trackChanges);
        Task<LocationDto> GetLocationByIdAsync(Guid locationId, bool trackChanges);
        Task UpdateLocationAsync(Guid locationId, LocationForCreationDto location, bool trackChanges);
    }
}
