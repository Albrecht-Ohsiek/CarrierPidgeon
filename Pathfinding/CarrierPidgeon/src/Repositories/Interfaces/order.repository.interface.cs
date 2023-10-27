using CarrierPidgeon.Models;
using MongoDB.Bson;

namespace CarrierPidgeon.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrderByStatus(string status);
        Task<Order> GetFirstOrderByStatus(string status);
        Task<Order> GetOrderByUserID(string userId);
        Task<Order> GetOrder(ObjectId _id);
        Task<Order> RegisterOrder(Order order);
        Task<Order> UpdateStatus(ObjectId userId, Order order);
    }
}