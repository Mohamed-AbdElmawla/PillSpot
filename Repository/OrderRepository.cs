using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Order>> GetOrdersAsync(bool trackChanges) => await FindAll(trackChanges).OrderBy(o => o.OrderedAt).ToListAsync();

        public async Task<Order> GetOrderAsync(int orderId, bool trackChanges) => await FindByCondition(o => o.Id.Equals(orderId), trackChanges).SingleOrDefaultAsync();

        public void CreateOrder(Order order) => Create(order);

        public void DeleteOrder(Order order) => Delete(order);

    }

}
