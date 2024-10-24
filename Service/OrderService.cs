using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Collections.Generic;

namespace Service
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<IServiceManager> _logger;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repository, ILogger<IServiceManager> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task <IEnumerable<OrderDto>> GetOrdersAsync(bool trackChanges)
        {
            var orders =  await _repository.Order.GetOrdersAsync(trackChanges);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        public async Task<OrderDto> GetOrderAsync(int orderId, bool trackChanges)
        {
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges);
            if (order is null)
                throw new OrderNotFoundException(orderId);

            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderForCreationDto orderForCreationDto, bool trackChanges)
        {
            var orderEntity = _mapper.Map<Order>(orderForCreationDto);

            foreach (var orderItemDto in orderForCreationDto.OrderItems)
            {
                var orderItemEntity = _mapper.Map<OrderItem>(orderItemDto);
                orderEntity.OrderItems.Add(orderItemEntity);
            }

            _repository.Order.CreateOrder(orderEntity);
            _repository.SaveAsync();

            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);
            return orderToReturn;
        }

        public async Task UpdateOrderAsync(int orderId, OrderForCreationDto orderForCreationDto, bool trackChanges)
        {
            var orderEntity = await _repository.Order.GetOrderAsync(orderId, trackChanges);
            if (orderEntity is null)
                throw new OrderNotFoundException(orderId);

            _mapper.Map(orderForCreationDto, orderEntity);

            orderEntity.OrderItems.Clear();

            foreach (var itemDto in orderForCreationDto.OrderItems)
            {
                var orderItemEntity = _mapper.Map<OrderItem>(itemDto);
                orderEntity.OrderItems.Add(orderItemEntity);
            }

            _repository.SaveAsync();
        }

        public async Task DeleteOrderAsync(int orderId, bool trackChanges)
        {
            var orderEntity = await _repository.Order.GetOrderAsync(orderId, trackChanges);
            if (orderEntity is null)
                throw new OrderNotFoundException(orderId);

            _repository.Order.DeleteOrder(orderEntity);
            _repository.SaveAsync();
        }
    }
}
