

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IUserService UserService { get; }
        IEmailService EmailService { get; }
        IPharmacyService PharmacyService { get; }
        IPharmacyRequestService PharmacyRequestService { get; }
    }
}
