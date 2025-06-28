namespace Entities.Exceptions
{
    public sealed class PharmacyRequestNotFoundException: NotFoundException
    {
        public PharmacyRequestNotFoundException(Guid requestId) : base($"Pharmacy request with id: {requestId} not found")
        {
            
        }
    }
}
