using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Order> GetOrderByUserIdAndOrderIdAsync(string userId, string orderId, bool trackChanges) =>
            await FindByCondition(o => o.UserId == userId && o.OrderId == orderId, trackChanges)
            .Include(o => o.OrderItems).SingleOrDefaultAsync();
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId, bool trackChanges) =>
            await FindByCondition(o => o.UserId == userId, trackChanges)
            .Include(o => o.OrderItems).ToListAsync();
        public void CreateOrder(Order order) => Create(order);

        public void DeleteOrder(Order order) => Delete(order);

    }

}
