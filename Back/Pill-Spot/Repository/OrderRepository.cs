using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void UpdateOrder(Order order) => Update(order);

        public void CreateOrder(Order order) => Create(order);

        public async Task<Order> GetOrderByIdAsync(Guid orderId, bool trackChanges) =>
            await FindByCondition(o => o.OrderId.Equals(orderId), trackChanges).SingleOrDefaultAsync();

        public async Task<PagedList<Order>> GetOrders(OrderRequestParameters orderRequestParameters, bool trackChanges)
        {
            var orders = await FindAll(trackChanges)
                .Sort(orderRequestParameters.OrderBy)
                .Skip((orderRequestParameters.PageNumber - 1) * orderRequestParameters.PageSize)
                .Take(orderRequestParameters.PageSize)
                .Include(p => p.Location)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Order>(orders, count, orderRequestParameters.PageNumber, orderRequestParameters.PageSize);
        }

        public async Task<PagedList<Order>> GetOrdersByUserIdAsync(string userId, OrderRequestParameters orderRequestParameters, bool trackChanges)
        {
            var orders = await FindByCondition(o => o.UserId.Equals(userId), trackChanges)
                .Sort(orderRequestParameters.OrderBy)
                .Skip((orderRequestParameters.PageNumber - 1) * orderRequestParameters.PageSize)
                .Take(orderRequestParameters.PageSize)
                .Include(p => p.Location)
                .ToListAsync();

            var count = await FindByCondition(o => o.UserId.Equals(userId), trackChanges).CountAsync();

            return new PagedList<Order>(orders, count, orderRequestParameters.PageNumber, orderRequestParameters.PageSize);
        }
    }
}
