using CarrierPidgeon.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarrierPidgeon.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(DatabaseServices dbContext)
        {
            _userCollection = dbContext.GetCollection<User>("users");
        }

        Task<User> IUserRepository.RegisterUser(User user)
        {
            _userCollection.InsertOneAsync(user);
            return Task.FromResult(user);
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _userCollection.Find(user => user.name == name).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userCollection.Find(user => user.email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(ObjectId userId)
        {
            return await _userCollection.Find(user => user._id == userId).FirstOrDefaultAsync();
        }

        Task<User> IUserRepository.UpdateUserById(ObjectId userId, User user)
        {
            var filter = Builders<User>.Filter.Eq(user => user._id, userId);
            _userCollection.ReplaceOneAsync(filter, user);
            return Task.FromResult(user);
        }
    }
}