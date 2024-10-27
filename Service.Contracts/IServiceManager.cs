

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IPharmacyService PharmacyService { get; }
        IPharmacyMedicineService PharmacyMedicineService { get; }
        IOrderService OrderService { get; }
        IMedicineService MedicineService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
