using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class DeliveryService : IDeliveryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<IServiceManager> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public DeliveryService(IRepositoryManager repository, ILogger<IServiceManager> logger, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<OrderDto>> GetPendingDeliveriesAsync(string userId, bool trackChanges)
        {
            var orders = await _repository.Order.GetOrdersByUserIdAsync(userId, trackChanges);
            var pendingOrders = orders.Where(o => o.Status == Status.Pending);
            return _mapper.Map<IEnumerable<OrderDto>>(pendingOrders);
        }

        public async Task<IEnumerable<OrderDto>> GetReadyToDeliverOrdersAsync(string userId, bool trackChanges)
        {
            var orders = await _repository.Order.GetOrdersByUserIdAsync(userId, trackChanges);
            var readyToDeliverOrders = orders.Where(o => o.Status == Status.ReadyToDeliver);

            return _mapper.Map<IEnumerable<OrderDto>>(readyToDeliverOrders);
        }

        public async Task<bool> MarkOrderAsReadyToDeliverAsync(string userId, string orderId)
        {
            if (userId == null)
            {
                _logger.LogWarning($"This User {orderId} not found.");
                return false;
            }
            var order = await _repository.Order.GetOrderByUserIdAndOrderIdAsync(userId, orderId, trackChanges: true);

            if (order == null)
            {
                _logger.LogWarning($"Order with ID {orderId} not found.");
                return false;
            }

            order.Status = Status.ReadyToDeliver;
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> MarkOrderAsDeliveredAsync(string userId, string orderId)
        {
            var order = await _repository.Order.GetOrderByUserIdAndOrderIdAsync(userId, orderId, trackChanges: false);
            if (order == null)
                return false;

            order.Status = Status.Delivered;
            await _repository.SaveAsync();

            return true;
        }
    }
}
