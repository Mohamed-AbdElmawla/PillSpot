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
        Task<IEnumerable<OrderDto>> GetOrdersAsync(bool trackChanges);
        Task<OrderDto> GetOrderAsync(int orderId, bool trackChanges);
        Task<OrderDto> CreateOrderAsync(OrderForCreationDto orderForCreationDto, bool trackChanges);
     //   Task<IEnumerable<OrderDto>> GetOrdersByStatusAsync(string status, bool trackChanges);
        Task UpdateOrderAsync(int orderId, OrderForCreationDto orderForCreationDto, bool trackChanges);
        Task DeleteOrderAsync(int orderId, bool trackChanges);
    }
}
