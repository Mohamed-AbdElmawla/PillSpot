using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderForCreationDto orderDto);
        Task<OrderDto> GetOrderByIdAsync(Guid orderId, bool trackChanges);
        Task<(IEnumerable<OrderDto> orders, MetaData metaData)> GetOrdersAsync(OrderRequestParameters orderRequestParameters, bool trackChanges);
        Task<(IEnumerable<OrderDto> orders, MetaData metaData)> GetOrdersByUserIdAsync(string userId, OrderRequestParameters orderRequestParameters, bool trackChanges);
        Task<bool> CancelOrderAsync(Guid orderId);
    }
}
