using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDeliveryService
    {
        Task<IEnumerable<OrderDto>> GetPendingDeliveriesAsync(string userId, bool trackChanges);
        Task<IEnumerable<OrderDto>> GetReadyToDeliverOrdersAsync(string userId, bool trackChanges);
        Task<bool> MarkOrderAsReadyToDeliverAsync(string userId, string orderId);
        Task<bool> MarkOrderAsDeliveredAsync(string userId, string orderId);
    }
}
