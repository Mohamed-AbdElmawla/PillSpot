namespace Entities.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(string orderId)
            : base($"Order with id: {orderId} was not found.")
        {
        }
    }
}