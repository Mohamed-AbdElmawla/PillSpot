namespace Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; } 
        IPermissionRepository PermissionRepository { get; }
        IEmployeePermissionRepository EmployeePermissionRepository { get;}
        IAdminPermissionRepository AdminPermissionRepository { get; }
        IAdminRepository AdminRepository { get; }
        IPharmacyRepository PharmacyRepository { get; }
        IPharmacyRequestRepository PharmacyRequestRepository { get; }
        ILocationRepository LocationRepository { get; }
        ICityRepository CityRepository { get; }
        IGovernmentRepository GovernmentRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IMedicineRepository MedicineRepository { get; }
        ICosmeticRepository CosmeticRepository { get; }
        IPharmacyProductRepository PharmacyProductRepository { get; }
        IPharmacyEmployeeRepository PharmacyEmployeeRepository { get; }
        IPharmacyEmployeeRequestRepository PharmacyEmployeeRequestRepository { get; }
        IOrderRepository OrderRepository { get; }
        INotificationRepository NotificationRepository { get; }
        ICartRepository CartRepository { get; }
        ICartItemRepository CartItemRepository { get; }
        IUserAddressRepository UserAddressRepository { get; }
        Task SaveAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
