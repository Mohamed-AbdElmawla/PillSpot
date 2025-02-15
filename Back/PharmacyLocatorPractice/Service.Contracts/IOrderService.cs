using Shared.DataTransferObjects;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(string userId, bool trackChanges);
    Task<OrderDto> GetOrderAsync(string userId, string orderId, bool trackChanges);
    Task<OrderDto> CreateOrderAsync(OrderForCreationDto orderForCreationDto, string userId);
    Task UpdateOrderAsync(string orderId, string userId, OrderForCreationDto orderForCreationDto, bool trackChanges);
    Task DeleteOrderAsync(string orderId, string userId, bool trackChanges);
}
