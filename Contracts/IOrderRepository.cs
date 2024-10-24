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
        IEnumerable<Order> GetOrders(bool trackChanges);
        Order GetOrder(int orderId, bool trackChanges);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
