namespace Entities.Exceptions
{
    public class PharmacyProductNotFoundException : NotFoundException
    {
        public PharmacyProductNotFoundException(Guid productId, Guid pharmacyId)
            : base($"PharmacyProduct with PharmacyId: {pharmacyId} and ProductId: {productId} was not found.")
        {
        }
    }
}
