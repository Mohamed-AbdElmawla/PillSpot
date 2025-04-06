using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        Task<Order> GetOrderByIdAsync(Guid orderId, bool trackChanges);
        Task<PagedList<Order>> GetOrders(OrderRequestParameters orderRequestParameters, bool trackChanges);
        Task<PagedList<Order>> GetOrdersByUserIdAsync(string userId, OrderRequestParameters orderRequestParameters, bool trackChanges);
        void UpdateOrder(Order order);
    }
}
