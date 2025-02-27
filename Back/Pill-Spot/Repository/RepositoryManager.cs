using Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IPharmacyRepository> _pharmacyRepository;
        private readonly Lazy<IPharmacyRequestRepository> _pharmacyRequestRepository;
        private readonly Lazy<ILocationRepository> _locationRepository;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly Lazy<IGovernmentRepository> _governmentRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ISubCategoryRepository> _subCategoryRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _pharmacyRepository = new Lazy<IPharmacyRepository>(() => new PharmacyRepository(repositoryContext));
            _pharmacyRequestRepository = new Lazy<IPharmacyRequestRepository>(() => new PharmacyRequestRepository(repositoryContext));
            _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(repositoryContext));
            _governmentRepository = new Lazy<IGovernmentRepository>(() => new GovernmentRepository(repositoryContext));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(repositoryContext));
            _subCategoryRepository = new Lazy<ISubCategoryRepository>(() => new SubCategoryRepository(repositoryContext));
        }
        public IUserRepository UserRepository => _userRepository.Value;
        public IPharmacyRepository PharmacyRepository => _pharmacyRepository.Value;
        public IPharmacyRequestRepository PharmacyRequestRepository => _pharmacyRequestRepository.Value;
        public ILocationRepository LocationRepository => _locationRepository.Value;
        public ICityRepository CityRepository => _cityRepository.Value;
        public IGovernmentRepository GovernmentRepository => _governmentRepository.Value;
        public ICategoryRepository CategoryRepository => _categoryRepository.Value;
        public ISubCategoryRepository SubCategoryRepository => _subCategoryRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
