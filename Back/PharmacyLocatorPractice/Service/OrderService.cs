using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<IServiceManager> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public OrderService(IRepositoryManager repository, ILogger<IServiceManager> logger, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(string userId, bool trackChanges)
        {
            var orders = await _repository.Order.GetOrdersByUserIdAsync(userId, trackChanges);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersDto;
        }

        public async Task<OrderDto> GetOrderAsync(string userId, string orderId, bool trackChanges)
        {
            var order = await _repository.Order.GetOrderByUserIdAndOrderIdAsync(userId, orderId, trackChanges);
            if (order is null)
                throw new OrderNotFoundException(orderId);

            var orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderForCreationDto orderForCreationDto, string userId)
        {
            var orderEntity = _mapper.Map<Order>(orderForCreationDto);
            orderEntity.UserId = userId;
            orderEntity.OrderedAt = DateTime.UtcNow;
            orderEntity.Status = Status.Pending;

            decimal totalPrice = 0; 

            foreach (var orderItemDto in orderForCreationDto.OrderItems)
            {
                var pharmacyMedicine = await _repository.PharmacyMedicine.GetMedicineAsync(
                    orderItemDto.PharmacyId, orderItemDto.MedicineId, trackChanges: true);

                if (pharmacyMedicine == null)
                    throw new PharmacyMedicineNotFoundException(orderItemDto.PharmacyId, orderItemDto.MedicineId);

                if (pharmacyMedicine.Quantity < orderItemDto.Quantity)
                    throw new InsufficientStockException(orderItemDto.MedicineId, pharmacyMedicine.Quantity);

                pharmacyMedicine.Quantity -= orderItemDto.Quantity;

                var orderItemEntity = _mapper.Map<OrderItem>(orderItemDto);
                orderItemEntity.UnitPrice = pharmacyMedicine.Price; 
                orderItemEntity.OrderId = orderEntity.OrderId;

                orderEntity.OrderItems.Add(orderItemEntity);

                totalPrice += orderItemEntity.UnitPrice * orderItemEntity.Quantity;
            }

            orderEntity.TotalPrice = totalPrice;

            _repository.Order.CreateOrder(orderEntity);

            await _repository.SaveAsync();

            var orderDto = _mapper.Map<OrderDto>(orderEntity);
            return orderDto;
        }


        public async Task UpdateOrderAsync(string orderId, string userId, OrderForCreationDto orderForCreationDto, bool trackChanges)
        {
            var orderEntity = await _repository.Order.GetOrderByUserIdAndOrderIdAsync(userId, orderId, trackChanges);
            if (orderEntity is null)
                throw new OrderNotFoundException(orderId);

            foreach (var existingItem in orderEntity.OrderItems)
            {
                var pharmacyMedicine = await _repository.PharmacyMedicine.GetMedicineAsync(
                    existingItem.pharmacyId, existingItem.MedicineId, trackChanges: true);

                if (pharmacyMedicine != null)
                    pharmacyMedicine.Quantity += existingItem.Quantity;
            }

            orderEntity.OrderItems.Clear();
            foreach (var itemDto in orderForCreationDto.OrderItems)
            {
                var pharmacyMedicine = await _repository.PharmacyMedicine.GetMedicineAsync(
                    itemDto.PharmacyId, itemDto.MedicineId, trackChanges: true);

                if (pharmacyMedicine == null)
                    throw new PharmacyMedicineNotFoundException(itemDto.PharmacyId, itemDto.MedicineId);

                if (pharmacyMedicine.Quantity < itemDto.Quantity)
                    throw new InsufficientStockException(itemDto.MedicineId, pharmacyMedicine.Quantity);

                pharmacyMedicine.Quantity -= itemDto.Quantity;

                var orderItemEntity = _mapper.Map<OrderItem>(itemDto);
                orderItemEntity.UnitPrice = pharmacyMedicine.Price;
                orderEntity.OrderItems.Add(orderItemEntity);
            }

            orderEntity.TotalPrice = orderEntity.OrderItems.Sum(item => item.UnitPrice * item.Quantity);

            await _repository.SaveAsync();
        }


        public async Task DeleteOrderAsync(string orderId, string userId, bool trackChanges)
        {
            var orderEntity = await _repository.Order.GetOrderByUserIdAndOrderIdAsync(userId, orderId, trackChanges);
            if (orderEntity is null)
                throw new OrderNotFoundException(orderId);

            foreach (var orderItem in orderEntity.OrderItems)
            {
                var pharmacyMedicine = await _repository.PharmacyMedicine.GetMedicineAsync(
                    orderItem.pharmacyId, orderItem.MedicineId, trackChanges: true);

                if (pharmacyMedicine != null)
                    pharmacyMedicine.Quantity += orderItem.Quantity;
            }

            _repository.Order.DeleteOrder(orderEntity);
            await _repository.SaveAsync();
        }

    }
}
