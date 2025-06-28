using PillSpot.Service.Contracts;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IUserService UserService { get; }
        IEmailService EmailService { get; }
        ISerilogService SerilogService { get; }
        IPermissionService PermissionService { get; }
        IEmployeePermissionService EmployeePermissionService { get; }
        IAdminPermissionService AdminPermissionService { get; }
        IAdminService AdminService { get; }
        IPharmacyService PharmacyService { get; }
        IPharmacyRequestService PharmacyRequestService { get; }
        ICategoryService CategoryService { get; }
        ISubCategoryService SubCategoryService { get; }
        IProductService ProductService { get; }
        IMedicineService MedicineService { get; }
        ICosmeticService CosmeticService { get; }
        IPharmacyProductService PharmacyProductService { get; }
        IPharmacyEmployeeRequestService PharmacyEmployeeRequestService { get; }
        IPharmacyEmployeeService PharmacyEmployeeService { get; }
        IOrderService OrderService { get; }
        INotificationService NotificationService { get; }
        IUserAddressService UserAddressService { get; }
        ICartService CartService { get; }
        ICartItemService CartItemService { get; }
        IPharmacyEmployeeRoleService PharmacyEmployeeRoleService { get; }
        IPrescriptionService PrescriptionService { get; }
        IPharmacyProductNotificationPreferenceService PharmacyProductNotificationPreferenceService { get; }
        ISecurityService SecurityService { get; }
    }
}
