namespace Entities.Exceptions
{
    public class MedicineNotFoundException : NotFoundException
    {
        public MedicineNotFoundException(Guid medicineId) : base($"Medicine with id {medicineId} doesn't exist in the database.")
        {
            
        }
    }
}
