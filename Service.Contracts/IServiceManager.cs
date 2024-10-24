

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IPharmacyService PharmacyService { get; }
        IPharmacyMedicineService PharmacyMedicineService { get; }
        IOrderService OrderService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
