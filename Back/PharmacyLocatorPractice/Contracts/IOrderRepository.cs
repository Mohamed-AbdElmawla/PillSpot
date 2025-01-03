using Entities.Models;
namespace Contracts
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByUserIdAndOrderIdAsync(string userId, string orderId, bool trackChanges);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId, bool trackChanges);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
