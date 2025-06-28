namespace Entities.Exceptions
{
    public class SubCategoryNotFoundException : NotFoundException
    {
        public SubCategoryNotFoundException(Guid subCategoryId):base($"Sub category with id: {subCategoryId} wasn't found")
        {
            
        }
    }
}
