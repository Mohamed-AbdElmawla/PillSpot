using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class DeliveryService : IDeliveryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<IServiceManager> _logger;
        private readonly IMapper _mapper;
        public DeliveryService(IRepositoryManager repository , ILogger<IServiceManager> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetPendingDeliveriesAsync(bool trackChanges)
        {
            var pendingOrders = await _repository.Order.GetOrdersByStatusAsync("Pending", trackChanges);
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(pendingOrders);
            return ordersDto;
        }

        public async Task<bool> MarkOrderAsDeliveredAsync(int orderId)
        {
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges: true);
            if (order == null) 
                return false;

            order.Status = "Delivered";
            await _repository.SaveAsync();

            return true;
        }
    }
}
