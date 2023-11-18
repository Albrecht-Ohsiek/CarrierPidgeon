using CarrierPidgeon.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarrierPidgeon.Repositories{
    public class OrderRepository: IOrderRepository{
         private readonly IMongoCollection<Order> _orderCollection;

        public OrderRepository(DatabaseServices dbContext)
        {
            _orderCollection = dbContext.GetCollection<Order>("orders");
        }

        public async Task<Order> GetOrder(ObjectId _id)
        {
            return await _orderCollection.Find(order => order._id == _id).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrderByStatus(string status)
        {
            return await _orderCollection.Find(order => order.status == status).ToListAsync();
        }

        public async Task<Order> GetFirstOrderByStatus(string status)
        {
            return await _orderCollection.Find(order => order.status == status).FirstOrDefaultAsync();
        }

        public async Task<Order> GetOrderByUserID(string userId)
        {
            return await _orderCollection.Find(order => order.userId == userId).FirstOrDefaultAsync();
        }

        public Task<Order> RegisterOrder(Order order)
        {
            _orderCollection.InsertOneAsync(order);
            return Task.FromResult(order);
        }

        public Task<Order> UpdateStatus(ObjectId orderId, Order order)
        {
            var filter = Builders<Order>.Filter.Eq(order => order._id, orderId);
            _orderCollection.ReplaceOneAsync(filter, order);
            return Task.FromResult(order);
        }
    }
}