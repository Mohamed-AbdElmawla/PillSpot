namespace Entities.Exceptions
{
    public sealed class PrescriptionProductNotFoundException : NotFoundException
    {
        public PrescriptionProductNotFoundException(Guid prescriptionId, Guid productId) : base($"The product with id {productId} in prescription {prescriptionId} was not found.") { }
    }
}