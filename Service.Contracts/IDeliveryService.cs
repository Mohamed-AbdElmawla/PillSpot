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
        Task<IEnumerable<OrderDto>> GetPendingDeliveriesAsync(bool trackChanges);
        Task<bool> MarkOrderAsDeliveredAsync(int orderId);
    }
}
