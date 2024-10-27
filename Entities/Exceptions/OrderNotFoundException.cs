namespace Entities.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(int orderId)
            : base($"Order with id: {orderId} was not found.")
        {
        }
    }
}