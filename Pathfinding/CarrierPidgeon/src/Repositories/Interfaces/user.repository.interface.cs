using CarrierPidgeon.Models;

namespace CarrierPidgeon.Repositories{
    public interface IUserRepository{
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByName(string email);
        Task<User> RegisterUser(User user);
    }
}