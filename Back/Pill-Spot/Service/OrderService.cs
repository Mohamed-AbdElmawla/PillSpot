using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly INotificationService _notificationService;

        public OrderService(
            IRepositoryManager repository, 
            IMapper mapper,
            UserManager<User> userManager,
            INotificationService notificationService)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _notificationService = notificationService;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderForCreationDto orderDto)
        {
            var user = await _userManager.FindByIdAsync(orderDto.UserId);
            if (user == null)
                throw new UserNotFoundException(orderDto.UserId);

            var order = _mapper.Map<Order>(orderDto);
                
            double totalPrice = 0;
            foreach (var item in order.OrderItems)
            {
                var product = await _repository.ProductRepository.GetProductAsync(item.ProductId, trackChanges: false);
                if (product == null)
                    throw new ProductNotFoundException(item.ProductId);

                item.UnitPrice = product.Price;
                totalPrice += item.UnitPrice * item.Quantity;
            }

            order.TotalPrice = totalPrice;

            _repository.OrderRepository.CreateOrder(order);
            await _repository.SaveAsync();

            // Send notification to user by username
            await _notificationService.SendNotificationByUsernameAsync(
                user.UserName,
                "New Order Created",
                $"Your order #{order.OrderId} has been created successfully.",
                NotificationType.OrderCreated,
                JsonSerializer.Serialize(new { orderId = order.OrderId })
            );

            // Send notification to admin by usernames
            await _notificationService.SendNotificationToRolesAsync(
                new[] { "Admin", "SuperAdmin" },
                "New Order Received",
                $"New order #{order.OrderId} has been placed.",
                NotificationType.NewOrder,
                JsonSerializer.Serialize(new { orderId = order.OrderId })
            );

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> GetOrderByIdAsync(Guid orderId, bool trackChanges)
        {
            var order = await _repository.OrderRepository.GetOrderByIdAsync(orderId, trackChanges);
            if (order == null)
                throw new OrderFoundException(orderId);

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<(IEnumerable<OrderDto> orders, MetaData metaData)> GetOrdersAsync(OrderRequestParameters orderRequestParameters, bool trackChanges)
        {
            var orders = await _repository.OrderRepository.GetOrders(orderRequestParameters, trackChanges);
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);

            return (orders: ordersDto, metaData: orders.MetaData);
        }

        public async Task<(IEnumerable<OrderDto> orders, MetaData metaData)> GetOrdersByUserIdAsync(string userId, OrderRequestParameters orderRequestParameters, bool trackChanges)
        {
            var orders = await _repository.OrderRepository.GetOrdersByUserIdAsync(userId, orderRequestParameters, trackChanges);
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);

            return (orders: ordersDto, metaData: orders.MetaData);
        }

        public async Task<bool> CancelOrderAsync(Guid orderId)
        {
            var order = await _repository.OrderRepository.GetOrderByIdAsync(orderId, trackChanges: true);
            if (order == null || order.IsDeleted)
                return false;

            order.IsDeleted = true;

            await _repository.SaveAsync();

            return true;
        }

        public async Task UpdateOrderStatusAsync(Guid orderId, string status)
        {
            var order = await GetOrderByIdAndCheckIfExists(orderId, trackChanges: true);
            order.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), status);
            await _repository.SaveAsync();

            // Get user by ID to get username
            var user = await _userManager.FindByIdAsync(order.UserId);
            if (user != null)
            {
                // Send notification to user by username
                await _notificationService.SendNotificationByUsernameAsync(
                    user.UserName,
                    "Order Status Updated",
                    $"Your order #{order.OrderId} status has been updated to {status}.",
                    NotificationType.DeliveryStatus,
                    JsonSerializer.Serialize(new { orderId = order.OrderId, status })
                );
            }
        }

        public async Task SendPaymentConfirmationAsync(Guid orderId, decimal amount)
        {
            var order = await GetOrderByIdAndCheckIfExists(orderId, trackChanges: true);
            
            // Get user by ID to get username
            var user = await _userManager.FindByIdAsync(order.UserId);
            if (user != null)
            {
                await _notificationService.SendNotificationByUsernameAsync(
                    user.UserName,
                    "Payment Confirmed",
                    $"Your payment of ${amount:F2} for order {orderId} has been confirmed",
                    NotificationType.PaymentConfirmation,
                    JsonSerializer.Serialize(new { orderId, amount })
                );
            }
        }

        private async Task<Order> GetOrderByIdAndCheckIfExists(Guid orderId, bool trackChanges)
        {
            var order = await _repository.OrderRepository.GetOrderByIdAsync(orderId, trackChanges);
            if (order == null)
                throw new OrderNotFoundException(orderId);
            return order;
        }
    }
}
