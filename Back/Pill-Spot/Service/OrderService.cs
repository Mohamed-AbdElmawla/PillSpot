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

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public OrderService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
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
    }
}
