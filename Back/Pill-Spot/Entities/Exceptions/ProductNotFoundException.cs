namespace Entities.Exceptions
{
    public class ProductNotFoundException: NotFoundException
    {
        public ProductNotFoundException(Guid productId):base($"Product with id: {productId} wasn't found")
        {
            
        }
    }
}
