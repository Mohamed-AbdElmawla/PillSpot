using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync(bool trackChanges);
        Task<Order>GetOrderAsync(int orderId, bool trackChanges);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
