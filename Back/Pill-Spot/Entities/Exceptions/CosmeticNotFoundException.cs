namespace Entities.Exceptions
{
    public class CosmeticNotFoundException: NotFoundException
    {
        public CosmeticNotFoundException(Guid productId) : base($"Cosmetics with id: {productId} wasn't found")
        {

        }
    }
}
