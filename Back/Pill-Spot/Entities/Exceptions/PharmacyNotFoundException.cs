namespace Entities.Exceptions
{
    public class PharmacyNotFoundException : NotFoundException
    {
        public PharmacyNotFoundException(Guid pharmacyId)
        : base($"The pharmacy with id: {pharmacyId} doesn't exist in the database.")
        { }
    }
}
