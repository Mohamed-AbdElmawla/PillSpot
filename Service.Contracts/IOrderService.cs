using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetOrders(bool trackChanges);
        OrderDto GetOrder(int orderId, bool trackChanges);
        OrderDto CreateOrder(OrderForCreationDto orderForCreationDto, bool trackChanges);
        void UpdateOrder(int orderId, OrderForCreationDto orderForCreationDto, bool trackChanges);
        void DeleteOrder(int orderId, bool trackChanges);
    }
}
