using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }

        IPharmacyRepository PharmacyRepository { get; }
        IPharmacyRequestRepository PharmacyRequestRepository { get; }
        ILocationRepository LocationRepository { get; }
        ICityRepository CityRepository { get; }
        IGovernmentRepository GovernmentRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        Task SaveAsync();
    }
}
