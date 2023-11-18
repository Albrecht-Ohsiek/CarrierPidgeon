using CarrierPidgeon.Models;
using MongoDB.Bson;

namespace CarrierPidgeon.Repositories{
    public interface IUserRepository{
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByName(string name);
        Task<User> GetUserById(ObjectId _id);
        Task<User> RegisterUser(User user);
        Task<User> UpdateUserById(ObjectId userId, User user);
    }
}