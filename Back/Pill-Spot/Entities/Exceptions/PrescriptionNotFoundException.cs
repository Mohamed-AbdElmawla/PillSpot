namespace Entities.Exceptions
{
    public sealed class PrescriptionNotFoundException : NotFoundException
    {
        public PrescriptionNotFoundException(Guid id) : base($"The prescription with id {id} was not found.") { }
    }
}