namespace Entities.Exceptions
{
    public class BatchNotFoundException : NotFoundException
    {
        public BatchNotFoundException(Guid productId, Guid pharmacyId)
            : base($"Batch for ProductId: {productId} and PharmacyId: {pharmacyId} was not found.")
        {
        }
    }
}
